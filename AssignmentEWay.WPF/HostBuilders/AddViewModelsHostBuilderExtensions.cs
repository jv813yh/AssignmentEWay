using AssignmentEWay.Data.Interfaces;
using AssignmentEWay.WPF.Commands;
using AssignmentEWay.WPF.Services;
using AssignmentEWay.WPF.Services.Interfaces;
using AssignmentEWay.WPF.States;
using AssignmentEWay.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVVMEssentials.Stores;

namespace AssignmentEWay.WPF.HostBuilders
{
    public static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices((context, services) =>
            {
                // Register HomeViewModel
                services.AddTransient<HomeViewModel>(services =>
                {
                    return  HomeViewModel.CreateAndLoadRecentContacts(
                        services.GetRequiredService<IEwayCrmService>(),
                        services.GetRequiredService<IDataHistoryService>(),
                        services.GetRequiredService<ContactStore>(),
                        services.GetRequiredService<NavigateCommand<InfoContantViewModel>>());
                });

                // Register NavigateCommand for home view model
                services.AddTransient<NavigateCommand<HomeViewModel>>(services =>
                {
                    return new NavigateCommand<HomeViewModel>(
                        new MyNavigationService<HomeViewModel>(
                            services.GetRequiredService<NavigationStore>(),
                            () => services.GetRequiredService<HomeViewModel>()));
                });

                // Register InfoContantViewModel
                services.AddTransient<InfoContantViewModel>(services =>
                {
                    return new InfoContantViewModel(
                        services.GetRequiredService<ContactStore>(),
                        services.GetRequiredService<NavigateCommand<HomeViewModel>>());
                });

                //Register NavigateCommand for info contant view model
                services.AddTransient<NavigateCommand<InfoContantViewModel>>(services =>
                {
                    return new NavigateCommand<InfoContantViewModel>(
                        new MyNavigationService<InfoContantViewModel>(
                            services.GetRequiredService<NavigationStore>(),
                            () => services.GetRequiredService<InfoContantViewModel>()));
                });
            });

            return hostBuilder;
        }
    }

}
