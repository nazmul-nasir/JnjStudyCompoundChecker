namespace JnjStudyCompoundChecker.Models.AppSettingsModels
{
    public class MailSettings
    {
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string Subject { get; set; }
        public string Environment { get; set; }
        public int Port { get; set; }
        public string SmtpName { get; set; }
        public string Password { get; set; }
        public string FileNotFoundBody { get; set; }
        public string ProcessingFailedBody { get; set; }
        public string CompoundMismatchBody { get; set; }
        
    }
}
