using System.Net.Mail;
using ExpiryLogger.DataAccessLayer.Entities;
using ExpiryLogger.DataAccessLayer.Repositories;
using Microsoft.Extensions.Logging;

namespace ExpiryLogger.NotifierService;

public interface IEmailBuilder
{
	MailMessage GetEmailMessage(string body);
}

public class EmailBuilder : IEmailBuilder
{
	private readonly IEmailSettingsRetriever _emailSettingsRetriever;
	private readonly ILogger<IEmailBuilder> _logger;
	private readonly IRepository<User> _usersRepository;

	public EmailBuilder(IEmailSettingsRetriever emailSettingsRetriever, ILogger<IEmailBuilder> logger, IRepository<User> usersRepository)
	{
		_emailSettingsRetriever = emailSettingsRetriever;
		_logger = logger;
		_usersRepository = usersRepository;
	}

	public MailMessage GetEmailMessage(string body)
	{
		_logger.LogTrace("GetEmailMessage");
		var recipients = _usersRepository.Get(u => u.Username != "SYSTEM")?.Select(u => u.Username)?.ToList();
		if (recipients is null || !recipients.Any())
			throw new ApplicationException("There are no recipients in the users table");

        _logger.LogDebug("Found {recipientsCount:N0} recipients", recipients.Count);
		var recipientsString = string.Join(",", recipients);

		var emailSettings = _emailSettingsRetriever.GetEmailSettings();
		var mailMessage = new MailMessage(from: emailSettings.Username, to: recipientsString, subject: "Expiration Summary", body: body);
		return mailMessage;
	}
}
