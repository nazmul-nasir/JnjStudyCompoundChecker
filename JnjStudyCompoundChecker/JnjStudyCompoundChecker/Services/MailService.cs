using System;
using System.Collections.Generic;
using System.Linq;
using JnjStudyCompoundChecker.Models.AppSettingsModels;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using JnjStudyCompoundChecker.Constants;

namespace JnjStudyCompoundChecker.Services
{
    public class MailService : IMailService
    {
        private readonly IOptions<MailSettings> _mailSettings;

        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings;
        }

        private string GetMailBody(Enums.MailBody mailBody, IEnumerable<string> protocolNames)
        {
            switch (mailBody)
            {
                case Enums.MailBody.FileNotFoundBody:
                    return _mailSettings.Value.FileNotFoundBody;

                case Enums.MailBody.ProcessingFailedBody:
                    return _mailSettings.Value.ProcessingFailedBody;

                case Enums.MailBody.CompoundMismatchBody:
                    var longBody = string.Empty;
                    longBody = protocolNames.Aggregate(longBody, (current, protocolName) => 
                                current + _mailSettings.Value.CompoundMismatchBody.Replace(Constants.Common.ProtocolName, protocolName) 
                                        + Environment.NewLine);
                    return longBody;
                
                default:
                    return string.Empty;
            }
        }

        public MailMessage CreateMailMessage(Enums.MailBody mailBody, IEnumerable<string> protocolNames = null)
        {
            var subject = _mailSettings.Value.Subject.Replace(Constants.Common.EnvironmentName, 
                            _mailSettings.Value.Environment);

            var mail = new MailMessage {From = new MailAddress(_mailSettings.Value.Sender)};
            mail.To.Add(_mailSettings.Value.Recipient);
            mail.Subject = subject;
            mail.Body = GetMailBody(mailBody, protocolNames);
            return mail;
        }

        public SmtpClient GetSmtpClient()
        {
            var smtpClient = new SmtpClient(_mailSettings.Value.SmtpName)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Port = _mailSettings.Value.Port,
                Credentials = new System.Net.NetworkCredential(_mailSettings.Value.Sender, _mailSettings.Value.Password)
            };
            return smtpClient;
        }
    }
}