using AssignmentEWay.WPF.Commands;
using AssignmentEWay.WPF.HostBuilders;
using AssignmentEWay.WPF.Services;
using AssignmentEWay.WPF.Services.Interfaces;
using AssignmentEWay.WPF.States;
using AssignmentEWay.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVVMEssentials.Stores;
using MVVMEssentials.ViewModels;
using System.Windows;

namespace AssignmentEWay.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            // Create the host with custom builder
            _host = CreateHostBuilder()
                    .Build();
        }

        /// <summary>
        /// Create the host builder
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private static IHostBuilder CreateHostBuilder(string[] args = null)
        {
            return Host.CreateDefaultBuilder(args)
                        .AddServices()
                        .AddStores()
                        .AddViewModels();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Start the host
            _host.Start();

            // Get the required services
            var navigationStore = _host.Services.GetRequiredService<NavigationStore>();
            var modalNavigationStore = _host.Services.GetRequiredService<ModalNavigationStore>();
            var homeViewModel = _host.Services.GetRequiredService<HomeViewModel>();

            // Set the current view model to the home view model
            navigationStore.CurrentViewModel = homeViewModel;

            // Set data context for the main window
            var mainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore, modalNavigationStore)
            };

            // Show the main window
            mainWindow.Show();
        }

        protected async override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            // Stop the host
            await _host.StopAsync();
            // Dispose the host
            _host.Dispose();
        }
    }
}
