using FamilyRehabilitationCenter.Application.Contracts.Persistence.UoW;
using FamilyRehabilitationCenter.Persistence.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FamilyRehabilitationCenter.Persistence
{
    public static class PersistenceDependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("ConnectionStrings:DefaultConnection")));


            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
