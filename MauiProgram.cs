﻿using Fetch.Pages;
using Fetch.Shared;
using Fetch.ViewModels;
using Grpc.Net.Client;
using Microsoft.Extensions.Logging;

namespace Fetch
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            string BaseAddress = "https://localhost:7290";
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .UseMauiMaps();

            var services = builder.Services;
#if DEBUG
    		builder.Logging.AddDebug();
#endif
            services.AddSingleton(services =>
            {

                var baseUri = new Uri(BaseAddress);
                var channel = GrpcChannel.ForAddress(baseUri);
                return new Greeter.GreeterClient(channel);
            });

            services.AddSingleton<HomePage>();
            services.AddSingleton<SandwichPage>();
            services.AddSingleton<SandwichViewModel>();

            services.AddSingleton<GreetingPage>();
            services.AddSingleton<GreeterViewModel>();

            return builder.Build();
        }
    }
}