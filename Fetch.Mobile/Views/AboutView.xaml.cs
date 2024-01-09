using System.Windows.Input;

namespace Fetch.Mobile.Views;

public partial class AboutView : ContentPage
{
	public AboutView()
	{
		InitializeComponent();
	}

	private ICommand _showNameCommand;

	private string id = "123";
	protected async Task ShowName()
	{
		await Shell.Current.GoToAsync($"{nameof(MyNewPage)}?QueryId={id}");
	}

	public ICommand ShowNameCommand() => _showNameCommand ?? (_showNameCommand =
		new Command(async param => await ShowName()));
}