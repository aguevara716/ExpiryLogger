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
    private readonly IEmailSettingsRetriever _emailSettingsRetriever;
    private readonly ILogger<IEmailSender> _logger;

    public EmailSender(IEmailSettingsRetriever emailSettingsRetriever, ILogger<IEmailSender> logger)
    {
        _emailSettingsRetriever = emailSettingsRetriever;
        _logger = logger;
    }

    public bool SendEmail(MailMessage mailMessage)
    {
        _logger.LogTrace("SendEmail");
        try
        {
            var emailSettings = _emailSettingsRetriever.GetEmailSettings();

            using var smtpClient = new SmtpClient(emailSettings.Host)
            {
                Port = emailSettings.Port,
                Credentials = new NetworkCredential(emailSettings.Username, emailSettings.Password),
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
