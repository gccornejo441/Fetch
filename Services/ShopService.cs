using Fetch.Model.Entities;
using Fetch.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Location = Fetch.Model.Entities.Location;

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
