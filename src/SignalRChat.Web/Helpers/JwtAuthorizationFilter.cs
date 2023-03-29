using Microsoft.AspNetCore.Mvc.Filters;

namespace SignalRChat.Web.Helpers;

public class JwtAuthorizationFilter : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var request = context.HttpContext.Request;

        var hasBearerToken = request
            .Headers
            .Authorization
            .Contains("Bearer");

        if (!hasBearerToken) 
        {
            
        }

        throw new NotImplementedException();
    }
}
