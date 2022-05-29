using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Logging;

namespace ExpiryLogger.NotifierService;

public interface IEmailSender
{
    bool SendEmail(MailMessage mailMessage);
}

public class EmailSender : IEmailSender
{
    private readonly ILogger<IEmailSender> _logger;

    public EmailSender(ILogger<IEmailSender> logger)
    {
        _logger = logger;
    }

    public bool SendEmail(MailMessage mailMessage)
    {
        _logger.LogTrace("SendEmail");
        try
        {
            using var smtpClient = new SmtpClient(emailHost)
            {
                Port = emailPort,
                Credentials = new NetworkCredential(emailUsername, emailPassword),
                EnableSsl = true
            };

            _logger.LogInformation("Sending email...");
            smtpClient.Send(mailMessage);
            _logger.LogInformation("Sent email");
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to send email");
            return false;
        }
    }

}
