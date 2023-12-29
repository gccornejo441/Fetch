using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Fetch.Model.Entities;
using Fetch.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Fetch.ViewModels
{
    public partial class AddShopViewModel : BaseViewModel
    {
        [ObservableProperty]
        Shop currentShop;
        [ObservableProperty]
        string defaultPageTitle;
        
        public AddShopViewModel()
        {
            CurrentShop = new Shop();
        }


        [RelayCommand]
        void PostNewShop()
        {
            var Shop = CurrentShop.Shop1;
            var Address = CurrentShop.Locations;
            var Specialty = CurrentShop.Specialty;

            // Validate input data
            if (string.IsNullOrWhiteSpace(Shop) || Address != null || string.IsNullOrWhiteSpace(Specialty))
            {
                // Handle validation failure (e.g., notify the user)
                return;
            }

            defaultPageTitle = Shop;

        }
    }
}
