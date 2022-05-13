using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ExpiryLogger.Api.Entities;
using ExpiryLogger.Api.Helpers;
using ExpiryLogger.Api.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ExpiryLogger.Api.Services;

public interface IUserService
{
    AuthenticateResponse? Authenticate(AuthenticateRequest model);
    IEnumerable<User> GetAll();
    User? GetById(int id);
}

public class UserService : IUserService
{
    private readonly User[] _users = new[]
    {
        new User
        {
            Id = 1,
            FirstName = "Test",
            LastName = "User",
            Username = "test",
            Password = "test"
        }
    };
    private readonly AppSettings _appSettings;

    public UserService(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
    }

    public AuthenticateResponse? Authenticate(AuthenticateRequest model)
    {
        var user = _users.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);
        if (user is null)
            return null;

        var token = GenerateJwtToken(user);
        return new AuthenticateResponse(user, token);
    }

    private string GenerateJwtToken(User user)
    {
        // generate token that is valid for 7 days
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
            Expires = DateTime.UtcNow.AddDays(7.0),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);

        return tokenString;
    }

    public IEnumerable<User> GetAll()
    {
        return _users;
    }

    public User? GetById(int id)
    {
        return _users.FirstOrDefault(u => u.Id == id);
    }
}
