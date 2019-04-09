namespace ReportWebJob
{
    public interface ISettings
    {
        string SqlServerDbConnectionString { get; }
        string SqlServerDbConnectionStringManaged { get; }
    }
}
