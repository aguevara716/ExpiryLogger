using ExpiryLogger.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ExpiryLogger.Api.Helpers;

public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.Items["User"] as User;
        if (user is not null)
            return;

        var messageObject = new { message = "Unauthorized" };
        context.Result = new JsonResult(messageObject)
        {
            StatusCode = StatusCodes.Status401Unauthorized
        };
    }

}
