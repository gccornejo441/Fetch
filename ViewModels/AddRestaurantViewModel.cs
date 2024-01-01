using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Fetch.Services;
using Fetch.Shared;
using System.Text.RegularExpressions;

namespace Fetch.ViewModels;

public partial class AddRestaurantViewModel : BaseViewModel
{
    private readonly IRestaurantServices _restaurantService;

    [ObservableProperty]
    Restaurant currentRestaurantObj;
    [ObservableProperty]
    string validationMessage;

    public AddRestaurantViewModel(IRestaurantServices restaurantServices)
    {
        _restaurantService = restaurantServices;
        currentRestaurantObj = new Restaurant();
    }

    [RelayCommand]
    void PostNewRestaurant()
    {
        if(IsBusy)
            return;

        if (!IsInputValid(CurrentRestaurantObj))
        {            
            return;
        }

        try
        {
            IsBusy = true;

            var newRestaurant = _restaurantService.AddRestaurant(CurrentRestaurantObj);
            if (newRestaurant != null)
            {
                ValidationMessage = $"Restaurant {newRestaurant.Name} added successfully";
            }
            else
            {
                ValidationMessage = "Failed to add new restaurant.";
            }
        }
        catch (Exception ex)
        {
            ValidationMessage = $"Error: {ex.Message}";
        }
        finally { IsBusy = false; }

    }

    private bool IsInputValid(Restaurant restaurant)
    {
        // Validate Restaurant Name
        if (string.IsNullOrWhiteSpace(restaurant.Name))
        {
            ValidationMessage = "Restaurant name is required.";
            return false;
        }

        // Validate TypeId (Assuming it should be a positive number)
        if (restaurant.TypeId <= 0)
        {
            ValidationMessage = "Invalid Type ID. Type ID must be positive.";
            return false;
        }

        // Validate Address
        if (string.IsNullOrWhiteSpace(restaurant.Address))
        {
            ValidationMessage = "Address is required.";
            return false;
        }

        // Validate Rating (assuming a scale of 0 to 5)
        if (restaurant.Rating < 0 || restaurant.Rating > 5)
        {
            ValidationMessage = "Rating must be between 0 and 5.";
            return false;
        }

        // Validate Phone Number (simple format validation)
        if (!Regex.IsMatch(restaurant.PhoneNumber, @"^\d{10}$"))
        {
            ValidationMessage = "Phone number must be a 10-digit number.";
            return false;
        }

        // Add more validations as necessary...

        ValidationMessage = string.Empty; // Reset validation message
        return true;
    }

}
