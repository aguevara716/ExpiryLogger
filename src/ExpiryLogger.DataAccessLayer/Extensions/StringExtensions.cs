using System.Security.Cryptography;
using System.Text;

namespace ExpiryLogger.DataAccessLayer.Extensions;

public static class StringExtensions
{
	public static string GetSha1Hash(string input)
	{
		using var sha1 = SHA1.Create();
		var inputBytes = Encoding.UTF8.GetBytes(input);
		var hashedBytes = sha1.ComputeHash(inputBytes);
		var hexString = Convert.ToHexString(hashedBytes);
		return hexString;
	}

}
