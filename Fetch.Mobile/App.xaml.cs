using Fetch.Mobile.Services;
using Fetch.Mobile.Services.Settings;

namespace Fetch.Mobile
{
    public partial class App : Application
    {
        private readonly ISettingsService _settingService;
        private readonly INavigationService _navigationService;
        public App(ISettingsService settingsService, INavigationService navigationService)
        {
            _settingService = settingsService;
            _navigationService = navigationService;

            InitializeComponent();

            MainPage = new AppShell(navigationService);
        }
    }
}
