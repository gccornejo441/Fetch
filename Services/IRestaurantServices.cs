using Fetch.Shared;

namespace Fetch.Services;

public interface IRestaurantServices
{
    Restaurant AddRestaurant(Restaurant restaurant);
    Restaurant GetRestaurant(int id);
    IEnumerable<Restaurant> GetAllRestaurants();
    Restaurant UpdateRestaurant(Restaurant restaurant);
    void DeleteRestaurant(int id);
}

