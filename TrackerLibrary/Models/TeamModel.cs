
namespace TrackerLibrary.Models;

public class TeamModel
{
    /// <summary>
    /// the members of a team.
    /// </summary>
    public List<PersonModel> TeamMembers { get; set; } = new();

    /// <summary>
    /// the team Name.
    /// </summary>
    public string TeamName { get; set; }

    public int Id { get; set; }
}
