using Rpository;

namespace Equipments_AnDB
{
    public class Program
    {
        public static void Main(string[] args)
        {
 

            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddSession();
            builder.Services.AddHttpClient();
            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
            builder.Services.AddTransient<AccountRepository>();
            builder.Services.AddTransient<RoomRepository>();
            builder.Services.AddTransient<EquipmentRepository>();




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSession();
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();

        }
    }
}