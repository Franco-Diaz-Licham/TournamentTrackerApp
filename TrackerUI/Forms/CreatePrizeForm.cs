
namespace TrackerUI
{
    public partial class CreatePrizeForm : Form
    {
        IPrizeRequester callingForm;

        public CreatePrizeForm(IPrizeRequester Caller)
        {
            InitializeComponent();
            callingForm = Caller;
        }

        /// <summary>
        /// in the event of the click of the create prize button, we will create the prizeModel object
        /// write to the sql db and bring back the info we required
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            // run method to check whether form is valid
            if (ValidateForm())
            {
                /// instantiate object prizeModel
                PrizeModel model = new PrizeModel(
                    PlaceNameValue.Text,
                    placeNumberValue.Text,
                    prizeAmountValue.Text,
                    prizePercentageValue.Text);

                // since the globalConfig was initiated from program.cs the list of globalConfig.Connection
                // will already have the datasource of interest. Call the method createPrize appropriate for
                // the datasource which will write to the database and return the object information from the db
                GlobalConfig.Connection.CreatePrize(model);

                callingForm.PrizeComplete(model);

                this.Close();

                // clear the entries of the form
                //PlaceNameValue.Text = "";
                //placeNumberValue.Text = "";
                //prizeAmountValue.Text = "0";
                //prizePercentageValue.Text = "0";
            }

            // if form validation is false, show user and error message
            else
            {
                MessageBox.Show("This is not a valid Form, please check and try again.");
            }
        }

        /// <summary>
        /// defines the method to check whether the form input is valid
        /// </summary>
        /// <returns></returns>
        private bool ValidateForm()
        { 
            // define the variables
            bool output = true;
            int placeNumber = 0;
            decimal prizeAmount = 0;
            double prizePercentage = 0;

            // we do not use out parameters anywhere else than just Tryparse
            // try parse does not crash when things do not work. it returns a true when successfull
            // as well as the actual value passed in. e.g. placeNumberValue.Text will return
            // placeNumberValid as true, and placenumber as the value of placeNumberValue.Text
            bool placeNumberValid = int.TryParse(placeNumberValue.Text, out placeNumber);
            bool prizeAmountValid = decimal.TryParse(prizeAmountValue.Text, out prizeAmount);
            bool prizePercentageValid = double.TryParse(prizePercentageValue.Text, out prizePercentage);

            // check if number is valid and that it is not below 1
            if (placeNumberValid == false)
            {
                output = false;
            }
            if (placeNumber < 1)
            {
                output = false;
            }

            // check that The placeName is not empty
            if (PlaceNameValue.Text.Length == 0)
            {
                output = false;
            }

            // 1. check that prizeAmounts and PrizePercentages are valid types of data
            // 2. check that prizeAmmount and prizePercentace cannot both be zero at the same time
            // 3. check  that negative numbers cannot be entered for prizePercentage and number greater than 100
            if (prizeAmountValid == false || prizePercentageValid == false)
            {
                output = false;
            }
            if (prizeAmount <= 0 && prizePercentage <= 0)
            {
                output = false;
            }
            if (prizePercentage < 0 || prizePercentage > 100)
            {
                output = false;
            }

            // return the result of the validation
            return output;
        }
    }
}
