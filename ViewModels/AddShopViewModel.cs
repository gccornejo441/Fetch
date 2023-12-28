using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Fetch.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fetch.ViewModels
{
    public partial class AddShopViewModel : BaseViewModel
    {
        public ObservableCollection<SandwichShop> SandwichShops { get; set; } = new();
        public AddShopViewModel()
        {

        }

        [ObservableProperty]
        string defaultPageTitle;



        [RelayCommand]
        void PostNewShop()
        {

        }
    }
}
