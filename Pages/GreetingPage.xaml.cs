using Fetch;
using Fetch.Shared;
using Fetch.ViewModels;

namespace Fetch.Pages;

public partial class GreetingPage : ContentPage
{
	private GreeterViewModel _greeterViewModel;
	public GreetingPage(GreeterViewModel greeterViewModel)
	{
		InitializeComponent();
		_greeterViewModel = greeterViewModel;
		BindingContext = _greeterViewModel;
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await _greeterViewModel.GreetAsync();
		var obj = new object();

	}
}