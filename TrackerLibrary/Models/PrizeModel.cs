
namespace TrackerLibrary.Models;

public class PrizeModel
{
    /// <summary>
    /// unique identifier for the prize
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// the physical number of the place so that we are able to sort, etc...
    /// </summary>
    public int PlaceNumber { get; set; }

    /// <summary>
    /// the place name, whether first second, etc...
    /// </summary>
    public string PlaceName { get; set; }

    /// <summary>
    /// the amount in dollars to pay to the winner
    /// </summary>
    public decimal PrizeAmount { get; set; }

    // doubles are less precise than decimal. up to 14 d.p. precice only.
    /// <summary>
    /// the amount out of the winning price for 2nd, 3rd, etc...
    /// </summary>
    public double PrizePercentage { get; set; }

    public PrizeModel()
    {

    }

    /// <summary>
    /// method to instantiate object PrizeModel
    /// </summary>
    /// <param name="placeName"> property placeName </param>
    /// <param name="placeNumber"> property PlaceNumber </param>
    /// <param name="prizeAmount"> property prizeAmount </param>
    /// <param name="prizePercentage"> property prizePercentage </param>
    public PrizeModel(string placeName, string placeNumber, string prizeAmount, string prizePercentage)
    {
        // since validation was checked under createPrizeForm, there is no need for validation here
        // all we need to do here is to update the properties for the object being created
        PlaceName = placeName;

        int placeNumberValue = 0;
        int.TryParse(placeNumber, out placeNumberValue);
        PlaceNumber = placeNumberValue;

        decimal prizeAmountValue = 0;
        decimal.TryParse(prizeAmount, out prizeAmountValue);
        PrizeAmount = prizeAmountValue;

        double prizePercentageValue = 0;
        double.TryParse(prizePercentage, out prizePercentageValue);
        PrizePercentage = prizePercentageValue;
    }

}
