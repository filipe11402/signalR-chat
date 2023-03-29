using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignalRChat.Web.Domain;
using SignalRChat.Web.Helpers;
using SignalRChat.Web.Requests;

namespace SignalRChat.Web.Controllers;

public class UserController : Controller
{
    private readonly IUserRepository _userRepository;

    public UserController(
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public IActionResult Index()
    {
        return View();
    }

    [Authorize]
    [HttpGet]
    public IActionResult Get(string Id)
    {
        return View();
    }

    [HttpGet]
    public IActionResult Login() 
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginUserRequest request) 
    {
        (Guid userId, string username) authenticateUserResult = (default, default);

        if (ModelState.IsValid) 
        {
            authenticateUserResult = await _userRepository
                .AuthenticateAsync(request.Username, request.Password);

            if (authenticateUserResult.username.Equals(string.Empty))
            {
                ModelState.AddModelError("", "Invalid information, either password or email are invalid");
            }

            SetJWTCookie(
                JwtTokenHelpers.GenerateToken(
                    authenticateUserResult.userId,
                    authenticateUserResult.username!));

            //TODO: return to user list
            return View(request);
        }

        ModelState.AddModelError("", "Invalid information, either password or email are invalid");

        return View(request);
    }

    private void SetJWTCookie(string token)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTimeOffset.UtcNow.AddHours(2)
        };

        Response.Cookies.Append("JWT", token, cookieOptions);
    }
}

public static class UserControllerExtensions 
{
    internal static void MapUserControllerRoutes(this IEndpointRouteBuilder builder)
    {
        builder.MapControllerRoute(
            name: "Get",
            pattern: "{controller=User}/{id}");

        builder.MapControllerRoute(
            name: "Loginuser",
            pattern: "{controller=User}/login");
    }
}
