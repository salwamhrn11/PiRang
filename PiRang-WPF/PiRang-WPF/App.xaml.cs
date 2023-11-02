using Microsoft.Extensions.DependencyInjection;
using PiRang_WPF.Services;
using PiRang_WPF.View;
using PiRang_WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PiRang_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<StartWindow>(provider => new StartWindow
            {
                DataContext = provider.GetRequiredService<StartViewModel>()
            });

            services.AddSingleton<StartViewModel>();
            services.AddSingleton<LoginViewModel>();
            services.AddSingleton<RegisterViewModel>();
            services.AddSingleton<DashboardViewModel>();
            services.AddSingleton<BerandaViewModel>();
            
            services.AddSingleton<INavigationService, NavigationService>();

            services.AddSingleton<Func<Type, Core.ViewModel>>
                (serviceProvider => viewModelType => (Core.ViewModel)serviceProvider.GetRequiredService(viewModelType));

            _serviceProvider = services.BuildServiceProvider();

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var startWindow = _serviceProvider.GetRequiredService<StartWindow>();
            startWindow.Show();
            base.OnStartup(e);
        }
    }
}
