using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace JnjStudyCompoundChecker.Services
{
    public interface IMailService
    {
        SmtpClient GetSmtpServer();
        MailMessage GetEmail();
    }
}
