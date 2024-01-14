using Consumidor;
using FiapTechChallenge.API.Core.Entity;
using FiapTechChallenge.Consumidor.Interfaces.Repository;
using FiapTechChallenge.Consumidor.Interfaces.Services;
using FiapTechChallenge.Consumidor.Repository;
using FiapTechChallenge.Consumidor.Services;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostingContext, config) =>
    {
        config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        config.AddEnvironmentVariables();
    })
    .ConfigureServices((hostContext, services) =>
    {
        services.Configure<AppSettings>(hostContext.Configuration.GetSection("AppSettings"));
        services.AddDbContext<ApplicationDbContext>(ServiceLifetime.Singleton);
        services.AddSingleton<ITransacaoRepository, TransacaoRepository>();
        services.AddSingleton<ITransacaoService, TransacaoService>();
        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();

