using Fetch.Mobile.Services;
using Fetch.Mobile.Services.Settings;
using Fetch.Mobile.Views;

using Microsoft.Extensions.Logging;

namespace Fetch.Mobile;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .RegisterAppServices()
            .Build();



        return builder.Build();
    }

    public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder app)
    {
        app.Services.AddSingleton<ISettingsService, SettingsServices>();
        app.Services.AddSingleton<INavigationService, MauiNavigationService>();

#if DEBUG
        app.Logging.AddDebug();
#endif
        return app;
    }

    public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddTransient<LoginView>();

        return mauiAppBuilder;
    }
}
