using BasicScoresheetLibrary.Helpers;
using BasicScoresheetLibrary.Models;
using CommonBasicStandardLibraries.CollectionClasses;
using Microsoft.JSInterop;
using System.Threading.Tasks;
namespace BasicScoresheetLibrary.StorageClasses
{
    public class MiscScoreStorage : IScoreStorage, IMiscScoreStorage
    {
        private readonly IJSRuntime _js;
        public MiscScoreStorage(IJSRuntime js)
        {
            _js = js;
        }
        public int MinimumPlayers => 7; //i think 7 players can be allowed
        public string Title => MiscScoresGlobalClass.Title;
        public async Task DeleteScoresAsync()
        {
            await _js.DeleteScoresAsync(Title);
        }
        public async Task<CustomBasicList<string>> GetDefaultPlayersAsync()
        {
            return await _js.GetDefaultPlayersAsync(MinimumPlayers, Title);
        }
        public async Task<CustomBasicList<PlayerModel>> GetSavedScoresAsync()
        {
            return await _js.GetPlayersAsync(MinimumPlayers, 1, Title); //obviously needs at least one.
        }
        public async Task<bool> HasSavedScoresAsync()
        {
            return await _js.HasSavedScoresAsync(Title);
        }
        public async Task SaveDefaultPlayersAsync(CustomBasicList<string> players)
        {
            await _js.SaveDefaultPlayersAsync(Title, players);
        }
        public async Task SaveScoresAsync(CustomBasicList<PlayerModel> players)
        {
            await _js.SaveScoresAsync(Title, players);
        }
    }
}