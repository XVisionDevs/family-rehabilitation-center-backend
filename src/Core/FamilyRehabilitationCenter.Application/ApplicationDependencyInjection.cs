using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FamilyRehabilitationCenter.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}
