using Microsoft.EntityFrameworkCore;
using Q2.Hubs;
using Q2.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSignalR();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<PRN221_Spr22Context>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));
builder.Services.AddScoped<PRN221_Spr22Context>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();
app.MapHub<SignR>("/abcd");
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();