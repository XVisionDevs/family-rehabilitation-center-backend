using FamilyRehabilitationCenter.API.Extensions.Builder;
using FamilyRehabilitationCenter.API.Extensions.Startup;
using FamilyRehabilitationCenter.API.Middleware;
using FamilyRehabilitationCenter.Application;
using FamilyRehabilitationCenter.Infrastructure;
using FamilyRehabilitationCenter.Persistence;

namespace FamilyRehabilitationCenter.API
{
    public class Startup
    {
        private readonly IConfigurationRoot _configuration;

        public Startup(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureBuilder(WebApplicationBuilder builder)
        {
            LoggingExtention.UseLogging(builder);
            AzureKeyVaultExtention.UseAzureKeyVault(builder);
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddProblemDetails();
            IdentityExtention.AddIdentity(services);
            JWTExtention.AddJWT(services, _configuration);
            services.AddAuthorization();


            services.AddPersistence(_configuration)
                    .AddInfrastructure(_configuration)
                    .AddApplication(_configuration);
        }
        public void Configure(WebApplication app)
        {

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseForwardedHeaders();

            app.UseExceptionHandler();
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
