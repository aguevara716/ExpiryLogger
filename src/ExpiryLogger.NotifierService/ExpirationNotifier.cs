using Microsoft.Extensions.Logging;

namespace ExpiryLogger.NotifierService;

public interface IExpirationNotifier
{
    void NotifyRecipients();
}

public class ExpirationNotifier : IExpirationNotifier
{
    private readonly IEmailBodyBuilder _emailBodyBuilder;
    private readonly IEmailBuilder _emailBuilder;
    private readonly IEmailSender _emailSender;
    private readonly IItemsRetriever _itemsRetriever;
    private readonly ILogger<IExpirationNotifier> _logger;

    public ExpirationNotifier(IEmailBodyBuilder emailBodyBuilder,
        IEmailBuilder emailBuilder,
        IEmailSender emailSender,
        IItemsRetriever itemsRetriever,
        ILogger<IExpirationNotifier> logger)
    {
        _emailBodyBuilder = emailBodyBuilder;
        _emailBuilder = emailBuilder;
        _emailSender = emailSender;
        _itemsRetriever = itemsRetriever;
        _logger = logger;
    }

    public void NotifyRecipients()
    {
        _logger.LogTrace("NotifyRecipients");
        var emailData = _itemsRetriever.GetEmailData();
        var emailBody = _emailBodyBuilder.GetEmailMessage(emailData);
        if (emailBody.Length == 0)
        {
            _logger.LogInformation("Nothing to send");
            return;
        }

        var emailMessage = _emailBuilder.GetEmailMessage(emailBody);
        var isSubmitted = _emailSender.SendEmail(emailMessage);
        if (isSubmitted)
            _logger.LogInformation("Sent email");
        else
            _logger.LogError("Unable to send email");
    }
}
