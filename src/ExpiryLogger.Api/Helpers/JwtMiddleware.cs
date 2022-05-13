using System.IdentityModel.Tokens.Jwt;
using System.Text;
using ExpiryLogger.Api.Entities;
using ExpiryLogger.Api.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ExpiryLogger.Api.Helpers;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly AppSettings _appSettings;
    private readonly Dictionary<string, User> _userCache;

    public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
    {
        _next = next;
        _appSettings = appSettings.Value;
        _userCache = new Dictionary<string, User>();
    }

    public async Task Invoke(HttpContext context, IUserService userService)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        if (token is not null)
            AttachUserToContext(context, userService, token);
        await _next.Invoke(context);
    }

    private void AttachUserToContext(HttpContext context, IUserService userService, string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                // set ClockSkew to 0 so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var idClaim = jwtToken.Claims.First(t => t.Type.Equals(nameof(User.Id), StringComparison.InvariantCultureIgnoreCase));
            var userId = int.Parse(idClaim.Value);

            var user = GetUserFromCacheOrDatabase(token, userId, userService);
            context.Items["User"] = _userCache[token];
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    private User GetUserFromCacheOrDatabase(string token, int userId, IUserService userService)
    {
        if (_userCache.ContainsKey(token))
            return _userCache[token];

        var user = userService.GetById(userId);
        if (user is null)
            throw new Exception($"User with ID {userId} not found");

        _userCache.Add(token, user);
        return user;
    }

}

