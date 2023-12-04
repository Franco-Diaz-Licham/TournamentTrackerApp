
namespace TrackerUI
{
    public partial class CreateTournamentForm : Form, IPrizeRequester, ITeamRequester
    {
        private List<TeamModel> availableTeams { get; set; } = GlobalConfig.Connection.GetTeam_All();
        private List<TeamModel> selectedTeams { get; set; } = new List<TeamModel>();
        private List<PrizeModel> selectedPrizes { get; set; } = new List<PrizeModel>();

        ITournamentRequester calling;

        public CreateTournamentForm(ITournamentRequester caller)
        {
            InitializeComponent();
            calling = caller;
            WiredUpLists();
        }

        public void WiredUpLists()
        {
            selectTeamDropDown.DataSource = null;
            selectTeamDropDown.DataSource = availableTeams;
            selectTeamDropDown.DisplayMember = "TeamName";

            tournamentTeamsListBox.DataSource = null;
            tournamentTeamsListBox.DataSource = selectedTeams;
            tournamentTeamsListBox.DisplayMember = "TeamName";

            prizesListBox.DataSource = null;
            prizesListBox.DataSource = selectedPrizes;
            prizesListBox.DisplayMember = "PlaceName";
        }

        private void addTeamButton_Click(object sender, EventArgs e)
        {
            if (selectTeamDropDown.SelectedItem != null)
            {
                TeamModel t = (TeamModel)selectTeamDropDown.SelectedItem;
                availableTeams.Remove(t);
                selectedTeams.Add(t);
                WiredUpLists();
            }
        }

        private void removeSelectedTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel t = (TeamModel)tournamentTeamsListBox.SelectedItem;
            if (t != null)
            {
                availableTeams.Add(t);
                selectedTeams.Remove(t);
                WiredUpLists();
            }
        }

        private void createTournamentButton_Click(object sender, EventArgs e)
        {
            if (ValidateTournamentForm())
            {
                // create tournament model
                TournamentModel tm = new TournamentModel();
                tm.TournamentName = TournamentNameValue.Text;
                tm.EntryFee = decimal.Parse(EntryFeeValue.Text);
                tm.EnteredTeams = selectedTeams;
                tm.Prizes = selectedPrizes;

                TournamentLogic.CreateRounds(tm);

                // create tournament
                // save all Prizes
                // save all team entries
                GlobalConfig.Connection.CreateTournament(tm);

                tm.AlertUsersToNewRound();

                calling.TournamentComplete(tm);
                this.Close();
            }
            else
            {
                MessageBox.Show("You need to enter a valid form.",
                    "Invalid Form",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public bool ValidateTournamentForm()
        {
            decimal fee = 0;
            bool output = true;
            bool feeValid = decimal.TryParse(EntryFeeValue.Text, out fee);

            if (TournamentNameValue.Text.Length == 0)
            {
                output = false;
            }

            if (tournamentTeamsListBox.Items.Count == 0)
            {
                output = false;
            }

            if (prizesListBox.Items.Count == 0)
            {
                output = false;
            }

            if (feeValid == false)
            {
                output = false;
            }

            return output;
        }

        private void RemoveSelectedPrizeButton_Click(object sender, EventArgs e)
        {
            PrizeModel p = (PrizeModel)prizesListBox.SelectedItem;
            if (prizesListBox.SelectedItem != null)
            {
                selectedPrizes.Remove(p);
                WiredUpLists();
            }
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            // call the CreatePrizeform
            CreatePrizeForm frm = new CreatePrizeForm(this);
            frm.Show();
        }

        public void PrizeComplete(PrizeModel model)
        {
            // Get back from the PrizeModel
            // populate the prizeList
            selectedPrizes.Add(model);
            WiredUpLists();
        }

        private void CreateNewTeamLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateTeamForm frm = new CreateTeamForm(this);
            frm.Show();
        }

        public void TeamComplete(TeamModel model)
        {
            selectedTeams.Add(model);
            WiredUpLists();
        }
    }
}
