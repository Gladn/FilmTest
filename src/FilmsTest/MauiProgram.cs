using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using FilmsTest.Service;
using FilmsTest.ViewModel;


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




            builder.Services.AddSingleton<MainSearchViewModel>();
            builder.Services.AddSingleton<MainPage>();

            builder.Services.AddScoped<IDatabaseService, DatabaseService>();
            builder.Services.AddScoped<IFilmsFilterService, FilmsFilterService>();
            //services.AddScoped<IDatabaseService, DatabaseService>();

            return builder.Build();
        }
    }
}