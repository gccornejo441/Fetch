using Fetch.ViewModels;

namespace Fetch.Pages;

public partial class SandwichPage : ContentPage
{
    SandwichViewModel _sandwichViewModel;
	public SandwichPage(SandwichViewModel sandwichViewModel)
	{
		InitializeComponent();
		_sandwichViewModel = sandwichViewModel;
        BindingContext = _sandwichViewModel;
	}
}