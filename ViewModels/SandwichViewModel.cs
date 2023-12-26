using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Fetch.Model.Entities;
using Fetch.Models;
using Fetch.Services;
using Fetch.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fetch.ViewModels
{
    public partial class SandwichViewModel : ObservableObject
    {
        public ObservableCollection<SandwichShop> SandwichShops { get; } = new();

        ShopService _shopService;
        public SandwichViewModel(ShopService shopService)
        {
            _shopService = shopService;
            DefaultShopName = "Default Name Title";
        }

        [ObservableProperty]
        string defaultShopName;

        
        [RelayCommand]
        public async Task SandwichShopsAsync()
        {
            try
            {
                var sandwhiches = _shopService.GetSandwichShops();
                foreach (var shop in sandwhiches)
                {
                    SandwichShops.Add(shop);
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }

            foreach (var shop in SandwichShops)
            {
                DefaultShopName = shop.Shop;
            }
        }   
    }
}
