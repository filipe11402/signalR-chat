using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SignalRChat.Web.Controllers;

namespace SignalRChat.Web.Helpers;

public class JwtAuthorizationFilter : Attribute, IAuthorizationFilter
{
    private static string[] _excludablePaths = new string[] { "Login" };

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var request = context.HttpContext.Request;

        var hasBearerToken = request
            .Headers
            .Authorization
            .Contains("Bearer");

        if (_excludablePaths.Any(path => request.Path.Value.Contains(path))) { return; }

        if (!hasBearerToken)
        {
            context.Result = new RedirectToActionResult("Login", "User", default);

            return;
        }


        throw new NotImplementedException();
    }
}
