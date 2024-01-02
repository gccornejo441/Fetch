using Fetch.Model.ShopModels;

namespace Fetch.Services;

public interface IShopService
{
    public Task<List<Shop>> GetAllShops();

    public Task AddShop(Shop shop);

    public Task UpdateShop(Shop shop);

    public Task DeleteShop(Shop shop);

    public Task DeleteShopById(int shopId);
}
