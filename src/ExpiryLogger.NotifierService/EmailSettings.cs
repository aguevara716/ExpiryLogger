namespace ExpiryLogger.NotifierService;

public class EmailSettings
{
	public string Username { get; init; }
	public string Password { get; init; }
	public string Host { get; init; }
	public ushort Port { get; init; }

	public EmailSettings()
	{
		Username = string.Empty;
		Password = string.Empty;
		Host = string.Empty;
		Port = ushort.MinValue;
	}
}
