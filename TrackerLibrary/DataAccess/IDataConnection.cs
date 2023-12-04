
namespace TrackerLibrary.DataAccess
{
    /// <summary>
    /// this is a public interface object it's only job is to specify what methods must be implemented 
    /// acrross the different datasource connectors. This is not a place to specify the logic (i.e. code) 
    /// to write to the data sources. You do that within the individual datasourceConnector Classes
    /// e.g. the SqlConnector class. However, having a contract will allow the other connector classes 
    /// to be updated if anything changes this way, you do not have to update every class and try to 
    /// remember what contract speicfications are required for the writing to the datasource to work
    /// </summary>
    public interface IDataConnection
    {
        void CreatePrize(PrizeModel model);
        void CreatePerson(PersonModel model);
        void CreateTeam(TeamModel model);
        void CreateTournament(TournamentModel model);
        List<PersonModel> GetPerson_All();
        void UpdateMatchup(MatchupModel Matchup);
        List<TeamModel> GetTeam_All();
        List<TournamentModel> GetTournament_All();
        List<PrizeModel> GetPrize_All();
    }
}
