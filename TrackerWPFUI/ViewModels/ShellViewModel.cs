namespace TrackerWPFUI.ViewModels;

public class ShellViewModel : Conductor<object>, IHandle<TournamentModel>
{
    public ShellViewModel()
    {
        OnStartup();
        _existingTournaments = new(GlobalConfig.Connection.GetTournament_All());
        TrackerEventAggregator.SubscribeOnBackgroundThread(this);
    }

    private BindableCollection<TournamentModel> _existingTournaments { get; set; }
    private TournamentModel _selectedTournament { get; set; } = new();
    public BindableCollection<TournamentModel> ExistingTournaments
    {
        get 
        { 
            return _existingTournaments; 
        }
        set 
        { 
            _existingTournaments = value; 
        }
    }
    public TournamentModel SelectedTournament
    {
        get 
        { 
            return _selectedTournament; 
        }
        set
        {
            _selectedTournament = value;
            NotifyOfPropertyChange(() => SelectedTournament);
            LoadTournament();
        }
    }

    private void OnStartup()
    {
        var builder = new ConfigurationBuilder();
        builder.SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json");
        IConfiguration Config = builder.Build();

        var cnx = Config.GetConnectionString("Tournaments");
        GlobalConfig.InitializeConnection(DatabaseTypeEnum.Sql, cnx);
    }

    public void LoadTournament()
    {
        if(SelectedTournament is null)
            return;
        if (string.IsNullOrWhiteSpace(SelectedTournament.TournamentName) is false)
            ActivateItemAsync(new TournamentViewerViewModel(SelectedTournament));
    }

    public void CreateTournament()
    {
        ActivateItemAsync(new CreateTournamentViewModel());
    }

    public async Task HandleAsync(
            TournamentModel model, 
            CancellationToken cancellationToken)
    {
        ExistingTournaments.Add(model);
        SelectedTournament = model;
    }
}
