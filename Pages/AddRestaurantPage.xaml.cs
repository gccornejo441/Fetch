using Fetch.ViewModels;

namespace Fetch.Pages;

public partial class AddRestaurantPage : ContentPage
{
	public AddRestaurantPage(AddRestaurantViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}