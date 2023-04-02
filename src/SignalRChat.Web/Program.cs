using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SignalRChat.Web.Controllers;
using SignalRChat.Web.Helpers;
using SignalRChat.Web.Infrastructure;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddInfrastructureLayer();

//builder.Services.AddAuthentication(opt =>
//{
//    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(jwt =>
//{
//    jwt.RequireHttpsMetadata = true;
//    jwt.SaveToken = true;

//    jwt.TokenValidationParameters = new TokenValidationParameters()
//    {
//        ValidateIssuerSigningKey = true,
//        IssuerSigningKey = new SymmetricSecurityKey(
//            Encoding.UTF8.GetBytes(JwtTokenHelpers.Key)
//            ),
//        ValidateAudience = false,
//        ValidateIssuer = false
//    };

//    jwt.Events = new JwtBearerEvents
//    {
//        OnTokenValidated = context =>
//        {
//            //TODO: get current user
//            return Task.CompletedTask;
//        },
//        OnForbidden = context =>
//        {
//            context.Response.Redirect("User/login");
//            context.Fail("failed");

//            return Task.CompletedTask;
//        },
//        OnMessageReceived = context =>
//        {
//            context.Token = context.Request.Cookies["Authorization"];

//            return Task.CompletedTask;
//        },
//        OnChallenge = context =>
//        {
//            if (!context.Request.Cookies.ContainsKey("Authorization"))
//            {
//                context.Response.Redirect("user/login");
//                context.HandleResponse();
//                return Task.CompletedTask;
//            }

//            return Task.CompletedTask;
//        }
//    };
//});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

//app.Filter

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Chat}/{action=Index}");

app.MapUserControllerRoutes();
app.MapHub<ChatHub>("/chathub");

app.Run();
