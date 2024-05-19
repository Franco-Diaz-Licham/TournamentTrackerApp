
namespace TrackerLibrary.Models;

public class PersonModel
{
    #region table cols
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string CellphoneNumber { get; set; }
    #endregion

    #region helpers
    public string FullName 
    { 
        get
        {
            return $"{FirstName} {LastName}";
        }
     }
    #endregion

    #region contructors
    public PersonModel() { }

    public PersonModel(
            string firstName, 
            string lastName, 
            string email, 
            string phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = email;
        CellphoneNumber = phoneNumber;
    }
    #endregion
}
