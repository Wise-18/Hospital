using CommunityToolkit.Maui;
using Hospital.Application;
using Hospital.Persistence;
using Hospital.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Hospital.UI
{
    public static class MauiProgram
    {
        static string settingsStream = "Hospital.UI.appsettings.json";

        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream(settingsStream);
            builder.Configuration.AddJsonStream(stream);

            var connStr = builder.Configuration
                .GetConnectionString("SqliteConnection");

            string dataDirectory = FileSystem.Current.AppDataDirectory + "/";

            connStr = String.Format(connStr, dataDirectory);
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite(connStr)
                .Options;


            builder.Services
                .AddPersistence(options);

            DbInitializer
                .Initialize(builder.Services.BuildServiceProvider())
                .Wait();

            builder.Services.AddApplication();
            builder.Services.RegisterPages();
            builder.Services.RegisterViewModels();

            



#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }   
}
