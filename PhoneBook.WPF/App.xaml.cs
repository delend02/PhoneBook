using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Application.Services;
using PhoneBook.WPF.Views.WindowViews;
using System.Windows;

namespace PhoneBook.WPF
{
    public partial class App : System.Windows.Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityServices();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
