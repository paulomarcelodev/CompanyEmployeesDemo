using Contracts;
using LoggerService;
using NLog;
using Repository;
using Service;
using Service.Contracts;

namespace CompanyEmployees.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });
    public static IServiceCollection ConfigureIssIntegration(this IServiceCollection services) =>
        services.Configure<IISOptions>(options => { });
    public static IServiceCollection ConfigureLoggerService(this IServiceCollection services, IWebHostEnvironment environment)
    {
        LogManager.LoadConfiguration(
            string.Concat(Directory.GetCurrentDirectory(),
                $"/nlog.{environment.EnvironmentName.ToLower()}.config")
        );
        return services.AddSingleton<ILoggerManager, LoggerManager>();
    }
    public static IServiceCollection ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();
    public static IServiceCollection ConfigureServiceManager(this IServiceCollection services) =>
        services.AddScoped<IServiceManager, ServiceManager>();
}