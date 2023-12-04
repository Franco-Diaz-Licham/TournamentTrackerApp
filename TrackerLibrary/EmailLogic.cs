
namespace TournamentTrackerTests
{
    public static class EmailLogic
    {
        public static void SendEmail(string to, string subject, string body)
        {
            string fromEmail = ConfigurationManager.AppSettings["fromEmail"];
            string SendDisplayName = ConfigurationManager.AppSettings["sendDisplayName"];

            MailAddress fromMailAddress = new MailAddress(fromEmail, SendDisplayName);

            MailMessage mail = new MailMessage();
            mail.To.Add(to);
            mail.From = fromMailAddress;
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            SmtpClient Client = new SmtpClient();

            Client.Send(mail);
        }
    }
}
