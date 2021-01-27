using BasicScoresheetLibrary.Helpers;
using BasicScoresheetLibrary.Models;
using CommonBasicStandardLibraries.CollectionClasses;
using System.Threading.Tasks;
namespace BasicScoresheetLibrary.SignalRInterfaces
{
    /// <summary>
    /// this will be used for offline mode.  for a version that will not even attempt to broadcast the scores to other devices.
    /// </summary>
    public class ScoresheetBasicOfflineNetworking : IScoresheetBasicInputNetworking
    {
        public string Title { get; set; } = "";
        public ValueTask DisposeAsync()
        {
            return ValueTask.CompletedTask;
        }
        public void Initialize()
        {
            BaseGlobalClass.NeedsRefresh = false; //because no signal r anyways.
        }
        public Task RegisterAsync()
        {
            return Task.CompletedTask;
        }
        public Task StartAsync()
        {
            return Task.CompletedTask;
        }
        public Task UpdatePlayersAsync(CustomBasicList<string> players)
        {
            return Task.CompletedTask;
        }
        public Task UpdateScoresAsync(CustomBasicList<PlayerModel> scores)
        {
            return Task.CompletedTask;
        }
    }
}