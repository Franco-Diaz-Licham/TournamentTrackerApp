namespace TrackerWPFUI.ViewModels;

public class CreateTournamentViewModel : Conductor<object>.Collection.AllActive, IHandle<TeamModel>, IHandle<PrizeModel>
{
	public CreateTournamentViewModel()
	{
        _availableTeams = new(GlobalConfig.Connection.GetTeam_All());
        TrackerEventAggregator.SubscribeOnBackgroundThread(this);
    }

    #region ui private 
    private string _tournamentName {  get; set; } = string.Empty;
    private decimal _entryFee { get; set; }
    private bool _selectedTeamsIsVisible { get; set; } = true;
    private bool _selectedPrizesIsVisible { get; set; } = true;
    private bool _addTeamIsVisible { get; set; } = false;
    private bool _addPrizeIsVisible { get; set; } = false;
    private TeamModel? _selectedTeamToAdd { get; set; }
    private TeamModel? _selectedTeamToRemove { get; set; }
    private Screen? _activeAddTeamView { get; set; }
    private PrizeModel? _selectedPrizeToRemove { get; set; }
    private Screen? _activeAddPrizeView { get; set; }
    private BindableCollection<TeamModel> _selectedTeams { get; set; } = new();
	private BindableCollection<PrizeModel> _selectedPrizes { get; set; } = new();
    private BindableCollection<TeamModel> _availableTeams { get; set; } = new();
    #endregion

    #region ui public
    public string TournamentName
	{
		get 
		{ 
			return _tournamentName; 
		}
		set 
		{ 
			_tournamentName = value; 
			NotifyOfPropertyChange(() => TournamentName);
		}
	}

    public decimal EntryFee
	{
		get 
		{ 
			return _entryFee; 
		}
		set 
		{ 
			_entryFee = value;
			NotifyOfPropertyChange(() => EntryFee);
		}
	}

    public TeamModel SelectedTeamToAdd
    {
        get
        {
            return _selectedTeamToAdd;
        }
        set
        {
            _selectedTeamToAdd = value;
            NotifyOfPropertyChange(() => SelectedTeamToAdd);
            NotifyOfPropertyChange(() => CanAddTeam);
        }
    }

    public TeamModel SelectedTeamToRemove
    {
        get
        {
            return _selectedTeamToRemove;
        }
        set
        {
            _selectedTeamToRemove = value;
            NotifyOfPropertyChange(() => SelectedTeamToRemove);
            NotifyOfPropertyChange(() => CanRemoveTeam);
        }
    }

    public Screen ActiveAddTeamView
    {
        get
        {
            return _activeAddTeamView;
        }
        set
        {
            _activeAddTeamView = value;
            NotifyOfPropertyChange(() => ActiveAddTeamView);
        }
    }

    public PrizeModel SelectedPrizeToRemove
    {
        get
        {
            return _selectedPrizeToRemove;
        }
        set
        {
            _selectedPrizeToRemove = value;
            NotifyOfPropertyChange(() => SelectedPrizeToRemove);
            NotifyOfPropertyChange(() => CanRemovePrize);
        }
    }

    public Screen ActiveAddPrizeView
    {
        get
        {
            return _activeAddPrizeView;
        }
        set
        {
            _activeAddPrizeView = value;
            NotifyOfPropertyChange(() => ActiveAddPrizeView);
        }
    }

    public BindableCollection<TeamModel> AvailableTeams
    {
		get 
		{ 
			return _availableTeams; 
		}
		set 
		{ 
			_availableTeams = value; 
		}
	}

	public BindableCollection<TeamModel> SelectedTeams
	{
		get 
		{ 
			return _selectedTeams; 
		}
		set 
		{ 
			_selectedTeams = value;
			NotifyOfPropertyChange(() => SelectedTeams);
        }
	}

    public BindableCollection<PrizeModel> SelectedPrizes
	{
		get 
		{
			return _selectedPrizes; 
		}
		set 
		{ 
			_selectedPrizes = value; 
			NotifyOfPropertyChange(() => SelectedPrizes);
		}
	}
    #endregion

