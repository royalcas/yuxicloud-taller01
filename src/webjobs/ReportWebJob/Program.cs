namespace ReportWebJob
{
    using System;
    using System.IO;
    using System.Reflection;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Azure.WebJobs;
    internal class Program
    {
        private const string EnvironmentConfigurationVariable = "ASPNETCORE_ENVIRONMENT";

        private static void Main(string[] args)
        {
            var configuration = GetWebJobConfiguration();

            var settings = new Settings(configuration);

            var servicesProvider = ServiceConfiguration.ConfigureServices(configuration, settings);

            var config = new JobHostConfiguration
            {
                JobActivator = new JobDependenciesActivator(servicesProvider)
            };

            config.UseTimers();

            var host = new JobHost(config);

            Console.WriteLine("Web-Job Running");

            host.RunAndBlock();
        }
        private static IConfigurationRoot GetWebJobConfiguration()
        {
            var environmentName = Environment.GetEnvironmentVariable(EnvironmentConfigurationVariable);

            Directory.SetCurrentDirectory(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
            var configuration = new ConfigurationBuilder()
                .SetBasePath(new DirectoryInfo(".").FullName)
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables()
                .Build();

            PrintEnvironmentConfiguration(environmentName);

            return configuration;
        }

        private static void PrintEnvironmentConfiguration(string environmentName)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($@"Environment : {environmentName}, using configuration file : appsettings.json");

            Console.ResetColor();
        }
    }
}