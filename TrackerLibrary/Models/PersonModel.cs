
namespace TrackerLibrary.Models
{
    public class PersonModel
    {
        /// <summary>
        /// The team member's firstname
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The team member's lastname
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The team member's Email Address to contact
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// the team member's Cellphone Number
        /// </summary>
        public string CellphoneNumber { get; set; }

        // 1. Validate the Form
        // 2. Initialise the Object
        // 3. CreatePerson Method under the SQL connector

        /// <summary>
        /// a tem member internal Id
        /// </summary>
        public int Id { get; set; }

        public string FullName 
        { get
            {
                return $"{FirstName} {LastName}";
            }
         }

        // important to define an empty method so that we are also able
        // to initialise an object without all the information needed as stated below
        public PersonModel() 
        { 
        }

        /// <summary>
        /// Person object to contain information from member
        /// </summary>
        /// <param name="firstName"> first name of person</param>
        /// <param name="lastName"> last name of person</param>
        /// <param name="email"> email of person</param>
        /// <param name="phoneNumber"> phone number of person</param>
        public PersonModel(string firstName, string lastName, string email, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = email;
            CellphoneNumber = phoneNumber;
        }

    }



}
