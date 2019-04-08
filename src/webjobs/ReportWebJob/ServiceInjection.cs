namespace ReportWebJob
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    internal static class ServiceInjection
    {
        public static void InjectServices(this IServiceCollection services, IConfigurationRoot configuration, ISettings settings)
        {
            AddSettings(services, settings);
            AddFunctions(services);
        }

        private static void AddSettings(IServiceCollection services, ISettings settings) => services.AddSingleton(provider => settings);

        private static void AddFunctions(IServiceCollection services) => services.AddTransient<Functions>();
    }
}