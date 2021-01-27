using AllScoresLoaderLibrary;
using BasicScoresheetLibrary.Helpers;
using ChinazoScoresheetLibrary.Helpers;
using CousinsScoresheetLibrary.Helpers;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Threading.Tasks;
namespace MainScoresheetOfflinePWA
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.RegisterOffline();
            builder.Services.RegisterChinazoScores();
            builder.Services.RegisterCousinsScores();
            builder.Services.RegisterMiscScores();
            builder.Services.RegisterLoader();
            await builder.Build().RunAsync();
        }
    }
}