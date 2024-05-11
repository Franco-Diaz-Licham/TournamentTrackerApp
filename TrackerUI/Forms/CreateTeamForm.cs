namespace TrackerUI;

public partial class CreateTeamForm : Form
{
    private List<PersonModel> AvailableTeamMembers { get; set; } = GlobalConfig.Connection.GetPerson_All();
    private List<PersonModel> SelectedTeamMembers { get; set; } = new();
    private ITeamRequester CallingForm { get; set; }

    public CreateTeamForm(
            ITeamRequester caller)
    {
        InitializeComponent();
        CallingForm = caller;
        WiredUpLists();
    }

    private void WiredUpLists()
    {
        selectTeamMemberDropDown.DataSource = null;
        selectTeamMemberDropDown.DataSource = AvailableTeamMembers;
        selectTeamMemberDropDown.DisplayMember = "FullName";

        teamMembersListBox.DataSource = null;
        teamMembersListBox.DataSource = SelectedTeamMembers;
        teamMembersListBox.DisplayMember = "FullName";
    }

    private void CreateTeamButton_Click(
            object sender, 
            EventArgs e)
    {
        if (ValidateCreateTeamForm() is false)
            return;

        TeamModel team = new()
        {
            TeamName = teamNameValue.Text,
            TeamMembers = SelectedTeamMembers
        };

        GlobalConfig.Connection.CreateTeam(team);
        CallingForm.TeamComplete(team);

        this.Close();
    }

    private void CreateMemberButton_Click(
            object sender, 
            EventArgs e)
    {
        if (ValidateAddPersonForm() is false)
        {
            MessageBox.Show("This is not a valid Form, please check and try again.");
            return;
        }

        PersonModel p = new()
        {
            FirstName = firstNameValue.Text,
            LastName = lastNameValue.Text,
            EmailAddress = emailLabel.Text,
            CellphoneNumber = cellPhoneValue.Text
        };

        GlobalConfig.Connection.CreatePerson(p);
        SelectedTeamMembers.Add(p);
        WiredUpLists();

        // clear the entries of the form
        firstNameValue.Text = "";
        lastNameValue.Text = "";
        emailValue.Text = "";
        cellPhoneValue.Text = "";
    }

    private bool ValidateAddPersonForm()
    {
        // define variables
        bool output = true;
        string firstName = firstNameValue.Text;
        string lastName = lastNameValue.Text;
        string email = emailValue.Text;
        string phoneNumber = cellPhoneValue.Text;

        // check validation conditions
        if (firstName.Length == 0)
            output = false;
        if (lastName.Length == 0)
            output = false;
        if (email.Length == 0 && email.Contains("@"))
            output = false;
        if (phoneNumber.Length == 0)
            output = false;

        return output;
    }

    private bool ValidateCreateTeamForm() 
    {
        bool output = true;
        string teamName = teamNameValue.Text;

        if (teamName.Length == 0)
            output = false;

        return output;
    }

    private void AddMemberButton_Click(
            object sender, 
            EventArgs e)
    {
        if (selectTeamMemberDropDown.SelectedItem is null)
            return;

        PersonModel p = (PersonModel)selectTeamMemberDropDown.SelectedItem;
        AvailableTeamMembers.Remove(p);
        SelectedTeamMembers.Add(p);
        WiredUpLists();
    }

    private void RemoveSelectedMemberButton_Click(
            object sender, 
            EventArgs e)
    {
        if (teamMembersListBox.SelectedItem is null)
            return ;

        PersonModel p = (PersonModel)teamMembersListBox.SelectedItem;
        SelectedTeamMembers.Remove(p);
        AvailableTeamMembers.Add(p);
        WiredUpLists();
    }
}
