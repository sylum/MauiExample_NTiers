using System.Reflection;
using Csla;
using Csla.Configuration;
using Microsoft.Extensions.Configuration;

namespace MauiExample;

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

    // Chargement de la configuration JSON
    var a = Assembly.GetExecutingAssembly();
    using var stream = a.GetManifestResourceStream("MauiExample.appsettings.json");
    var config = new ConfigurationBuilder().AddJsonStream(stream).Build();
    builder.Configuration.AddConfiguration(config);

    // Recupération du DataPortalUrl dans la configuration
    var providerConfig = builder.Services.BuildServiceProvider();
    var _configuration = providerConfig.GetService<IConfiguration>();
    App.AppSettings = _configuration.GetRequiredSection("AppSettings").Get<AppSettings>();

    builder.Services.AddTransient<HttpClient>();
    builder.Services.AddTransient<DataAccess.IPersonDal, DataAccess.PersonDal>();

    builder.Services.AddCsla(o => o
          .DataPortal(dp => dp
            .UseHttpProxy(hp => hp
              .DataPortalUrl = App.AppSettings.DataPortalUrl)));

    var provider = builder.Services.BuildServiceProvider();
    App.ApplicationContext = provider.GetRequiredService<ApplicationContext>();

    return builder.Build();
	}
}
