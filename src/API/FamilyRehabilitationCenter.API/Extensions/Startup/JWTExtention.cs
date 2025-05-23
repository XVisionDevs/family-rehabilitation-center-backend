using FamilyRehabilitationCenter.API.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FamilyRehabilitationCenter.API.Extensions.Builder
{
    public static class JWTExtention
    {
        public static void AddJWT(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JWTSettings>(configuration.GetSection("JwtSettings"));

            var jwtSettings = configuration.GetSection("JwtSettings").Get<JWTSettings>();
            var key = Encoding.UTF8.GetBytes(jwtSettings.Secret);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
                    ValidateIssuer = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidateAudience = true,
                    ValidAudiences = jwtSettings.Audiences,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
    }
}
