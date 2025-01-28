using AssignmentEWay.WPF.States;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVVMEssentials.Stores;

namespace AssignmentEWay.WPF.HostBuilders
{
    public static class AddStoresHostBuilderExtensions
    {
        public static IHostBuilder AddStores(this IHostBuilder hostBuilder)
        {

            hostBuilder.ConfigureServices((context, services) =>
            {
                services.AddSingleton<ContactStore>();
                services.AddSingleton<NavigationStore>();
                services.AddSingleton<ModalNavigationStore>();
            });


            return hostBuilder;
        }
    }
}
