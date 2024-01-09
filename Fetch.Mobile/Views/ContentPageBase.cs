namespace Fetch.Mobile.Views;

public class ContentPageBase : ContentPage
{
    public ContentPageBase()
    {
        NavigationPage.SetBackButtonTitle(this, "Trader Joe's");
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

    }
}
