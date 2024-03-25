using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Q1.Repository;
namespace Q1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;
        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton(typeof(IEmpRepository), typeof(EmpRepository));
            services.AddSingleton<MainWindow>();
        }

        private void OnStartUp(object sender, StartupEventArgs e)
        {
            var MainWindow = serviceProvider.GetService<MainWindow>();
            MainWindow.Show();
        }
    }
}
