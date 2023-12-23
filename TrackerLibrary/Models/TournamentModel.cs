
namespace TrackerLibrary.Models;

public class TournamentModel
{
    /// <summary>
    /// Name of the tournament.
    /// </summary>
    public string TournamentName { get; set; }

    /// <summary>
    /// The cost to enter the model
    /// </summary>
    public decimal EntryFee { get; set; }

    /// <summary>
    /// The list of teams that are part of a tournament
    /// </summary>
    public List<TeamModel> EnteredTeams { get; set; } = new List<TeamModel>();

    /// <summary>
    /// The list of all the prizes available for a tournament
    /// </summary>
    public List<PrizeModel> Prizes { get; set; } = new List<PrizeModel>();

    /// <summary>
    /// The list of all the lists of matchup. That is, the list of all the rounds
    /// witch every round being a list in itself.
    /// </summary>
    public List<List<MatchupModel>> Rounds { get; set; } = new List<List<MatchupModel>>();
    public int Id { get; set; }
    public bool Active { get; set; }

    public TournamentModel()
    { 
    }

    public TournamentModel(string tournamentName, string entryFee, List<TeamModel> teams, List<PrizeModel> prizes)
    {
        TournamentName = tournamentName;
        EntryFee = decimal.Parse(entryFee);
        EnteredTeams = teams;
        Prizes = prizes;
    }

    public event EventHandler<DateTime> OnTournamentComplete;

    public void HandleCompleteTournament()
    {
        OnTournamentComplete.Invoke(this, DateTime.Now);
    }
}
