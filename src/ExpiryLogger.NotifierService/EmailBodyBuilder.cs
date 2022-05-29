using System.Text;
using Microsoft.Extensions.Logging;

namespace ExpiryLogger.NotifierService;

public interface IEmailBodyBuilder
{
    string GetEmailMessage(EmailData emailData);
}

public class EmailBodyBuilder : IEmailBodyBuilder
{
    private readonly ILogger<IEmailBodyBuilder> _logger;

    public EmailBodyBuilder(ILogger<IEmailBodyBuilder> logger)
    {
        _logger = logger;
    }

    public string GetEmailMessage(EmailData emailData)
    {
        _logger.LogTrace("GetEmailMessage(EmailData");
        ArgumentNullException.ThrowIfNull(emailData);

        var bodyBuilder = new StringBuilder();
        if (emailData.ExpiringThisMonth.Any())
        {
            _logger.LogTrace("Adding \"Expiring this month\"");
            bodyBuilder.AppendLine("Here are the products expiring this month:");
            bodyBuilder.AppendLine(string.Join(Environment.NewLine, emailData.ExpiringThisMonth.Select(pd => $"{pd.Name} - {pd.ExpirationDate:yyyy-MM-dd}")));
        }

        if (emailData.ExpiringThisWeek.Any())
        {
            _logger.LogTrace("Adding \"Expiring this week\"");
            bodyBuilder.AppendLine("Here are the products expiring this week:");
            bodyBuilder.AppendLine(string.Join(Environment.NewLine, emailData.ExpiringThisWeek.Select(pd => $"{pd.Name} - {pd.ExpirationDate:yyyy-MM-dd}")));
        }

        if (emailData.ExpiringToday.Any())
        {
            _logger.LogTrace("Adding \"Expiring today\"");
            bodyBuilder.AppendLine("Here are the products expiring today:");
            bodyBuilder.AppendLine(string.Join(Environment.NewLine, emailData.ExpiringToday.Select(pd => $"{pd.Name} - {pd.ExpirationDate:yyyy-MM-dd}")));
        }

        if (emailData.ExpiredThisMonth.Any())
        {
            _logger.LogTrace("Adding \"Already expired\"");
            bodyBuilder.AppendLine($"Here are the products that have already expired:");
            bodyBuilder.AppendLine(string.Join(Environment.NewLine, emailData.ExpiredThisMonth.Select(pd => $"{pd.Name} - {pd.ExpirationDate:yyyy-MMM-dd}")));
        }

        var body = bodyBuilder.ToString();
        _logger.LogInformation("Email body length: {emailBodyLength:N0}", body.Length);
        return body;
    }
}

