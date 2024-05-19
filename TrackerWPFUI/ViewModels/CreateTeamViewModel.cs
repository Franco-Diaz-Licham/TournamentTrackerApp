namespace TrackerWPFUI.ViewModels;

public class CreateTeamViewModel : Conductor<object>, IHandle<PersonModel>
{
    #region constructors
    public CreateTeamViewModel()
    {
        _availableTeamMembers = new(GlobalConfig.Connection.GetPerson_All());
		TrackerEventAggregator.SubscribeOnBackgroundThread(this);
    }
    #endregion

    #region ui private
    private string _teamName { get; set; } = string.Empty;
	private BindableCollection<PersonModel> _availableTeamMembers { get; set; } = new();
	private PersonModel? _selectedTeamMemberToAdd { get; set; }
	private BindableCollection<PersonModel> _selectedTeamMembers { get; set; } = new();
	private PersonModel? _selectedTeamMemberToRemove { get; set; }
	private bool _selectedTeamMembersIsVisible { get; set; } = true;
	private bool _addPersonIsVisible { get; set; } = false;	
	#endregion

	#region ui public
	public string TeamName
	{
		get 
		{ 
			return _teamName; 
		}
		set
		{
			_teamName = value;
			NotifyOfPropertyChange(() => TeamName);
			NotifyOfPropertyChange(() => CanCreateTeam);
		}
	}
	public BindableCollection<PersonModel> AvailableTeamMembers
	{
		get 
		{ 
			return _availableTeamMembers; 
		}
		set 
		{ 
			_availableTeamMembers = value; 
		}
	}
	public PersonModel? SelectedTeamMemberToAdd
	{
		get 
		{ 
			return _selectedTeamMemberToAdd; 
		}
		set
		{
			_selectedTeamMemberToAdd = value;
			NotifyOfPropertyChange(() => SelectedTeamMemberToAdd);
			NotifyOfPropertyChange(() => CanAddMember);
		}
	}
	public BindableCollection<PersonModel> SelectedTeamMembers
	{
		get 
		{ 
			return _selectedTeamMembers; 
		}
		set
		{
			_selectedTeamMembers = value;
		}
	}
	public PersonModel? SelectedTeamMemberToRemove
	{
		get 
		{ 
			return _selectedTeamMemberToRemove; 
		}
		set
		{
			_selectedTeamMemberToRemove = value;
			NotifyOfPropertyChange(() => SelectedTeamMemberToRemove);
			NotifyOfPropertyChange(() => CanRemoveMember);
		}
	}
    public bool SelectedTeamMembersIsVisible
    {
        get
        {
            return _selectedTeamMembersIsVisible;
        }
        set
        {
            _selectedTeamMembersIsVisible = value;
            NotifyOfPropertyChange(() => SelectedTeamMembersIsVisible);
        }
    }
    public bool AddPersonIsVisible
    {
        get
        {
            return _addPersonIsVisible;
        }
        set
        {
            _addPersonIsVisible = value;
            NotifyOfPropertyChange(() => AddPersonIsVisible);
        }
    }
    #endregion

    #region validation
    public bool CanAddMember => SelectedTeamMemberToAdd != null;
    public bool CanRemoveMember => SelectedTeamMemberToRemove != null;
    public bool CanCreateTeam
    {
        get
        {
            if (string.IsNullOrEmpty(TeamName))
                return false;
            if (SelectedTeamMembers.Any() is false)
                return false;

            return true;
        }
    }
    #endregion

    #region button actions
    public void AddMember()
	{
		SelectedTeamMembers.Add(SelectedTeamMemberToAdd!);
		AvailableTeamMembers.Remove(SelectedTeamMemberToAdd!);
        NotifyOfPropertyChange(() => CanCreateTeam);
    }

    public void RemoveMember()
	{
        AvailableTeamMembers.Add(SelectedTeamMemberToRemove!);
        SelectedTeamMembers.Remove(SelectedTeamMemberToRemove!);
        NotifyOfPropertyChange(() => CanCreateTeam);
    }

    public void CreateMember()
	{
		ActivateItemAsync(new CreatePersonViewModel());
        SelectedTeamMembersIsVisible = false;
		AddPersonIsVisible = true;
	}

    public void CreateTeam()
	{
        TeamModel model = new()
        {
            TeamName = TeamName,
            TeamMembers = SelectedTeamMembers.ToList(),
        };

        GlobalConfig.Connection.CreateTeam(model);
        TrackerEventAggregator.PublishOnUIThreadAsync(model);
        TryCloseAsync();
    }

    public void CancelCreation()
    {
        TrackerEventAggregator.PublishOnUIThreadAsync(new TeamModel());
        TryCloseAsync();
    }
    #endregion

    #region handlers
    public async Task HandleAsync(
        PersonModel p,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(p.FullName) is false)
        {
            SelectedTeamMembers.Add(p);
            NotifyOfPropertyChange(() => CanCreateTeam);
        }

        SelectedTeamMembersIsVisible = true;
        AddPersonIsVisible = false;
    }
    #endregion
}
