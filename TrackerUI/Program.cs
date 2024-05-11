namespace TrackerUI;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        GlobalConfig.InitializeConnection(DatabaseTypeEnum.Sql);
        Application.Run(new TournamentDashboardForm());
    }
}