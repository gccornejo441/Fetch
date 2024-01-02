using Fetch.Cli.DbServices;
using Fetch.Cli.GrpcServices;
using Fetch.Model.ShopModels;

namespace Fetch.Cli;

public class Program
{
    static async Task Main(string[] args)
    {
        CliRestaurantApi.RestaurantService();

        //ShopService shopService = new();
        //bool continueRunning = true;

        //while (continueRunning)
        //{
        //    switch (ShowMenu())
        //    {
        //        case 1:
        //            ViewAllShops(shopService);
        //            break;
        //        case 2:
        //            AddAShopFromCli(shopService);
        //            break;
        //        case 3:
        //            DeleteShopById(shopService);
        //            break;
        //        case 4:
        //            await ViewShopByNamePrompt(shopService);
        //            break;
        //        case 5:
        //            continueRunning = false;
        //            break;
        //        default:
        //            Console.WriteLine("Invalid option, please try again.");
        //            break;
        //    }
        //}

        Console.WriteLine("Press any key to exit...");
        Console.ReadLine();
    }



    private static int ShowMenu()
    {
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1) View all shops");
        Console.WriteLine("2) Add a shop");
        Console.WriteLine("3) Delete a shop by ID");
        Console.WriteLine("4) View a shop by Name");
        Console.WriteLine("5) Exit");
        Console.Write("Enter choice: ");

        int.TryParse(Console.ReadLine(), out int choice);
        return choice;
    }


    private static async Task ViewShopByNamePrompt(ShopService shopService)
    {
        Console.WriteLine("Enter the name of the Shop you want to view:");
        var shopName = Console.ReadLine();
        await ViewShopByName(shopService, shopName);
    }

    public static async Task ViewShopByName(ShopService shopService, string shopName)
    {
        if (string.IsNullOrWhiteSpace(shopName))
        {
            Console.WriteLine("Shop name cannot be empty. Please try again.");
            return;
        }

        try
        {
            var shop = await shopService.GetShopByName(shopName);
            if (shop is null)
            {
                Console.WriteLine("Shop not found in our database. Please try a different name.");
                return;
            }

            var shopsName = shop.Shop1;
            var shopsLocation = shop.Locations.FirstOrDefault();

            if (shopsLocation is null)
            {
                Console.WriteLine($"Shop Name: {shopsName} has no locations registered.");
                return;
            }

            Console.WriteLine($"Is this the shop you are looking for?\nShop Name: {shopsName}\nLocation: {shopsLocation.Address}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }


    public static async Task ViewAllShops(ShopService shopService)
    {
        var shops = await shopService.GetAllShops();
        foreach (var shop in shops)
        {
            Console.WriteLine($"Shop Name: {shop.Shop1}, Specialty: {shop.Specialty}");
            foreach (var location in shop.Locations)
            {
                Console.WriteLine($"Location: {location.Address}");
            }
        }
    }

    private static void DeleteShopById(ShopService shopService)
    {
        Console.WriteLine("Enter the ID of the shop to delete:");
        if (int.TryParse(Console.ReadLine(), out int shopId))
        {
            shopService.DeleteShopById(shopId).Wait();
            Console.WriteLine($"Shop with ID {shopId} has been deleted.");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid shop ID.");
        }
    }

    public static void AddAShopFromCli(ShopService shopService)
    {
        string shopName;
        string specialty;
        List<Location> locations = new List<Location>();

        Console.WriteLine("Enter a Shop Name:");
        shopName = Console.ReadLine();

        Console.WriteLine("Enter the Specialty of the Shop:");
        specialty = Console.ReadLine();

        while (true)
        {
            Console.WriteLine("Enter an Address for the Shop (or 'done' to finish):");
            string address = Console.ReadLine();
            while (true)
            {
                if (!string.IsNullOrEmpty(address)) break;
                Console.WriteLine("Enter an Address for the Shop (or 'done' to finish):");
                address = Console.ReadLine();

            }

            if (address.ToLower() == "done") break;

            locations.Add(new Location { Address = address });
        }

        Shop shop = new Shop
        {
            Shop1 = shopName, // Assuming 'Shop1' is the property name for the shop name
            Specialty = specialty,
            Locations = locations
        };

        shopService.AddShop(shop).Wait(); // Call the method to add the shop with locations

    }
}
