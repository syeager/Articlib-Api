using Microsoft.Extensions.DependencyInjection;

namespace Articlib.Core.Infra.Logging;

public static class LogsConfiguration
{
    public static void AddLogs(this IServiceCollection services)
    {
        using var serviceProvider = services.BuildServiceProvider();
        Logs.DiagnosticContext = serviceProvider.GetRequiredService<IDiagnosticContext>();
    }
}
