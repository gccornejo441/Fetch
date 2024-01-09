namespace Fetch.Mobile.ViewModel;

public partial class LoginViewModel : ObservableObject
{
    private long _counter = 0;

    [ObservableProperty]
    private long counterValue;

    public LoginViewModel() 
    {
        
    }

}
