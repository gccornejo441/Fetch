using Fetch.Model.ShopModels;
using Microsoft.EntityFrameworkCore;

namespace Fetch.Cli.DbServices;

public class ShopService : IShopService
{
    public async Task AddShop(Shop shop)
    {
        using (var context = new FetchContext())
        {
            context.Shops.Add(shop);

            await context.SaveChangesAsync();
        }
    }

    public async Task DeleteShop(Shop shop)
    {
        using (var context = new FetchContext())
        {
            context.Shops.Remove(shop);
            await context.SaveChangesAsync();
        }
    }

    public async Task<Shop> GetShopByName(string shopName)
    {
        using (var context = new FetchContext())
        {
            var shop = await context.Shops
                .Include(s => s.Locations)
                .FirstOrDefaultAsync(s => s.Shop1 == shopName);
            return shop;
        }
    }

    public async Task DeleteShopById(int shopId)
    {
        using (var context = new FetchContext())
        {
            var shop = await context.Shops
                                    .Include(s => s.Locations)
                                    .FirstOrDefaultAsync(s => s.Id == shopId);

            if (shop != null)
            {
                context.Shops.Remove(shop);
                await context.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine($"Shop with ID {shopId} not found.");
            }
        }

    }

    public Task<List<Shop>> GetAllShops()
    {
        List<Shop> shops = new List<Shop>();

        try
        {
            FetchContext fetchContext = new FetchContext();

            shops = fetchContext.Shops
                .Include(shop => shop.Locations)
                .ToList();

            if (shops.Count > 0)
            {
                foreach (Shop shop in shops)
                {
                    Console.WriteLine($"Shop Id: {shop.Id}{Environment.NewLine}Shop Name: {shop.Shop1}{Environment.NewLine}");

                    foreach (var location in shop.Locations)
                    {
                        Console.WriteLine($"Location Id: {location.Id}{Environment.NewLine}Address Name: {location.Address}{Environment.NewLine}");
                    }
                }
            }
            else
            {
                Console.WriteLine("ZERO SHOPS");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return Task.FromResult(shops);
    }

    public async Task UpdateShop(Shop shop)
    {
        using (var context = new FetchContext())
        {
            context.Shops.Update(shop);
            await context.SaveChangesAsync();
        }
    }
}
