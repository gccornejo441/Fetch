namespace Fetch.Mobile.Views;

public partial class CommandView : ContentPage
{

	public CommandView()
	{
		InitializeComponent();
		BindingContext = new CommandViewModel();
	}
}