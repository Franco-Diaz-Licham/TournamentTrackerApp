namespace TrackerLibrary.Models;

public class TournamentModel
{
    #region table cols
    public int Id { get; set; }
    public bool Active { get; set; }
    public string TournamentName { get; set; }
    public decimal EntryFee { get; set; }
    public List<TeamModel> EnteredTeams { get; set; } = new();
    public List<PrizeModel> Prizes { get; set; } = new();
    #endregion

    #region related
    /// <summary>
    /// The list of all the lists of matchup. That is, the list of all the rounds
    /// witch every round being a list in itself.
    /// </summary>
    public List<List<MatchupModel>> Rounds { get; set; } = new();
    #endregion

    #region constructors
    public TournamentModel() { }

    public TournamentModel(
            string tournamentName,
            string entryFee,
            List<TeamModel> teams,
            List<PrizeModel> prizes)
    {
        TournamentName = tournamentName;
        EntryFee = decimal.Parse(entryFee);
        EnteredTeams = teams;
        Prizes = prizes;
    }
    #endregion

    #region events
    public event EventHandler<DateTime> OnTournamentComplete;

    public void HandleCompleteTournament()
    {
        OnTournamentComplete.Invoke(this, DateTime.Now);
    }
    #endregion
}
