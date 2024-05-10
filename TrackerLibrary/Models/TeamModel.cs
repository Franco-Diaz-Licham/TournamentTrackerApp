
namespace TrackerLibrary.Models;

// making the class public, which is going to be access by any code within the main program
public class TeamModel
{
    /* declaring the property of list of persons, it needs to be initialised in C#. Before 6.0 version,
    strings were initialised by creation of method which would contain new List<Person>()*/

    /// <summary>
    /// the members of a team.
    /// </summary>
    public List<PersonModel> TeamMembers { get; set; } = new List<PersonModel>();

    /// <summary>
    /// the team Name.
    /// </summary>
    public string TeamName { get; set; }

    public int Id { get; set; }
}
