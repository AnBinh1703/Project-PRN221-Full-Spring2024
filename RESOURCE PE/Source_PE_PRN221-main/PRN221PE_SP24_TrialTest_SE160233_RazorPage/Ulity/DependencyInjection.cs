using Microsoft.EntityFrameworkCore;
using PRN221PE_SP24_TrialTest_SE160233_Repo;
using PRN221PE_SP24_TrialTest_SE160233_Repo.Repo;

namespace PRN221PE_SP24_TrialTest_SE160233_RazorPage.Ulity
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddDbContext<Eyeglasses2024DBContext>(option => option.UseSqlServer(GetConnectionString()));
            return services;
        }
        private static string GetConnectionString()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", true, true)
                        .Build();
            var strConn = config["ConnectionStrings:Eyeglasses"];

            return strConn;
        }
    }
}
