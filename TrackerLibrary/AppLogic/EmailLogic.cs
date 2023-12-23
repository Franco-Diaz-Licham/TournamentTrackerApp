namespace TrackerLibrary.AppLogic;

public static class EmailLogic
{
    public static void SendEmail(string to, string subject, string body)
    {
        SendEmail(new List<string> { to }, new List<string>(), subject, body);
    }

    public static void SendEmail(List<string> to, List<string> bcc, string subject, string body)
    {
        string fromEmail = ConfigurationManager.AppSettings["fromEmail"];
        string SendDisplayName = ConfigurationManager.AppSettings["sendDisplayName"];

        MailAddress fromMailAddress = new(fromEmail, SendDisplayName);
        SmtpClient Client = new();
        MailMessage mail = new()
        {
            From = fromMailAddress,
            Subject = subject,
            Body = body,
            IsBodyHtml = true
        };

        foreach (string email in to)
        {
            if(email != null)
            {
                mail.To.Add(email);
            }
        }

        foreach (string email in bcc)
        {
            if(email != null)
            {
                mail.Bcc.Add(email);
            }
        }

        Client.Send(mail);
    }
}
