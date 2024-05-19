namespace TrackerUI;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        var cnx = GlobalConfig.CnnString("Tournaments");
        GlobalConfig.InitializeConnection(DatabaseTypeEnum.Sql, cnx);
        Application.Run(new TournamentDashboardForm());
    }
}