using Fetch.Mobile.Services;
using Fetch.Mobile.Views;

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
            Routing.RegisterRoute("CommandView", typeof(CommandView));
        }
    }
}
