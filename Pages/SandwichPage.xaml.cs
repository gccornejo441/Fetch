using Fetch.ViewModels;

namespace Fetch.Pages;

public partial class SandwichPage : ContentPage
{
	public SandwichPage(SandwichViewModel sandwichViewModel)
	{
		InitializeComponent();

		BindingContext = sandwichViewModel;
	}
}