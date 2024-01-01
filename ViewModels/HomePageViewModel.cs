using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fetch.ViewModels
{
    public partial class HomePageViewModel : BaseViewModel
    {
        [RelayCommand]
        async Task GoToAddShop()
        {
            await Shell.Current.GoToAsync(nameof(AddRestaurantPage));
            
        }
    }
}
