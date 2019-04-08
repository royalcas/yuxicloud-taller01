namespace ReportWebJob
{
    using System;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    internal static class ServiceConfiguration
    {
        public static IServiceProvider ConfigureServices(IConfigurationRoot configuration, ISettings settings)
        {
            IServiceCollection services = new ServiceCollection();

            AddWebJobsCommonServices(configuration);

            services.InjectServices(configuration, settings);

            return services.BuildServiceProvider();
        }

        private static void AddWebJobsCommonServices(IConfiguration configuration)
        {
            if (!string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("AzureWebJobsStorage")))
                return;
            Environment.SetEnvironmentVariable("AzureWebJobsStorage", configuration.GetConnectionString("AzureWebJobsStorage"));
            Environment.SetEnvironmentVariable("AzureWebJobsDashboard", configuration.GetConnectionString("AzureWebJobsDashboard"));
        }
    }
}
