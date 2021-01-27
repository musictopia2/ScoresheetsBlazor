using ChinazoScoresheetLibrary.StorageClasses;
using ChinazoScoresheetLibrary.ViewModels;
using Microsoft.Extensions.DependencyInjection;
namespace ChinazoScoresheetLibrary.Helpers
{
    public static class Extensions
    {
        public static void RegisterChinazoScores(this IServiceCollection services)
        {
            services.AddTransient<IChinazoViewModel, ChinazoViewModel>();
            services.AddTransient<IChinazoStorage, ChinazoStorage>();
        }
    }
}