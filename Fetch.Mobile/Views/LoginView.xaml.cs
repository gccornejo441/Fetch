using System.Security.Cryptography;

namespace Fetch.Mobile.Views;

public partial class LoginView : ContentPage
{
	private long _counter = 0;
	public LoginView()
	{
		InitializeComponent();
	}

	[RelayCommand]
	public void IncrementCounter()
	{
		// Used to safely increment this counter
		Interlocked.Increment(ref _counter);
	}

	public long CounterValue => Interlocked.Read(ref _counter);

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync("CommandView");
    }
}