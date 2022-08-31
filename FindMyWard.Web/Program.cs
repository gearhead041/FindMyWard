using FindMyWard.DataAccess.Data;
using FindMyWard.DataAccess.Repository;
using FindMyWard.DataAccess.Repository.IRepository;
using FindMyWard.Utility;
using FindMyWard.Utility.IUtility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services
	.AddIdentity<IdentityUser,IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
	.AddEntityFrameworkStores<ApplicationDbContext>()
	.AddDefaultTokenProviders();

builder.Services.AddScoped<IAdmin,Admin>();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IEmailSender, EmailService>();
builder.Services.AddRazorPages();
builder.Services.AddAuthentication()
	.AddMicrosoftAccount(microsoftOptions =>
	{
		microsoftOptions.ClientId = builder.Configuration.GetSection("MicrosoftLogin")["ClientId"];
		microsoftOptions.ClientSecret = builder.Configuration.GetSection("MicrosoftLogin")["ClientSecret"];
		microsoftOptions.AuthorizationEndpoint = "https://login.microsoftonline.com/72ca12ad-1c5b-400e-a56e-de2f46920121/oauth2/v2.0/authorize";
		microsoftOptions.TokenEndpoint = "https://login.microsoftonline.com/72ca12ad-1c5b-400e-a56e-de2f46920121/oauth2/v2.0/token";
	})
	.AddGoogle(googleOptions =>
	{
		googleOptions.ClientId = builder.Configuration.GetSection("GoogleLogin")["ClientId"];
		googleOptions.ClientSecret = builder.Configuration.GetSection("GoogleLogin")["ClientSecret"];
	})
 ;

builder.Services.AddControllers().AddJsonOptions( x =>
	x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var twilioAccountSID = builder.Configuration.GetSection("Twilio")["AccountSID"];
var twilioAuthToken = builder.Configuration.GetSection("Twilio")["AuthToken"];
Environment.SetEnvironmentVariable("TWILIO_ACCOUNT_SID", twilioAccountSID);
Environment.SetEnvironmentVariable("TWILIO_AUTH_TOKEN", twilioAuthToken);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
}
else
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

app.MapRazorPages();
app.MapControllers();
app.Run();
