using BasicScoresheetLibrary.SignalRInterfaces;
using Microsoft.Extensions.DependencyInjection;
namespace ScoresheetSignalRLibrary
{
    public static class Extensions
    {
        public static void RegisterSignalRClasses(this IServiceCollection services)
        {
            services.AddTransient<IScoresheetBasicDisplayNetworking, ScoresheetBasicDisplayNetworkClass>();
            services.AddTransient<IScoresheetBasicInputNetworking, ScoresheetIBasicInputNetworkClass>();
        }
    }
}