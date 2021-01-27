using BasicScoresheetLibrary.Helpers;
using BasicScoresheetLibrary.Models;
using CommonBasicStandardLibraries.CollectionClasses;
using Microsoft.JSInterop;
using System.Threading.Tasks;
namespace BasicScoresheetLibrary.StorageClasses
{
    public abstract class BaseCategoryScoreStorage : IBaseCategoryScoreStorage
    {
        private readonly IJSRuntime _js;

        public BaseCategoryScoreStorage(IJSRuntime js)
        {
            _js = js;
        }

        public virtual int MinimumPlayers => 5; //default to 5 but can be changed depending on game.
        public abstract string Title { get; }
        public abstract CustomBasicList<string> Categories { get; } //this is needed too.

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
            return await _js.GetPlayersAsync(MinimumPlayers, Categories.Count, Title);
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
