
namespace TrackerLibrary.Models;

public class PrizeModel
{
    #region table cols
    public int Id { get; set; }
    public int PlaceNumber { get; set; }
    public string PlaceName { get; set; }
    public decimal PrizeAmount { get; set; }
    public double PrizePercentage { get; set; }
    #endregion

    #region constructors
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
    #endregion
}
