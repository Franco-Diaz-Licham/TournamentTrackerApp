namespace TrackerWPFUI.ViewModels;

public class TournamentViewerViewModel : Screen
{
    public TournamentViewerViewModel(
            TournamentModel model)
    {
        Tournament = model;
        TournamentName = model.TournamentName;
        Matchups = new BindableCollection<MatchupModel>(model.Rounds.First());
        LoadRounds();
    }

    #region ui private
    private BindableCollection<int> _rounds { get; set; } = new();
    private double _teamTwoScore { get; set; }
    private string _tournamentName { get; set; } = string.Empty;
    private int _selectedRound { get; set; }
    private bool _unplayedOnly { get; set; }
    private string? _teamOne { get; set; }
    private string? _teamTwo { get; set; }
    private double _teamOneScore { get; set; }
    private MatchupModel? _selectedMatchup { get; set; }
    private BindableCollection<MatchupModel> _matchups { get; set; } = new();
    public string TournamentName{
        get
        {
            return $"Tournament: {Tournament.TournamentName}";
        }
        set
        {
            _tournamentName = value;
            NotifyOfPropertyChange(() => TournamentName);
        }
    }
    #endregion

    #region ui public
    public TournamentModel Tournament { get; set; }

    public BindableCollection<int> Rounds
    {
        get 
        { 
            return _rounds; 
        }
        set 
        { 
            _rounds = value; 
        }
    }

    public BindableCollection<MatchupModel> Matchups
    {
        get 
        { 
            return _matchups; 
        }
        set 
        { 
            _matchups = value; 
        }
    }

    public MatchupModel SelectedMatchup
    {
        get 
        { 
            return _selectedMatchup; }
        set 
        { 
            _selectedMatchup = value; 
            NotifyOfPropertyChange(() => SelectedMatchup);
            LoadMatchup();
        }
    }

    public int SelectedRound
    {
        get 
        { 
            return _selectedRound; 
        }
        set 
        { 
            _selectedRound = value;
            NotifyOfPropertyChange(() => SelectedRound);
            LoadMatchups();
        }
    }

    public bool UnplayedOnly
    {
        get 
        { 
            return _unplayedOnly; 
        }
        set 
        { 
            _unplayedOnly = value;
            NotifyOfPropertyChange(() => UnplayedOnly);
            LoadMatchups();
        }
    }

    public string TeamOne
    {
        get 
        { 
            return _teamOne; 
        }
        set 
        { 
            _teamOne = value;
            NotifyOfPropertyChange(() => TeamOne);
        }
    }

    public string TeamTwo
    {
        get 
        { 
            return _teamTwo; 
        }
        set 
        { 
            _teamTwo = value;
            NotifyOfPropertyChange(() => TeamTwo);
        }
    }

    public double TeamOneScore
    {
        get 
        { 
            return _teamOneScore; 
        }
        set 
        { 
            _teamOneScore = value;
            NotifyOfPropertyChange(() => TeamOneScore);
        }
    }

    public double TeamTwoScore
    {
        get 
        { 
            return _teamTwoScore; 
        }
        set 
        { 
            _teamTwoScore = value;
            NotifyOfPropertyChange(() => TeamTwoScore);
        }
    }
    #endregion

    #region aux methods
    private void LoadRounds()
    {
        Rounds = new() { 1 };
        int currRound = 1;

        foreach (List<MatchupModel> matchups in Tournament.Rounds)
        {
            if (matchups.First().MatchupRound > currRound)
            {
                currRound = matchups.First().MatchupRound;
                Rounds.Add(currRound);
            }
        }

        SelectedRound = 1;
    }

    private void LoadMatchups()
    {
        Matchups.Clear();

        foreach (List<MatchupModel> matchups in Tournament.Rounds)
            if (matchups.First().MatchupRound == SelectedRound)
                foreach (MatchupModel Matchup in matchups)
                    if (Matchup.Winner == null || !UnplayedOnly)
                        Matchups.Add(Matchup);

        if (Matchups.Any() is true)
        {
            SelectedMatchup = Matchups.First();
        }
    }

    private void LoadMatchup()
    {
        if(SelectedMatchup is null)
            return;

        for (int i = 0; i < SelectedMatchup.Entries.Count; i++)
        {
            if (i == 0)
            {
                if (SelectedMatchup.Entries[i].TeamCompeting != null)
                {
                    TeamOne = SelectedMatchup.Entries[0].TeamCompeting.TeamName;
                    TeamOneScore = SelectedMatchup.Entries[0].Score;

                    TeamTwo = "<bye>";
                    TeamTwoScore = 0;
                }
                else
                {
                    TeamOne = "Not yet set.";
                    TeamOneScore = 0;
                }
            }

            if (i == 1)
            {
                if (SelectedMatchup.Entries[i].TeamCompeting != null)
                {
                    TeamTwo = SelectedMatchup.Entries[1].TeamCompeting.TeamName;
                    TeamTwoScore = SelectedMatchup.Entries[1].Score;
                }
                else
                {
                    TeamTwo = "Not yet set.";
                    TeamTwoScore = 0;
                }
            }
        }
    }
    #endregion

    #region button action
    public void ScoreMatch()
    {
        for (int i = 0; i < SelectedMatchup.Entries.Count; i++)
        {
            if (i is 0)
                if (SelectedMatchup.Entries[i].TeamCompeting is not null)
                    SelectedMatchup.Entries[0].Score = TeamOneScore;

            if (i is 1)
                if (SelectedMatchup.Entries[i].TeamCompeting is not null)
                    SelectedMatchup.Entries[1].Score = TeamTwoScore;
        }

        try
        {
            TournamentLogic.UpdateTournamentResults(Tournament);
        }
        catch (Exception exc)
        {
            MessageBox.Show($"Error: {exc.Message}");
            return;
        }

        LoadMatchups();
    }
    #endregion
}

