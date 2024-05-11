namespace TrackerUI;

public partial class CreateTournamentForm : Form, IPrizeRequester, ITeamRequester
{
    private List<TeamModel> AvailableTeams { get; set; } = GlobalConfig.Connection.GetTeam_All();
    private List<TeamModel> SelectedTeams { get; set; } = new List<TeamModel>();
    private List<PrizeModel> SelectedPrizes { get; set; } = new List<PrizeModel>();
    private ITournamentRequester Calling { get; set; }

    public CreateTournamentForm(
            ITournamentRequester caller)
    {
        InitializeComponent();
        Calling = caller;
        WiredUpLists();
    }

    public void WiredUpLists()
    {
        selectTeamDropDown.DataSource = null;
        selectTeamDropDown.DataSource = AvailableTeams;
        selectTeamDropDown.DisplayMember = "TeamName";

        tournamentTeamsListBox.DataSource = null;
        tournamentTeamsListBox.DataSource = SelectedTeams;
        tournamentTeamsListBox.DisplayMember = "TeamName";

        prizesListBox.DataSource = null;
        prizesListBox.DataSource = SelectedPrizes;
        prizesListBox.DisplayMember = "PlaceName";
    }

    private void AddTeamButton_Click(
            object sender, 
            EventArgs e)
    {
        if (selectTeamDropDown.SelectedItem is null)
            return;

        TeamModel t = (TeamModel)selectTeamDropDown.SelectedItem;
        AvailableTeams.Remove(t);
        SelectedTeams.Add(t);
        WiredUpLists();
    }

    private void RemoveSelectedTeamButton_Click(
            object sender, 
            EventArgs e)
    {
        TeamModel t = (TeamModel)tournamentTeamsListBox.SelectedItem;

        if (t is null)
            return;

        AvailableTeams.Add(t);
        SelectedTeams.Remove(t);
        WiredUpLists();
    }

    private void CreateTournamentButton_Click(
            object sender, 
            EventArgs e)
    {
        if (ValidateTournamentForm() is false)
        {
            MessageBox.Show("You need to enter a valid form.",
                            "Invalid Form",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            return;
        }

        // create tournament model
        TournamentModel tm = new();
        tm.TournamentName = TournamentNameValue.Text;
        tm.EntryFee = decimal.Parse(EntryFeeValue.Text);
        tm.EnteredTeams = SelectedTeams;
        tm.Prizes = SelectedPrizes;

        TournamentLogic.CreateRounds(tm);

        // create tournament
        // save all Prizes
        // save all team entries
        GlobalConfig.Connection.CreateTournament(tm);
        tm.AlertUsersToNewRound();
        Calling.TournamentComplete(tm);

        this.Close();
    }

    public bool ValidateTournamentForm()
    {
        bool output = true;
        bool feeValid = decimal.TryParse(EntryFeeValue.Text, out var fee);

        if (TournamentNameValue.Text.Length == 0)
            output = false;
        if (tournamentTeamsListBox.Items.Count == 0)
            output = false;
        if (prizesListBox.Items.Count == 0)
            output = false;
        if (feeValid == false)
            output = false;

        return output;
    }

    private void RemoveSelectedPrizeButton_Click(
            object sender, 
            EventArgs e)
    {
        PrizeModel p = (PrizeModel)prizesListBox.SelectedItem;

        if (prizesListBox.SelectedItem is null)
            return;

        SelectedPrizes.Remove(p);
        WiredUpLists();
    }

    private void CreatePrizeButton_Click(
            object sender, 
            EventArgs e)
    {
        CreatePrizeForm frm = new(this);
        frm.Show();
    }

    public void PrizeComplete(
            PrizeModel model)
    {
        SelectedPrizes.Add(model);
        WiredUpLists();
    }

    private void CreateNewTeamLink_LinkClicked(
            object sender, 
            LinkLabelLinkClickedEventArgs e)
    {
        CreateTeamForm frm = new(this);
        frm.Show();
    }

    public void TeamComplete(
            TeamModel model)
    {
        SelectedTeams.Add(model);
        WiredUpLists();
    }
}
