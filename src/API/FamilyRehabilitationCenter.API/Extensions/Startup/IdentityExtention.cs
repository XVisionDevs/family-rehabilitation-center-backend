using FamilyRehabilitationCenter.Persistence;
using FamilyRehabilitationCenter.Persistence.Identity;
using Microsoft.AspNetCore.Identity;

namespace FamilyRehabilitationCenter.API.Extensions.Builder
{
    public static class IdentityExtention
    {
        public static void AddIdentity(IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole<int>>(options =>
            {
                options.Password.RequiredLength = 8;
            }).AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        }
    }
}
