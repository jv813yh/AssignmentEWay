using AssignmentEWay.Data.Interfaces;
using AssignmentEWay.Data.Services;
using AssignmentEWay.Domain.Services;
using AssignmentEWay.Domain.Services.Interfaces;
using AssignmentEWay.WPF.Services;
using AssignmentEWay.WPF.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AssignmentEWay.WPF.HostBuilders
{
    public static class AddServicesHostBuilderExtensions
    {
        public static IHostBuilder AddServices(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices((context, services) =>
            {
                services.AddSingleton<IDataHistoryService, JsonDataServiceProvider>();
                services.AddSingleton<IEwayCrmService, EwayCrmProvider>();
                services.AddSingleton<IEwayService, EwayProvider>();
            });


            return hostBuilder;
        }
    }
}
