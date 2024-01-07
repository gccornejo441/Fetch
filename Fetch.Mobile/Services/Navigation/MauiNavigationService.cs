using Fetch.Mobile.Services.Settings;

namespace Fetch.Mobile.Services;

public class MauiNavigationService : INavigationService
{
    private readonly ISettingsService _settingsService;

    public MauiNavigationService(ISettingsService settingsService) 
    {
        _settingsService = settingsService;
    }

    /// <summary>
    /// Initializes the navigation service asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task InitializeAsync() => 
        NavigateToAsync(
            string.IsNullOrEmpty(_settingsService.AuthAccessToken)
            ? "//Login"
            : "//Main/Catalog");
    
    
    /// <summary>
    /// Navigates to a specified route asynchronously.
    /// </summary>
    /// <param name="route">The route to navigate to.</param>
    /// <param name="routeParameters">Optional parameters for the route.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task NavigateToAsync(string route, IDictionary<string, object> routeParameters = null)
    {
        var shellNavigation = new ShellNavigationState(route);

        return routeParameters != null
            ? Shell.Current.GoToAsync(shellNavigation, routeParameters)
            : Shell.Current.GoToAsync(shellNavigation);
    }

    /// <summary>
    /// Pops the top page off the navigation stack asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task PopAsync() => Shell.Current.GoToAsync("..");
}
