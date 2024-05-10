namespace TrackerLibrary.AppLogic;

public static class SMSLogic
{
    /// <summary>
    /// Method which sends a text message.
    /// </summary>
    /// <param name="to">Receipient phone number.</param>
    /// <param name="textMessage">The body of the text.</param>
    public static void SendSMSMessage(string to, string textMessage)
    {
        string accountSid = GlobalConfig.AppKeyLookup("smsAccountSid");
        string authToken = GlobalConfig.AppKeyLookup("smsAuthToken");
        string fromPhoneNumber = GlobalConfig.AppKeyLookup("smsFromPhoneNumber");

        TwilioClient.Init(accountSid, authToken);

        // send message
        var message = MessageResource.Create(
            to: new PhoneNumber(to),
            from: new PhoneNumber(fromPhoneNumber),
            body: textMessage);
    }
}
