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
        services.Configure<IISOptions>(options =>
        {

        });
}