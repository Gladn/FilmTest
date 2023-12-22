using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using FilmsTest.View;

namespace FilmsTest
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>().ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            }).UseMauiCommunityToolkit();
#if DEBUG
    		builder.Logging.AddDebug();
#endif
            //builder.Services.AddTransient<FilmDetailsPage>();
            return builder.Build();
        }
    }
}