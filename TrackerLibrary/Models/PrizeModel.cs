
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

    /// <summary>
    /// the amount out of the winning price for 2nd, 3rd, etc...
    /// </summary>
    public double PrizePercentage { get; set; }

    public PrizeModel(){}

    public PrizeModel(
            string placeName, 
            string placeNumber, 
            string prizeAmount, 
            string prizePercentage)
    {
        PlaceName = placeName;

        int.TryParse(placeNumber, out var placeNumberValue);
        decimal.TryParse(prizeAmount, out var prizeAmountValue);
        double.TryParse(prizePercentage, out var prizePercentageValue);

        PlaceNumber = placeNumberValue;
        PrizeAmount = prizeAmountValue;
        PrizePercentage = prizePercentageValue;
    }

}
