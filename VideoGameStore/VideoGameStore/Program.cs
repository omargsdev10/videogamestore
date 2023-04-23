using VGS.Repository.Interfaces;
using VGS.Repository.Repository;
using VGS.Service.Interfaces;
using VGS.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IVideoGameService, VideoGameService>();
builder.Services.AddScoped<IVideoGameRepository, VideoGameRepository>();
builder.Services.AddScoped<IConsoleService, ConsoleService>();
builder.Services.AddScoped<IConsoleRepository, ConsoleRepository>();
builder.Services.AddScoped<IGenderService, GenderService>();
builder.Services.AddScoped<IGenderRepository, GenderRepository>();

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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Store}/{action=Index}/{id?}");

app.Run();
