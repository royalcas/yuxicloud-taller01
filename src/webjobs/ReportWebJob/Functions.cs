namespace ReportWebJob
{
    using System.IO;
    using System.Data.SqlClient;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.Services.AppAuthentication;
    using Dapper;

    public class Functions
    {
        private readonly ISettings _settings;

        public Functions(ISettings settings)
        {
            _settings = settings;
        }

        // { "second" }, { "minute" }, { "hour" }, { "day" }, { "month" }, { "day-of-week" }
        public void ExecuteWithTimer([TimerTrigger("0/10 * * * * *", RunOnStartup = false)] TimerInfo timerInfo, TextWriter log)
        {
            log.WriteLine("Execution Started...");

            // Get Number of records in the database table
            //log.WriteLine($"Total number of records : {GetRowTableCountFromDatabase()}");

            log.WriteLine($"Total number of records : {GetRowTableCountFromDatabaseWithManagedIdentity()}");

            log.WriteLine("Execution Finished...");
        }

        private int GetRowTableCountFromDatabase()
        {
            const string countSqlQuery = "SELECT COUNT(1) FROM ValuesTableCarrero";
            int count;

            using (var connection = new SqlConnection(_settings.SqlServerDbConnectionString))
                count = connection.ExecuteScalar<int>(countSqlQuery);

            return count;
        }

        private int GetRowTableCountFromDatabaseWithManagedIdentity()
        {
            const string countSqlQuery = "SELECT COUNT(1) FROM ValuesTableCarrero";
            int count;

            using (var connection = new SqlConnection(_settings.SqlServerDbConnectionStringManaged))
            {
                connection.AccessToken = (new AzureServiceTokenProvider()).GetAccessTokenAsync("https://database.windows.net/").Result;

                count = connection.ExecuteScalar<int>(countSqlQuery);
            }

            return count;
        }
    }
}