namespace TrackerUI;

public partial class TournamentDashboardForm : Form, ITournamentRequester
{
    private List<TournamentModel> tournamentModels = GlobalConfig.Connection.GetTournament_All();

    public TournamentDashboardForm()
    {
        InitializeComponent();
        WiredUpLists();
    }

    private void LoadTournamentButton_Click(object sender, EventArgs e)
    {
        TournamentModel model = (TournamentModel)loadExistingTournamentDropDown.SelectedItem;
        TournamentViewerForm frm = new(model);
        frm.Show();
    }

    private void CreateTournamentButton_Click(object sender, EventArgs e)
    {
        CreateTournamentForm frm = new(this);
        frm.Show();
    }

    public void TournamentComplete(TournamentModel model)
    {
        tournamentModels.Add(model);
        WiredUpLists();
    }

    public void WiredUpLists()
    {
        loadExistingTournamentDropDown.DataSource = null;
        loadExistingTournamentDropDown.DataSource = tournamentModels;
        loadExistingTournamentDropDown.DisplayMember = "TournamentName";
    }
}
