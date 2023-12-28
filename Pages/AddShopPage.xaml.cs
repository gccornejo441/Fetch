using Fetch.ViewModels;

namespace Fetch.Pages;

public partial class AddShopPage : ContentPage
{
	public AddShopPage(AddShopViewModel addShopViewModel)
	{
		InitializeComponent();
		BindingContext = addShopViewModel;
	}
}