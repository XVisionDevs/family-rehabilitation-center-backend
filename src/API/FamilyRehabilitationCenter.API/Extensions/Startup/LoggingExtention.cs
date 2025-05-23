using Serilog;

namespace FamilyRehabilitationCenter.API.Extensions.Startup
{
    public static class LoggingExtention
    {
        public static void UseLogging(WebApplicationBuilder builder)
        {
            builder.Host.UseSerilog((context, loggerConfig) =>
            loggerConfig.ReadFrom.Configuration(context.Configuration));
            var logConfiguration = new LoggerConfiguration();

            if (builder.Environment.IsDevelopment())
            {
                logConfiguration.WriteTo.Console();
            }

            Log.Logger = logConfiguration.CreateLogger();
        }
    }
}
