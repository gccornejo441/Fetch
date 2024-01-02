using Fetch.Shared;
using Grpc.Net.Client;

namespace Fetch.Cli.GrpcServices;

public class CliGreeterApi
{
    public static void GreeterService()
    {
        var channel = GrpcChannel.ForAddress("https://localhost:7290");
        var client = new SandwichShopService.SandwichShopServiceClient(channel);

        var shops = client.GetAllSandwichShops(new Google.Protobuf.WellKnownTypes.Empty());

        var sandwichShops = shops.SandwichShops;

        if (shops != null)
        {
            foreach (var shop in sandwichShops)
            {
                foreach (var location in shop.Address)
                {
                    Console.WriteLine($"Shop Id: {shop.Id}{Environment.NewLine}Shop Name: {shop.Shop}{Environment.NewLine}Addresses:");
                    Console.WriteLine($" - Id: {location.Id}, ShopId: {shop.Id}, Address: {location.Address}");
                }
            }
        }
        else
        {
            Console.WriteLine("no shops");
        }
    }
}
