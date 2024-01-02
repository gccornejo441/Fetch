using Fetch.Shared;
using Grpc.Net.Client;

namespace Fetch.Cli.GrpcServices;

public class CliRestaurantApi
{
    public static void RestaurantService()
    {
        var channel = GrpcChannel.ForAddress("https://localhost:7290");
        var client = new RestaurantService.RestaurantServiceClient(channel);

        // Prompt for restaurant details
        Console.WriteLine("Enter new restaurant details:");
        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Type ID (number): ");
        int typeId = int.Parse(Console.ReadLine());  // Add validation for non-integer input

        Console.Write("Address: ");
        string address = Console.ReadLine();

        Console.Write("Rating (0.0 to 5.0): ");
        float rating = float.Parse(Console.ReadLine());  // Add validation for non-float input

        Console.Write("Phone Number: ");
        string phoneNumber = Console.ReadLine();

        Console.Write("Website URL: ");
        string websiteUrl = Console.ReadLine();

        Console.Write("Description: ");
        string description = Console.ReadLine();

        Console.Write("Opening Hours: ");
        string openingHours = Console.ReadLine();

        var newRestaurant = new Restaurant
        {
            Name = name,
            RestaurantTypeId = typeId,
            Address = address,
            Rating = rating,
            PhoneNumber = phoneNumber,
            WebsiteUrl = websiteUrl,
            Description = description,
            OpeningHours = openingHours
        };

        // Send data to gRPC service
        var createdRestaurant = client.CreateRestaurant(newRestaurant);
        Console.WriteLine($"Restaurant Created: {createdRestaurant.Name} with ID: {createdRestaurant.Id}");

        // Prompt for location details
        Console.WriteLine("Enter new location details for a restaurant:");
        Console.Write("Restaurant ID: ");
        int restaurantId = int.Parse(Console.ReadLine()); // Add validation for non-integer input

        Console.Write("City: ");
        string city = Console.ReadLine();

        Console.Write("State: ");
        string state = Console.ReadLine();

        Console.Write("Zip Code: ");
        string zipCode = Console.ReadLine();

        var newLocation = new Location
        {
            RestaurantId = restaurantId,
            Address = address,
            City = city,
            State = state,
            ZipCode = zipCode
        };

        // Send data to gRPC service
        try
        {
            var createdLocation = client.CreateLocation(newLocation);
            Console.WriteLine($"Location Created: {createdLocation.Address} for Restaurant ID: {createdLocation.RestaurantId}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}

    //public static void RestaurantService()
    //{
    //    var channel = GrpcChannel.ForAddress("https://localhost:7290");
    //    var client = new RestaurantService.RestaurantServiceClient(channel);

    //    var newRestaurant = new Restaurant
    //    {
    //        Name = "Mock Restaurant",
    //        TypeId = 2, // Assuming this refers to a valid type in restaurant_types
    //        Address = "123 Mock Street",
    //        Rating = 4.5f,
    //        PhoneNumber = "123-456-7890",
    //        WebsiteUrl = "http://www.mockrestaurant.com",
    //        Description = "This is a mock description of a restaurant.",
    //        OpeningHours = "9 AM - 10 PM"
    //    };

    //    client.CreateRestaurant(newRestaurant);
    //}
//}
