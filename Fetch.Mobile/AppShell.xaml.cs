using Fetch.Mobile.Services;

namespace Fetch.Mobile
{
    public partial class AppShell : Shell
    {
        private readonly INavigationService _navigationService;
        public AppShell(INavigationService navigationService)
        {
            _navigationService = navigationService;

            AppShell.InitializeRouting();
            InitializeComponent();
        }

        private static void InitializeRouting()
        {
        }
    }
}
