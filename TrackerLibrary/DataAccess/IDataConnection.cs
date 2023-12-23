namespace TrackerLibrary.DataAccess;

public interface IDataConnection
{
    void CreatePrize(PrizeModel model);
    void CreatePerson(PersonModel model);
    void CreateTeam(TeamModel model);
    void CreateTournament(TournamentModel model);
    void CompleteTournament(TournamentModel model);
    List<PersonModel> GetPerson_All();
    void UpdateMatchup(MatchupModel Matchup);
    List<TeamModel> GetTeam_All();
    List<TournamentModel> GetTournament_All();
    List<PrizeModel> GetPrize_All();
}
