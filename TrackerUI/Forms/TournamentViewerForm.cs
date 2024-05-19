namespace TrackerUI;

public partial class TournamentViewerForm : Form
{
    private TournamentModel Tournament { get; set; }
    private List<int> Rounds { get; set; } = new();
    private List<MatchupModel> SelectedMatchups { get; set; } = new();

    public TournamentViewerForm(
            TournamentModel tournamentModel)
    {
        InitializeComponent();
        Tournament = tournamentModel;
        Tournament.OnTournamentComplete += Tournament_OnTournamentComplete;
        LoadFormData();
        LoadRounds();
    }

    private void Tournament_OnTournamentComplete(
            object sender, 
            DateTime e)
    {
        this.Close();
    }

    public void LoadFormData()
    {
        tournamentName.Text = Tournament.TournamentName;
    }

    private void WireUpRoundLists()
    {
        roundsDropDown.DataSource = null;
        roundsDropDown.DataSource = Rounds;
    }

    private void WireUpMatchupLists()
    {
        matchupListBox.DataSource = null;
        matchupListBox.DataSource = SelectedMatchups;
        matchupListBox.DisplayMember = "DisplayName";
    }

    private void LoadRounds()
    {
        Rounds = new(){1};
        int currRound = 1;

        foreach (List<MatchupModel> matchups in Tournament.Rounds)
        {
            if (matchups.First().MatchupRound > currRound)
            {
                currRound = matchups.First().MatchupRound;
                Rounds.Add(currRound);
            }
        }

        WireUpRoundLists();
        LoadMatchups();
    }

    private void LoadMatchups()
    {
        if (roundsDropDown.SelectedValue is null)
            return;

        int round = (int)roundsDropDown.SelectedValue;
        SelectedMatchups.Clear();

        foreach (List<MatchupModel> matchups in Tournament.Rounds)
            if (matchups.First().MatchupRound == round)
                foreach (MatchupModel Matchup in matchups)
                    if (Matchup.Winner == null || !unplayedOnlyCheckBox.Checked)
                        SelectedMatchups.Add(Matchup);

        WireUpMatchupLists();
        DisplayMatchupInfo();
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

    private void LoadMatchup(MatchupModel m)
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

    private void TournamentViewerForm_Load(
            object sender, 
            EventArgs e)
    {

    }

    private string IsValidData()
    {
        string output = "";
        bool isScoreOneValid = double.TryParse(teamOneScoreValue.Text, out var teamOneScore);
        bool isScoreTwoValid = double.TryParse(teamTwoScoreValue.Text, out var teamTwoScore);

        if (!isScoreOneValid)
            output = "Invalid team 1 score.";
        else if (!isScoreTwoValid)
            output = "Invalid team 2 score.";
        else if (teamOneScore == 0 && teamTwoScore == 0)
            output = "you did not enter a sore for teams 1 and 2.";
        else if (teamOneScore == teamTwoScore)
            output = "Ties not allowed in this application.";

        return output;
    }

    private void ScoreButton_Click(
            object sender, 
            EventArgs e)
    {
        if (IsValidData().Length > 0)
        {
            MessageBox.Show($"{IsValidData()}");
            return; 
        }

        // get values from form
        MatchupModel m = (MatchupModel)matchupListBox.SelectedItem;

        for (int i = 0; i < m.Entries.Count; i++)
        {
            if (i == 0)
            {
                if (m.Entries[i].TeamCompeting != null)
                {
                    bool isValid = double.TryParse(teamOneScoreValue.Text, out var teamOneScore);

                    if(isValid is false)
                    {
                        MessageBox.Show("Please enter a valid score for team 1.");
                        return;
                    }

                    m.Entries[0].Score = teamOneScore;
                }
            }

            if (i == 1)
            {
                if (m.Entries[i].TeamCompeting != null)
                {
                    bool isValid = double.TryParse(teamTwoScoreValue.Text, out var teamTwoScore);

                    if (isValid is false)
                    {
                        MessageBox.Show("Please enter a valid score for team 2.");
                        return;
                    }

                    m.Entries[1].Score = teamTwoScore;
                }
            }
        }

        try
        {
            TournamentLogic.UpdateTournamentResults(Tournament);
        }
        catch (Exception exc)
        {
            MessageBox.Show($"The application had an error: {exc.Message}");
            return;
        }

        LoadMatchups();
    }

    private void MatchupListBox_SelectedIndexChanged(
            object sender, 
            EventArgs e)
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
            WireUpMatchupLists();
            return;
        }

        LoadMatchup(m);
    }

    private void RoundsDropDown_SelectedIndexChanged(
            object sender, 
            EventArgs e)
    {
        LoadMatchups();
    }

    private void UnplayedOnlyCheckBox_CheckedChanged(
            object sender, 
            EventArgs e)
    {
        LoadMatchups();
    }
}