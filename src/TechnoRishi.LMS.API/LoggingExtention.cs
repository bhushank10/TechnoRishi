using Serilog;

namespace TechnoRishi.LMS.Framework;

public static class LoggingExtention
{
    public static void AddLogging(this WebApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration()
                    .WriteTo.Console()
                    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
                    .Enrich.FromLogContext()
                    .MinimumLevel.Information()
                    .CreateLogger();
        builder.Host.UseSerilog();
    }
}