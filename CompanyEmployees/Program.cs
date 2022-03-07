using CompanyEmployees.Extensions;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureCors()
    .ConfigureIssIntegration()
    .ConfigureLoggerService(builder.Environment)
    .ConfigureSqlContext(builder.Configuration)
    .ConfigureRepositoryManager()
    .ConfigureServiceManager()
    .AddAutoMapper(typeof(Program))
    .AddControllers()
    .AddApplicationPart(typeof(CompanyEmployees.Presentation.AssemblyReference).Assembly).Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});
app.UseCors("CorsPolicy");
app.UseAuthorization();
app.MapControllers();
app.Run();