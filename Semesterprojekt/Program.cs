using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Semesterprojekt.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<ItemService, ItemService>();
builder.Services.AddSingleton<IItemService, ItemService>();
builder.Services.AddSingleton<IWorkshopService, WorkshopService>(); //singleton gør at når flere bruger gør den samme action er der kun et resultat pr. action, så hvis flere sletter den samme workshop bliver workshppen ku slettet en gang
builder.Services.AddSingleton<UserService, UserService>();
builder.Services.AddTransient<JsonFileWorkshopService>();
builder.Services.AddTransient<JasonFileOrdreService>();

builder.Services.Configure<CookiePolicyOptions>(options => {
    // This lambda determines whether user consent for non-essential cookies is needed for a given request. options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;

});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(cookieOptions => {
    cookieOptions.LoginPath = "/Login/LogInd";

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
app.UseAuthentication(); //Til at kunne logind
app.UseAuthorization();

app.MapRazorPages();

app.Run();
