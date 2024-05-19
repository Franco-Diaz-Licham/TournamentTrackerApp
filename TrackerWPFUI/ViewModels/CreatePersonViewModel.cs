namespace TrackerWPFUI.ViewModels;

public class CreatePersonViewModel : Screen
{
	public CreatePersonViewModel() { }

    #region ui private
    private string _firstName {  get; set; } = string.Empty;
    private string _lastName { get; set; } = string.Empty;
    private string _emailAddress { get; set; } = string.Empty;
    private string _cellphone { get; set; } = string.Empty;
    #endregion

    #region ui public
    public string FirstName
	{
		get 
		{ 
			return _firstName; 
		}
		set 
		{ 
			_firstName = value; 
			NotifyOfPropertyChange(() => FirstName);
			NotifyOfPropertyChange(() => CanCreatePerson);
		}
	}
	public string LastName
	{
		get 
		{ 
			return _lastName; 
		}
		set 
		{ 
			_lastName = value; 
			NotifyOfPropertyChange(() => LastName);
            NotifyOfPropertyChange(() => CanCreatePerson);
        }
	}
	public string EmailAddress
	{
		get 
		{ 
			return _emailAddress; 
		}
		set 
		{ 
			_emailAddress = value;
			NotifyOfPropertyChange(() => EmailAddress);
            NotifyOfPropertyChange(() => CanCreatePerson);
        }
	}
	public string Cellphone
	{
		get 
		{ 
			return _cellphone;
		}
		set 
		{ 
			_cellphone = value;
			NotifyOfPropertyChange(() => Cellphone);
            NotifyOfPropertyChange(() => CanCreatePerson);
        }
	}
	#endregion

	#region validation
	public bool CanCreatePerson
	{
		get
		{
			if (string.IsNullOrEmpty(FirstName))
				return false;
			if (string.IsNullOrEmpty(LastName))
				return false;
			if (string.IsNullOrEmpty(EmailAddress))
				return false;
			if (string.IsNullOrEmpty(Cellphone))
				return false;
			return true;
		}
	}
    #endregion

    #region button actions
    public void CreatePerson()
	{
        PersonModel model = new()
        {
            FirstName = FirstName,
            LastName = LastName,
            EmailAddress = EmailAddress,
            CellphoneNumber = Cellphone
        };

		GlobalConfig.Connection.CreatePerson(model);
		TrackerEventAggregator.PublishOnUIThreadAsync(model);
		TryCloseAsync();
    }

	public void CancelCreation()
	{
        TrackerEventAggregator.PublishOnUIThreadAsync(new PersonModel());
        TryCloseAsync();
    }
    #endregion
}
