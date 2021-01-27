using BasicBlazorLibrary.Helpers;
using BasicScoresheetLibrary.Models;
using BasicScoresheetLibrary.SignalRInterfaces;
using BasicScoresheetLibrary.StorageClasses;
using BasicScoresheetLibrary.ViewModels;
using CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.BasicExtensions;
using CommonBasicStandardLibraries.CollectionClasses;
using CommonBasicStandardLibraries.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using System.Threading.Tasks;
namespace BasicScoresheetLibrary.Helpers
{
    public static class Extensions
    {
        public static void RegisterOffline(this IServiceCollection services)
        {
            services.AddTransient<IScoresheetBasicInputNetworking, ScoresheetBasicOfflineNetworking>();
            services.AddTransient<IScoresheetGenericInputNetworking, ScoresheetGenericOfflineNetworking>();
        }
        public static void RegisterMiscScores(this IServiceCollection services)
        {
            services.AddTransient<IMiscScoreViewModel, MiscScoreViewModel>();
            services.AddTransient<IMiscScoreStorage, MiscScoreStorage>();
        }
        public static async Task SaveScoresAsync(this IJSRuntime js, string title, CustomBasicList<PlayerModel> players)
        {
            string key = $"saveddata{title}";
            await js.StorageSetItemAsync(key, players);
        }
        public static async Task DeleteScoresAsync(this IJSRuntime js, string title)
        {
            string key = $"saveddata{title}";
            if (await js.ContainsKeyAsync(key) == false)
                return;
            await js.StorageRemoveItemAsync(key);
        }
        public static async Task<bool> HasSavedScoresAsync(this IJSRuntime js, string title)
        {
            string key = $"saveddata{title}";
            return await js.ContainsKeyAsync(key);
        }
        public static async Task<CustomBasicList<PlayerModel>> GetPlayersAsync(this IJSRuntime js, int minimumPlayers, int scores, string title)
        {
            if (minimumPlayers == 0)
                throw new BasicBlankException("The minimum players cannot be 0");
            string key = $"saveddata{title}";
            CustomBasicList<PlayerModel> players = new CustomBasicList<PlayerModel>();
            if (await js.ContainsKeyAsync(key) == false)
                minimumPlayers.Times(xx =>
                {
                    PlayerModel player = new PlayerModel();
                    if (scores > 0)
                        scores.Times(yy =>
                        {
                            player.Scores.Add(0); //i think
                        });
                    players.Add(player); //forgot this part.
                });
            else
                players = await js.StorageGetItemAsync<CustomBasicList<PlayerModel>>(key);
            if (players.Count == 0)
                throw new BasicBlankException("Must have at least one player for getting players async");
            return players;
        }
        public static async Task SaveDefaultPlayersAsync(this IJSRuntime js, string title, CustomBasicList<string> players)
        {
            string key = $"defaultplayers{title}";
            await js.StorageSetItemAsync(key, players);
        }
        public static async Task<CustomBasicList<string>> GetDefaultPlayersAsync(this IJSRuntime js, int minimumPlayers, string title)
        {
            //if there is none, then just return a list of blank minimum players
            string key = $"defaultplayers{title}";
            CustomBasicList<string> output = new CustomBasicList<string>();
            if (await js.ContainsKeyAsync(key) == false)
                //this means to do a blank list
                minimumPlayers.Times(x =>
                {
                    output.Add("");
                });
            else
                output = await js.StorageGetItemAsync<CustomBasicList<string>>(key);
            return output;
        }
    }
}
