using System.Collections.Generic;
using System.Net.Mail;
using JnjStudyCompoundChecker.Constants;

namespace JnjStudyCompoundChecker.Services.Interfaces
{
    public interface IMailService
    {
        SmtpClient GetSmtpClient();
        MailMessage CreateMailMessage(Enums.MailBody mailBody, IEnumerable<string> protocolNames = null);
    }
}
