namespace TrackerLibrary;

public static class GlobalConfig
{
    public const string PrizesFile = "PrizeModel.csv";
    public const string PeopleFile = "PersonModel.csv";
    public const string TeamFile = "TeamModel.csv";
    public const string TournamentFile = "TournamentModels.csv";
    public const string MatchupFile = "MatchupModels.csv";
    public const string MatchupEntryFile = "MatchupEntryModels.csv";
    public static IDataConnection Connection {get; private set;}

    public static void InitializeConnection(
            DatabaseTypeEnum db)
    {
        if(db is DatabaseTypeEnum.Sql)
        {
            var cnx = CnnString("Tournaments");
            SqlConnector sql = new(cnx);
            Connection = sql;
        } 
        else if (db is DatabaseTypeEnum.TextFile)
        {
            TextConnector Text = new();
            Connection = Text;
        }
    }

    public static string CnnString(
            string name)
    {
        var cnx = ConfigurationManager.ConnectionStrings[name].ConnectionString;
        return cnx;
    }

    public static string AppKeyLookup(
            string key)
    {
        var value = ConfigurationManager.AppSettings.GetValues(key)!;
        return value.ToString()!;
    }
}
