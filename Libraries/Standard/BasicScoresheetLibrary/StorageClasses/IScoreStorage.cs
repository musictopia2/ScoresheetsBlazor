using BasicScoresheetLibrary.Models;
using CommonBasicStandardLibraries.CollectionClasses;
using System.Threading.Tasks;
namespace BasicScoresheetLibrary.StorageClasses
{
    public interface IScoreStorage
    {
        int MinimumPlayers { get; } //this is still needed though.
        string Title { get; } //storage does need title.  does not care how it gets it.
        Task SaveDefaultPlayersAsync(CustomBasicList<string> players);
        Task SaveScoresAsync(CustomBasicList<PlayerModel> players);
        Task<CustomBasicList<string>> GetDefaultPlayersAsync();
        Task<CustomBasicList<PlayerModel>> GetSavedScoresAsync();
        Task DeleteScoresAsync();
        Task<bool> HasSavedScoresAsync(); //has to be async now.
    }
}