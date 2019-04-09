namespace ReportWebJob
{
    using Microsoft.Extensions.Configuration;

    internal class Settings : ISettings
    {
        private readonly IConfiguration _configuration;

        public Settings(IConfiguration configuration) => _configuration = configuration;

        public string SqlServerDbConnectionString => GetEntry("ConnectionStrings", "SQLServerConnection");

        public string SqlServerDbConnectionStringManaged => GetEntry("ConnectionStrings", "SQLServerConnectionManaged");

        private string GetEntry(string configurationRoot, string configurationKey) => _configuration[$"{configurationRoot}:{configurationKey}"];
    }
}
