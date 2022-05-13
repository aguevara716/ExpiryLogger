using System.IdentityModel.Tokens.Jwt;
using System.Text;
using ExpiryLogger.Api.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ExpiryLogger.Api.Helpers;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly AppSettings _appSettings;

    public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
    {
        _next = next;
        _appSettings = appSettings.Value;
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
            var userId = int.Parse(jwtToken.Claims.First(t => t.Type == "id").Value);

            // attach user to context on successful jwt validation
            context.Items["User"] = userService.GetById(userId);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

}

