namespace TrackerUI;

public partial class CreatePrizeForm : Form
{
    private IPrizeRequester CallingForm { get; set; }

    public CreatePrizeForm(
            IPrizeRequester Caller)
    {
        InitializeComponent();
        CallingForm = Caller;
    }

    private void createPrizeButton_Click(
            object sender, 
            EventArgs e)
    {
        if (ValidateForm() is false)
        {
            MessageBox.Show("This is not a valid Form, please check and try again.");
            return;
        }

        PrizeModel model = new( PlaceNameValue.Text,
                                placeNumberValue.Text,
                                prizeAmountValue.Text,
                                prizePercentageValue.Text);

        GlobalConfig.Connection.CreatePrize(model);
        CallingForm.PrizeComplete(model);

        this.Close();
    }

    private bool ValidateForm()
    { 
        bool output = true;
        bool placeNumberValid = int.TryParse(placeNumberValue.Text, out var placeNumber);
        bool prizeAmountValid = decimal.TryParse(prizeAmountValue.Text, out var prizeAmount);
        bool prizePercentageValid = double.TryParse(prizePercentageValue.Text, out var prizePercentage);

        // check validation conditions
        if (placeNumberValid == false)
            output = false;
        if (placeNumber < 1)
            output = false;
        if (PlaceNameValue.Text.Length == 0)
            output = false;
        if (prizeAmountValid == false || prizePercentageValid == false)
            output = false;
        if (prizeAmount <= 0 && prizePercentage <= 0)
            output = false;
        if (prizePercentage < 0 || prizePercentage > 100)
            output = false;

        return output;
    }
}
