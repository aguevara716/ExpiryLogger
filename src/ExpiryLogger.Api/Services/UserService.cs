using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ExpiryLogger.Api.Helpers;
using ExpiryLogger.Api.Models;
using ExpiryLogger.DataAccessLayer.Entities;
using ExpiryLogger.DataAccessLayer.Extensions;
using ExpiryLogger.DataAccessLayer.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ExpiryLogger.Api.Services;

public interface IUserService
{
    AuthenticateResponse? Authenticate(AuthenticateRequest model);
    IEnumerable<User>? GetAll();
    User? GetById(int id);
}

public class UserService : IUserService
{
    private readonly AppSettings _appSettings;
    private readonly IRepository<User> _userRepository;

    public UserService(IOptions<AppSettings> appSettings, IRepository<User> userRepository)
    {
        _appSettings = appSettings.Value;
        _userRepository = userRepository;
    }

    public AuthenticateResponse? Authenticate(AuthenticateRequest model)
    {
        var hashedPassword = StringExtensions.GetSha1Hash(model.Password);
        var user = _userRepository.GetFirstOrDefault(u => u.Username == model.Username && u.HashedPassword.Equals(hashedPassword, StringComparison.OrdinalIgnoreCase));
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

    public IEnumerable<User>? GetAll()
    {
        return _userRepository.Get();
    }

    public User? GetById(int id)
    {
        return _userRepository.Get(id);
    }
}
