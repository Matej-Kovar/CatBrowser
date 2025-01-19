using CatBrowser.Service;
using CatBrowser.ViewModel;
using Microsoft.Extensions.Logging;

namespace CatBrowser
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<CatGetter>();

            builder.Services.AddSingleton<CatBrowserViewModel>();

            builder.Services.AddSingleton<MainPage>();
            return builder.Build();
        }
    }
}
