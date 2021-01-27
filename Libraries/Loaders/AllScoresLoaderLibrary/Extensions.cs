using BasicScoresheetLibrary.ViewModels;
using Microsoft.Extensions.DependencyInjection;
namespace AllScoresLoaderLibrary
{
    public static class Extensions
    {
        public static void RegisterLoader(this IServiceCollection services)
        {
            services.AddTransient<IScorePageList, LoaderViewModel>();
            services.AddTransient<ILoaderViewModel, LoaderViewModel>();
        }
    }
}