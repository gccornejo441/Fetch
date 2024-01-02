using Fetch.Model.RestaurantModels;
using Fetch.Shared;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using DbLocation = Fetch.Model.RestaurantModels.Location;
using DbRestaurant = Fetch.Model.RestaurantModels.Restaurant;
using Location = Fetch.Shared.Location;
using Restaurant = Fetch.Shared.Restaurant;

namespace Fetch.Service.Services;

public class GrpcResturantService : RestaurantService.RestaurantServiceBase
{
    IConfiguration _config;
    private readonly ILogger<GrpcResturantService> _logger;
    public GrpcResturantService(ILogger<GrpcResturantService> logger, IConfiguration config)
    {
        _logger = logger;
        _config = config;
    }
    public override Task ListRestaurants(Empty request, IServerStreamWriter<Restaurant> responseStream, ServerCallContext context)
    {
        return base.ListRestaurants(request, responseStream, context);
    }
    public override async Task<Restaurant> CreateRestaurant(Restaurant request, ServerCallContext context)
    {
        var newRestaurant = new DbRestaurant
        {
            Name = request.Name,
            RestaurantTypeId = request.RestaurantTypeId,
            Address = request.Address,
            Rating = request.Rating,
            PhoneNumber = request.PhoneNumber,
            WebsiteUrl = request.WebsiteUrl,
            Description = request.Description,
            OpeningHours = request.OpeningHours,
            FoodTypeId = request.FoodTypeId
        };
        try
        {

            using (var dbContext = new FetchDbContext(_config)) 
            {
                dbContext.Restaurants.Add(newRestaurant);

                await dbContext.SaveChangesAsync();
            }

            var newAutoRestaurant = new Restaurant
            {
                Id = newRestaurant.Id, 
                Name = newRestaurant.Name,
                RestaurantTypeId = newRestaurant.RestaurantTypeId,
                Address = newRestaurant.Address,
                Rating = (double)newRestaurant.Rating,
                PhoneNumber = newRestaurant.PhoneNumber,
                WebsiteUrl = newRestaurant.WebsiteUrl,
                Description = newRestaurant.Description,
                OpeningHours = newRestaurant.OpeningHours,
                FoodTypeId = (int)newRestaurant.FoodTypeId
            };
            return newAutoRestaurant;

        }
        catch (Exception ex)
        {
            _logger.LogError($"Error creating restaurant: {ex.Message}");
            throw new RpcException(new Status(StatusCode.Internal, "Internal server error"));
        }

    }
    public override async Task<Location> CreateLocation(Location request, ServerCallContext context)
    {
        using (var dbContext = new FetchDbContext(_config))
        {
            var restaurantExists = await dbContext.Restaurants.AnyAsync(r => r.Id == request.RestaurantId);
            if (!restaurantExists)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "Restaurant not found"));
            }

            var newLocation = new DbLocation
            {
                RestaurantId = request.RestaurantId,
                Address = request.Address,
                City = request.City,
                State = request.State,
                ZipCode = request.ZipCode
            };

            try
            {
                dbContext.Locations.Add(newLocation);
                await dbContext.SaveChangesAsync();

                var newGrpcLocation = new Location
                {
                    Id = newLocation.Id,
                    RestaurantId = newLocation.RestaurantId,
                    Address = newLocation.Address,
                    City = newLocation.City,
                    State = newLocation.State,
                    ZipCode = newLocation.ZipCode
                };

                return newGrpcLocation;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating location: {ex.Message}");
                throw new RpcException(new Status(StatusCode.Internal, "Internal server error"));
            }
        }
    }

}
