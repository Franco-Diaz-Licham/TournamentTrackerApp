
namespace TrackerLibrary.Models;

public class MatchupModel
{
    #region table cols
    public int Id { get; set; }
    /// <summary>
    /// Represents the curren round for the matchups
    /// </summary>
    public int MatchupRound { get; set; }
    public int WinnerId { get; set; }
    public TeamModel Winner { get; set; }
    #endregion

    #region related
    /// <summary>
    /// list of all the matchups for all rounds. That is, every MatchupEntry will have team vs team 
    /// for a given round and this List of MatchupEntries will contain all those matchups for all the other teams for
    /// a given round
    /// </summary>
    public List<MatchupEntryModel> Entries { get; set; } = new();
    #endregion

    #region helpers
    public string DisplayName 
    {
        get
        {
            string name = "";

            foreach(MatchupEntryModel entry in Entries)
            {
                if(entry.TeamCompeting != null)
                {
                    if (name.Length == 0)
                        name = entry.TeamCompeting.TeamName;
                    else
                        name += $" vs. {entry.TeamCompeting.TeamName}";
                }
                else
                {
                    name = "Matchup not yet determined.";
                    break;
                }
            }

            return name;
        }
    }
    #endregion
}