    #region validation
    public bool CanAddTeam => SelectedTeamToAdd != null;
	public bool CanRemoveTeam => SelectedTeamToRemove != null;
	public bool CanRemovePrize => SelectedPrizeToRemove != null;
	public bool CanCreateTournament
	{
		get
		{
			if(string.IsNullOrWhiteSpace(TournamentName) is true)
				return false;
			if(SelectedTeams.Any() is false)
				return false;
			if(SelectedPrizes.Any() is false) 
				return false;
			return true;
		}
	}
    #endregion

    #region button actions
    public bool SelectedTeamsIsVisible
    {
        get
        {
            return _selectedTeamsIsVisible;
        }
        set
        {
            _selectedTeamsIsVisible = value;
            NotifyOfPropertyChange(() => SelectedTeamsIsVisible);
        }
    }
    public bool AddTeamIsVisible
    {
        get
        {
            return _addTeamIsVisible;
        }
        set
        {
            _addTeamIsVisible = value;
            NotifyOfPropertyChange(() => AddTeamIsVisible);
        }
    }
    public bool SelectedPrizesIsVisible
    {
        get
        {
            return _selectedPrizesIsVisible;
        }
        set
        {
            _selectedPrizesIsVisible = value;
            NotifyOfPropertyChange(() => SelectedPrizesIsVisible);
        }
    }
    public bool AddPrizeIsVisible
    {
        get
        {
            return _addPrizeIsVisible;
        }
        set
        {
            _addPrizeIsVisible = value;
            NotifyOfPropertyChange(() => AddPrizeIsVisible);
        }
    }

    public void AddTeam()
	{
        SelectedTeams.Add(SelectedTeamToAdd!);
        AvailableTeams.Remove(SelectedTeamToAdd!);
		NotifyOfPropertyChange(() => CanCreateTournament);
	}

	public void RemoveTeam()
	{
        AvailableTeams.Add(SelectedTeamToRemove!);
        SelectedTeams.Remove(SelectedTeamToRemove!);
		NotifyOfPropertyChange(() => CanCreateTournament);
	}

	public void CreateTeam()
	{
		ActiveAddTeamView = new CreateTeamViewModel();
		Items.Add(ActiveAddTeamView);
        SelectedTeamsIsVisible = false;
        AddTeamIsVisible = true;
	}

	public void CreatePrize()
	{
        ActiveAddPrizeView = new CreatePrizeViewModel();
        Items.Add(ActiveAddPrizeView);
        SelectedPrizesIsVisible = false;
        AddPrizeIsVisible = true;
    }

	public void RemovePrize()
	{
        SelectedPrizes.Remove(SelectedPrizeToRemove!);
        NotifyOfPropertyChange(() => CanCreateTournament);
    }

    public void CreateTournament()
	{
        TournamentModel model = new()
        {
            TournamentName = TournamentName,
            EntryFee = EntryFee,
            EnteredTeams = SelectedTeams.ToList(),
            Prizes = SelectedPrizes.ToList()
        };

        TournamentLogic.CreateRounds(model);

		GlobalConfig.Connection.CreateTournament(model);
		TrackerEventAggregator.PublishOnUIThreadAsync(model);
        TryCloseAsync();
    }
    #endregion

    #region handlers
    public async Task HandleAsync(
			TeamModel model, 
			CancellationToken cancellationToken)
    {
		if(string.IsNullOrWhiteSpace(model.TeamName) is false)
            SelectedTeams.Add(model);

        SelectedTeamsIsVisible = true;
		AddTeamIsVisible = false;
        NotifyOfPropertyChange(() => CanCreateTournament);
    }

    public async Task HandleAsync(
			PrizeModel model, 
			CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(model.PlaceName) is false)
            SelectedPrizes.Add(model);

        SelectedPrizesIsVisible = true;
        AddPrizeIsVisible = false;
        NotifyOfPropertyChange(() => CanCreateTournament);
    }
    #endregion
}
