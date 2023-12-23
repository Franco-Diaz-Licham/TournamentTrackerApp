
namespace TrackerUI;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        // Initialise the database connection
        GlobalConfig.InitializeConnection(DatabaseType.Sql);

        // run application
        Application.Run(new TournamentDashboardForm());
    }
}