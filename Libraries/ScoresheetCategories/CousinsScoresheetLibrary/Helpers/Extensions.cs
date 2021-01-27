using CousinsScoresheetLibrary.StorageClasses;
using CousinsScoresheetLibrary.ViewModels;
using Microsoft.Extensions.DependencyInjection;
namespace CousinsScoresheetLibrary.Helpers
{
    public static class Extensions
    {
        public static void RegisterCousinsScores(this IServiceCollection services)
        {
            services.AddTransient<ICousinsViewModel, CousinsViewModel>();
            services.AddTransient<ICousinsStorage, CousinsStorage>();
        }
    }
}