namespace TrackerLibrary.Models;

public class MatchupEntryModel
{
    public int Id { get; set; }
    public double Score { get; set; }
    public int TeamCompetingId { get; set; }
    public TeamModel TeamCompeting { get; set; }
    /// <summary>
    /// Represents the matchup that this team
    /// came from as the winner.
    /// </summary>
    public int ParentMatchupId { get; set; }
    public MatchupModel ParentMatchup { get; set; }
}
