using FiapTechChallenge.API;
using FiapTechChallenge.API.Logging;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .ConfigureLogging((context, builder) =>
            {
                builder.ClearProviders(); // Limpar os provedores de log padrão
                builder.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration()
                {
                    LogLevel = LogLevel.Information
                }));
            });
}


