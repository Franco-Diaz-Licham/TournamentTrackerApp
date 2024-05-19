namespace TrackerLibrary.Models;

public class TeamModel
{
    #region table cols
    public int Id { get; set; }
    public string TeamName { get; set; }
    #endregion

    #region related
    public List<PersonModel> TeamMembers { get; set; } = new();
    #endregion
}
