using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace ExpiryLogger.NotifierService;

public interface IEmailSettingsRetriever
{
    EmailSettings GetEmailSettings();
}

public class EmailSettingsRetriever : IEmailSettingsRetriever
{
    private readonly ILogger<EmailSettingsRetriever> _logger;
    private const string SETTINGS_FILENAME = "EmailSettings.json";

    public EmailSettingsRetriever(ILogger<EmailSettingsRetriever> logger)
    {
        _logger = logger;
    }

    public EmailSettings GetEmailSettings()
    {
        _logger.LogTrace("GetEmailSettings()");

        if (!File.Exists(SETTINGS_FILENAME))
            throw new FileNotFoundException("Email settings not found", SETTINGS_FILENAME);

        var jsonString = File.ReadAllText(SETTINGS_FILENAME);
        var emailSettings = JsonSerializer.Deserialize<EmailSettings>(jsonString)!;
        return emailSettings;
    }

}
