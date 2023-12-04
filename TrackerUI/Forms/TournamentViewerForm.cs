
namespace TrackerUI
{
    public partial class TournamentViewerForm : Form
    {
        private TournamentModel tournament;
        List<int> rounds = new();
        List<MatchupModel> SelectedMatchups = new();

        public TournamentViewerForm(TournamentModel tournamentModel)
        {
            InitializeComponent();
            tournament = tournamentModel;
            LoadFormData();
            loadRounds();
        }

        /// <summary>
        /// Method which calls other methods to hydrate form.
        /// </summary>
        public void LoadFormData()
        {
            tournamentName.Text = tournament.TournamentName;
        }

        /// <summary>
        /// Method which sets the value of the round dropdownlist.
        /// </summary>
        private void wireUpRoundLists()
        {
            roundsDropDown.DataSource = null;
            roundsDropDown.DataSource = rounds;
        }

        /// <summary>
        /// Method which sets the values of the matchup lists box.
        /// </summary>
        private void wireUpMatchupLists()
        {
            matchupListBox.DataSource = null;
            matchupListBox.DataSource = SelectedMatchups;
            matchupListBox.DisplayMember = "DisplayName";
        }

        /// <summary>
        /// Method to calculate the total number of rounds in the tournament.
        /// </summary>
        private void loadRounds()
        {
            rounds = new List<int>();

            rounds.Add(1);
            int currRound = 1;

            foreach (List<MatchupModel> matchups in tournament.Rounds)
            {
                if (matchups.First().MatchupRound > currRound)
                {
                    currRound = matchups.First().MatchupRound;
                    rounds.Add(currRound);
                    currRound += 1;
                }
            }

            wireUpRoundLists();
        }

        private void loadMatchups()
        {
            if (roundsDropDown.SelectedValue != null)
            {
                int round = (int)roundsDropDown.SelectedValue;
                SelectedMatchups.Clear();

                foreach (List<MatchupModel> matchups in tournament.Rounds)
                {
                    if (matchups.First().MatchupRound == round)
                    {
                        foreach(MatchupModel Matchup in matchups)
                        {
                            if(Matchup.Winner == null || !unplayedOnlyCheckBox.Checked)
                            {
                                SelectedMatchups.Add(Matchup);
                            }
                        }
                    }
                }

                wireUpMatchupLists();
                DisplayMatchupInfo();
            }
        }

        private void DisplayMatchupInfo()
        {
            bool isVisible = (SelectedMatchups.Count > 0);

            teamOneLabel.Visible = isVisible;
            TeamOneScoreLabel.Visible = isVisible;
            teamOneScoreValue.Visible = isVisible;
            teamTwoLabel.Visible = isVisible;
            TeamTwoScoreLabel.Visible = isVisible;
            teamTwoScoreValue.Visible = isVisible;
            versusLabel.Visible = isVisible;
            scoreButton.Visible = isVisible;
        }

        private void loadMatchup(MatchupModel m)
        {
            for (int i = 0; i < m.Entries.Count; i++)
            {
                if (i == 0)
                {
                    if (m.Entries[i].TeamCompeting != null)
                    {
                        teamOneLabel.Text = m.Entries[0].TeamCompeting.TeamName;
                        teamOneScoreValue.Text = m.Entries[0].Score.ToString();

                        teamTwoLabel.Text = "<bye>";
                        teamTwoScoreValue.Text = "0";
                    }
                    else
                    {
                        teamOneLabel.Text = "Not yet set.";
                        teamOneScoreValue.Text = "0";
                    }
                }

                if (i == 1)
                {
                    if (m.Entries[i].TeamCompeting != null)
                    {
                        teamTwoLabel.Text = m.Entries[1].TeamCompeting.TeamName;
                        teamTwoScoreValue.Text = m.Entries[1].Score.ToString();
                    }
                    else
                    {
                        teamTwoLabel.Text = "Not yet set.";
                        teamTwoScoreValue.Text = "0";
                    }
                }
            }
        }

        private void TournamentViewerForm_Load(object sender, EventArgs e)
        {

        }

        private string IsValidData()
        {
            string output = "";

            double teamOneScore = 0;
            double teamTwoScore = 0;

            bool isScoreOneValid = double.TryParse(teamOneScoreValue.Text, out teamOneScore);
            bool isScoreTwoValid = double.TryParse(teamTwoScoreValue.Text, out teamTwoScore);

            if (!isScoreOneValid)
            {
                output = "Invalid team 1 score.";
            }
            else if (!isScoreTwoValid)
            {
                output = "Invalid team 2 score.";
            }
            else if (teamOneScore == 0 && teamTwoScore == 0)
            {
                output = "you did not enter a sore for teams 1 and 2.";
            }
            else if (teamOneScore == teamTwoScore)
            {
                output = "Ties not allowed in this application.";
            }

            return output;
        }

        private void scoreButton_Click(object sender, EventArgs e)
        {
            if (IsValidData().Length > 0)
            {
                MessageBox.Show($"{IsValidData()}");
                return; 
            }

            // get values from form
            MatchupModel m = (MatchupModel)matchupListBox.SelectedItem;
            double teamOneScore = 0;
            double teamTwoScore = 0;

            for (int i = 0; i < m.Entries.Count; i++)
            {
                if (i == 0)
                {
                    if (m.Entries[i].TeamCompeting != null)
                    {
                        bool isValid = double.TryParse(teamOneScoreValue.Text, out teamOneScore);

                        if(isValid)
                        {
                            m.Entries[0].Score = teamOneScore;
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid score for team 1.");
                            return;
                        }

                    }
                }

                if (i == 1)
                {
                    if (m.Entries[i].TeamCompeting != null)
                    {
                        bool isValid = double.TryParse(teamTwoScoreValue.Text, out teamTwoScore);

                        if (isValid)
                        {
                            m.Entries[1].Score = teamTwoScore;
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid score for team 2.");
                            return;
                        }

                    }
                }
            }

            try
            {
                TournamentLogic.UpdateTournamentResults(tournament);
            }
            catch(Exception exc)
            {
                MessageBox.Show($"The application had an error: {exc.Message}");
                return;
            }

            loadMatchups();
        }

        private void matchupListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MatchupModel selectedValue = (MatchupModel)matchupListBox.SelectedItem;
            MatchupModel m;

            if (selectedValue != null)
            {
                m = selectedValue;
            }
            else if (SelectedMatchups.Count > 0)
            {
                m = SelectedMatchups.First();
            }
            else
            {
                wireUpMatchupLists();
                return;
            }

            loadMatchup(m);
        }

        private void roundsDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadMatchups();
        }

        private void unplayedOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            loadMatchups();
        }
    }
}