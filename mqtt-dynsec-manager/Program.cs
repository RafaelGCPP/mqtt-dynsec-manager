using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using mqtt_dynsec_manager.Data;
using mqtt_dynsec_manager.DynSec;
using mqtt_dynsec_manager.DynSec.Interfaces;
using mqtt_dynsec_manager.Environment;
using mqtt_dynsec_manager.Helpers;
using mqtt_dynsec_manager.Models;
using MQTTnet;
using MQTTnet.Client;
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);

// Binding configurations

OracleDBConfig oraDbConfig = new();
MQTTConfig mqttConfig = new();
CertificateConfig certificateConfig = new();
builder.Configuration.Bind("ORADB", oraDbConfig);
builder.Configuration.Bind("MQTT", mqttConfig);
builder.Configuration.Bind("Certificate", certificateConfig);

builder.Services.AddSingleton(oraDbConfig);
builder.Services.AddSingleton(certificateConfig);
builder.Services.AddSingleton(mqttConfig);

var keyConfig = builder.Configuration.GetSection("IdentityServer:Key");

keyConfig.GetSection("Type").Value = "File";
keyConfig.GetSection("FilePath").Value = certificateConfig.Path;
keyConfig.GetSection("Password").Value = certificateConfig.Password;

// Preparing MQTT options
builder.Services.AddMqttOptions(mqttConfig);

builder.Services.AddMqttClient();
builder.Services.AddScoped<IDynSec, DynSec>();

// Add services to the container.


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(oraDbConfig.ConnectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

X509Certificate2 certificate = new(certificateConfig.Path, certificateConfig.Password);

builder.Services.AddIdentityServer(options =>
{
    // set path where to store keys
    options.KeyManagement.KeyPath = "/opt/keys";

    // new key every 30 days
    options.KeyManagement.RotationInterval = TimeSpan.FromDays(30);

    // announce new key 2 days in advance in discovery
    options.KeyManagement.PropagationTime = TimeSpan.FromDays(2);

    // keep old key for 7 days in discovery for validation of tokens
    options.KeyManagement.RetentionDuration = TimeSpan.FromDays(7);
})
    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>()
    //.AddSigningCredential(new X509SigningCredentials(certificate))
    ;


builder.Services.AddAuthentication()
    .AddIdentityServerJwt()
    .AddCookie("cookies", options =>
    {
        options.Cookie.Name = "appcookie";
        options.Cookie.SameSite = SameSiteMode.Strict;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    })
    ;
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();

}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCookiePolicy(new CookiePolicyOptions
{
    HttpOnly = HttpOnlyPolicy.Always,
    MinimumSameSitePolicy = SameSiteMode.None,
    Secure = CookieSecurePolicy.Always
});
app.UseAuthentication();

app.UseIdentityServer();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");
app.MapRazorPages();

app.MapFallbackToFile("index.html");





app.Run();
