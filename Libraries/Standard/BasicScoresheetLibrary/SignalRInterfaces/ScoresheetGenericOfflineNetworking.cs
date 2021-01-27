using BasicScoresheetLibrary.Helpers;
using CommonBasicStandardLibraries.CollectionClasses;
using System.Threading.Tasks;
namespace BasicScoresheetLibrary.SignalRInterfaces
{
    public class ScoresheetGenericOfflineNetworking : IScoresheetGenericInputNetworking
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
        public Task UpdateScoresAsync(object scores)
        {
            return Task.CompletedTask;
        }
    }
}
