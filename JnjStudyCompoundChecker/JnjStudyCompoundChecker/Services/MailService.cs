using JnjStudyCompoundChecker.Models.AppSettingsModels;
using Microsoft.Extensions.Options;
using System.Net.Mail;

namespace JnjStudyCompoundChecker.Services
{
    public class MailService : IMailService
    {
        private readonly IOptions<MailSettings> _mailSettings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings;
                
        }
        public MailMessage GetEmail()
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(_mailSettings.Value.Sender);
            mail.To.Add(_mailSettings.Value.Recipient);
            mail.Subject = _mailSettings.Value.Recipient;
            mail.Body = _mailSettings.Value.Body;

            if (!string.IsNullOrEmpty(_mailSettings.Value.Attachment))
            {
                    mail.Attachments.Add(new System.Net.Mail.Attachment(_mailSettings.Value.Attachment));
            }
            return mail;
        }

        public SmtpClient GetSmtpServer()
        {
            SmtpClient SmtpServer = new SmtpClient(_mailSettings.Value.SmtpName);
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Port = _mailSettings.Value.Port;
            SmtpServer.Credentials = new System.Net.NetworkCredential(_mailSettings.Value.Sender, _mailSettings.Value.Password);
            SmtpServer.EnableSsl = true;
            return SmtpServer;
        }
    }
}