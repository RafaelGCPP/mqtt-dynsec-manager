using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using mqtt_dynsec_manager.Data;
using mqtt_dynsec_manager.DynSec;
using mqtt_dynsec_manager.DynSec.Interfaces;
using mqtt_dynsec_manager.Environment;
using mqtt_dynsec_manager.Models;
using MQTTnet;
using MQTTnet.Client;


var builder = WebApplication.CreateBuilder(args);

// Binding configurations

OracleDBConfig oraDbConfig = new();
MQTTConfig mqttConfig = new();
builder.Configuration.Bind("ORADB", oraDbConfig);
builder.Configuration.Bind("MQTT", mqttConfig);

// Preparing MQTT options
MqttClientOptionsBuilder mqttClientOptionsBuilder = new();
if (mqttConfig.WebSockets)
{
    mqttClientOptionsBuilder = mqttClientOptionsBuilder.WithWebSocketServer(mqttConfig.Host)
        .WithCredentials(mqttConfig.UserName, mqttConfig.Password);
}
else
{
    mqttClientOptionsBuilder = mqttClientOptionsBuilder.WithTcpServer(mqttConfig.Host)
        .WithCredentials(mqttConfig.UserName, mqttConfig.Password); ;
}

if (mqttConfig.Tls) mqttClientOptionsBuilder = mqttClientOptionsBuilder.WithTls();
var mqttClientOptions = mqttClientOptionsBuilder
    .WithClientId("mqtt-dynsec-manager")
    .WithCleanSession(true)
    .WithProtocolVersion(MQTTnet.Formatter.MqttProtocolVersion.V500)
    .Build();

builder.Services.AddSingleton(mqttClientOptions);

builder.Services.AddScoped<IMqttClient>(sp =>
{
    MqttClientOptions options = sp.GetRequiredService<MqttClientOptions>();
    MqttFactory mqttFactory = new();
    var client = mqttFactory.CreateMqttClient();
    client.ConnectAsync(options).Wait();
    return client;
});

builder.Services.AddScoped<IDynSec, DynSec>();

// Add services to the container.

builder.Services.AddSingleton(oraDbConfig);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(oraDbConfig.ConnectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentityServer()
    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

builder.Services.AddAuthentication()
    .AddIdentityServerJwt()
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

app.UseAuthentication();
app.UseIdentityServer();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");
app.MapRazorPages();

app.MapFallbackToFile("index.html");





app.Run();
