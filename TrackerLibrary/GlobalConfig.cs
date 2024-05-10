namespace TrackerLibrary;

/// <summary>
/// its job is to write information to whataver data source you have chosen
/// </summary>
public static class GlobalConfig
{
    public const string PrizesFile = "PrizeModel.csv";
    public const string PeopleFile = "PersonModel.csv";
    public const string TeamFile = "TeamModel.csv";
    public const string TournamentFile = "TournamentModels.csv";
    public const string MatchupFile = "MatchupModels.csv";
    public const string MatchupEntryFile = "MatchupEntryModels.csv";

    /// <summary>
    /// creating a public static list of connections so that every part of the code can access it.
    /// This list will hold anything that implements the contract specifications
    /// </summary>
    public static IDataConnection Connection {get; private set;}

    /// <summary>
    /// intialise the connection
    /// </summary>
    /// <param name="database"> pass whether you want to connect to SQL server</param>
    /// <param name="texfiles"> pass whether you want to write to textFiles</param>
    public static void InitializeConnection(DatabaseType db)
    {
        // check if databse was the source chosen
        if(db == DatabaseType.Sql)
        {
            SqlConnector sql = new();
            Connection = sql;

        } else if (db == DatabaseType.TextFile)
        {
            TextConnector Text = new();
            Connection = Text;
        }
    }

    /// <summary>
    /// method to retrive the string found under app.config which will contain the information needed
    /// to connect to the SQL server and run the stored procedure.
    /// name is the tag in the XML app.config file.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static string CnnString(string name)
    {
        return ConfigurationManager.ConnectionStrings[name].ConnectionString;
    }

    public static string AppKeyLookup(string key)
    {
        return ConfigurationManager.AppSettings.GetValues(key).ToString();
    }
}
