namespace JnjStudyCompoundChecker.Models.AppSettingsModels
{
    public class MailSettings
    {
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string SmtpName { get; set; }
        public string Password { get; set; }
        public string Attachment { get; set; }
        public int Port { get; set; }
    }
}
