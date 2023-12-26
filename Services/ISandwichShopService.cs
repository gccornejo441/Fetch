namespace Fetch.Services;

public interface ISandwichShopService
{
    
    Task<IEnumerable<Location>> GetLocations(string query);
}
