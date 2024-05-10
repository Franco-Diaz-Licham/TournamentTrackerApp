
namespace TrackerLibrary.Models;

public class MatchupEntryModel
{
    /// <summary>
    /// Represents the teams in the matchup. Only one entry
    /// </summary>
    public TeamModel TeamCompeting { get; set; }
    /// <summary>
    /// Represents the score for this particular team.
    /// </summary>
    public double Score { get; set; }
    public int TeamCompetingId { get; set; }
    public int ParentMatchupId { get; set; }
    /// <summary>
    /// Represents the matchup that this team
    /// came from as the winner.
    /// </summary>
    public MatchupModel ParentMatchup { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int Id { get; set; }
}
