using Fetch.Shared;

namespace Fetch.Services;

public class RestaurantServices : IRestaurantServices
{
    private readonly RestaurantService.RestaurantServiceClient _client;
    public RestaurantServices(RestaurantService.RestaurantServiceClient client)
    {
        _client = client;
    }

    public Restaurant AddRestaurant(Restaurant restaurant)
    {
       var insertedRestaurant = _client.CreateRestaurant(new Restaurant
        {
            Name = restaurant.Name,
            TypeId = restaurant.TypeId,
            Address = restaurant.Address,
            Rating = restaurant.Rating,
            PhoneNumber = restaurant.PhoneNumber,
            WebsiteUrl = restaurant.WebsiteUrl,
            Description = restaurant.Description,
            OpeningHours = restaurant.OpeningHours,
        });

        return insertedRestaurant;
    }

    public void DeleteRestaurant(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Restaurant> GetAllRestaurants()
    {
        throw new NotImplementedException();
    }

    public Restaurant GetRestaurant(int id)
    {
        throw new NotImplementedException();
    }

    public Restaurant UpdateRestaurant(Restaurant restaurant)
    {
        throw new NotImplementedException();
    }
}
