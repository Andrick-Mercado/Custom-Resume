﻿using CustomResume.Library;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;

namespace CustomResume.Maui
{
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
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddMudServices();
            builder.Services.AddCustomResumeMauiServices();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
            //builder.Logging.SetMinimumLevel(LogLevel.Debug);
#endif

            return builder.Build();
        }
    }
}
