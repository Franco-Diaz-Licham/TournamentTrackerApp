namespace TrackerWPFUI.ViewModels;

public class CreatePrizeViewModel : Screen
{
    #region ui private
    private int _placeNumber { get; set; }
    private string _placeName { get; set; } = string.Empty;
    private decimal _prizeAmount { get; set; }
    private double _prizePercentage { get; set; }
    #endregion

    #region ui public
    public int PlaceNumber
	{
		get { return _placeNumber; }
		set 
		{ 
			_placeNumber = value;
			NotifyOfPropertyChange(() => PlaceNumber);
			NotifyOfPropertyChange(() => CanCreatePrize);
		}
	}
	public string PlaceName
	{
		get { return _placeName; }
		set 
		{ 
			_placeName = value;
            NotifyOfPropertyChange(() => PlaceName);
            NotifyOfPropertyChange(() => CanCreatePrize);
        }
	}
	public decimal PrizeAmount
	{
		get { return _prizeAmount; }
		set { 
			_prizeAmount = value; 
			NotifyOfPropertyChange(() => PrizeAmount);
            NotifyOfPropertyChange(() => CanCreatePrize);
        }
	}
	public double PrizePercentage
	{
		get { return _prizePercentage; }
		set 
		{ 
			_prizePercentage = value;
            NotifyOfPropertyChange(() => PrizePercentage);
            NotifyOfPropertyChange(() => CanCreatePrize);
        }
	}
    #endregion

    #region validation
    public bool CanCreatePrize
	{
		get
		{
            if (PlaceNumber < 1)
                return false;
            if (PlaceName.Length == 0)
                return false;
            if (PrizeAmount <= 0 && PrizePercentage <= 0)
                return false;
            if (PrizePercentage < 0 || PrizePercentage > 100)
                return false;

            return true;
        }
    }
    #endregion

    #region button actions
    public void CreatePrize()
	{
		PrizeModel model = new() 
		{ 
			PlaceNumber = PlaceNumber, 
			PlaceName = PlaceName, 
			PrizeAmount = PrizeAmount, 
			PrizePercentage = PrizePercentage 
		};

        GlobalConfig.Connection.CreatePrize(model);
        TrackerEventAggregator.PublishOnUIThreadAsync(model);
        TryCloseAsync();

    }

    public void CancelCreation()
    {
        TrackerEventAggregator.PublishOnUIThreadAsync(new PrizeModel());
        TryCloseAsync();
    }
    #endregion
}
