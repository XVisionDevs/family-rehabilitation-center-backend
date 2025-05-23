using Azure.Identity;

namespace FamilyRehabilitationCenter.API.Extensions.Startup
{
    public class AzureKeyVaultExtention
    {
        public static void UseAzureKeyVault(WebApplicationBuilder builder)
        {
            var vaultName = builder.Configuration["KeyVault:VaultName"];
            var vaultUri = new Uri($"https://{vaultName}.vault.azure.net/");

            builder.Configuration.AddAzureKeyVault(vaultUri, new DefaultAzureCredential()
            );
        }
    }
}
