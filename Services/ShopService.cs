using Fetch.Shared;

namespace Fetch.Services
{
    public class ShopService
    {
        private readonly SandwichShopService.SandwichShopServiceClient _client;

        public ShopService(SandwichShopService.SandwichShopServiceClient client)
        {
            _client = client;
        }

        List<SandwichShop> sandwichShop = new();
        public List<SandwichShop> GetSandwichShops()
        {
            var shops = _client.GetAllSandwichShops(new Google.Protobuf.WellKnownTypes.Empty());

            foreach (var shop in shops.SandwichShops)
            {
                sandwichShop.Add(shop);
            }

            return sandwichShop;
        }

    }
}
