using System.Windows.Input;

namespace Fetch.Mobile.ViewModel;

public class UserAlert
{
    public string Title { get; set; }
    public string Message { get; set; }
    public string CancelName { get; set; }
}
public partial class CommandViewModel : ObservableObject
{
    private string userAlert = "HEY YOU OUT THERE ON YOUR OWN DO YOU HEAR ME?";
    public CommandViewModel()
    {
    }

    [RelayCommand]
    private async void AlertUser(UserAlert? userAlert)
    {
        await Shell.Current.DisplayAlert(userAlert.Title, userAlert.Message, userAlert.CancelName);
    }
}
