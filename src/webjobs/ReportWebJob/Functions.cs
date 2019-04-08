namespace ReportWebJob
{
    using System.IO;
    using System.Data.SqlClient;
    using Microsoft.Azure.WebJobs;
    using Dapper;

    public class Functions
    {
        private readonly ISettings _settings;

        public Functions(ISettings settings)
        {
            _settings = settings;
        }

        // { "second" }, { "minute" }, { "hour" }, { "day" }, { "month" }, { "day-of-week" }
        public void ExecuteWithTimer([TimerTrigger("0/5 * * * * *", RunOnStartup = false)] TimerInfo timerInfo, TextWriter log)
        {
            log.WriteLine("Execution Started...");

            // Get Number of records in the database table
            log.WriteLine($"Total number of records : {GetRowTableCountFromDatabase()}");

            log.WriteLine("Execution Finished...");
        }

        private int GetRowTableCountFromDatabase()
        {
            var countSqlQuery = "SELECT COUNT(1) FROM ValuesTableCarrero";
            var count = 0;

            using (var connection = new SqlConnection(_settings.SqlServerDbConnectionString))
                count = connection.ExecuteScalar<int>(countSqlQuery);

            return count;
        }
    }
}