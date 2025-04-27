using Microsoft.Extensions.Logging;
using MauiApp2.Services;

namespace MauiApp2
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

            builder.Services.AddDbContext<MySqlDbContext>();
            builder.Services.AddTransient<DatabaseService>();
            builder.ConfigureMauiHandlers(handlers =>
            {
#if ANDROID
                Microsoft.Maui.Handlers.ImageHandler.Mapper.AppendToMapping("Splash", (handler, view) =>
                {
                    // Здесь можно настроить логику обработки сплэш-скрина
                });
#endif
            });


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
