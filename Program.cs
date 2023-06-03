using BlazorOidcAuthentication.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    opt.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
}).AddCookie().AddOpenIdConnect("oidc", options =>
{
    options.Authority = "https://demo.identityserver.io/";
    options.ClientId = "interactive.confidential.short";
    options.ClientSecret = "secret";
    options.ResponseType = "code";
    options.SaveTokens = true;
    options.GetClaimsFromUserInfoEndpoint = true;
    options.UseTokenLifetime = false;
    options.Scope.Add("openid");
    options.Scope.Add("profile");
    options.TokenValidationParameters = new TokenValidationParameters { NameClaimType = "name" };
    options.Events = new OpenIdConnectEvents
    {
        OnAccessDenied = context =>
        {
            context.HandleResponse();
            context.Response.Redirect("/");
            return Task.CompletedTask;
        }
    };
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
