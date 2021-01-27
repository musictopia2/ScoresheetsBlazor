using BasicScoresheetLibrary.Models;
using BasicScoresheetLibrary.StorageClasses;
using CommonBasicStandardLibraries.CollectionClasses;
using CommonBasicStandardLibraries.Exceptions;
using System.Threading.Tasks;
namespace BasicScoresheetLibrary.ViewModels
{
    public class MiscScoreViewModel : IMiscScoreViewModel
    {
        private readonly IMiscScoreStorage _storage;
        public MiscScoreViewModel(IMiscScoreStorage storage)
        {
            _storage = storage;
        }
        public CustomBasicList<PlayerModel> Players { get; private set; } = new CustomBasicList<PlayerModel>();
        public async Task ClearScoresAsync()
        {
            Players.ForEach(player =>
            {
                player.Scores.Clear();
                player.Scores.Add(0); //just one.
            });
            await _storage.DeleteScoresAsync();
        }
        public async Task InitPlayersAsync()
        {
            Players = await _storage.GetSavedScoresAsync();
            if (Players.Count == 0)
                throw new BasicBlankException("There has to be at least 1 player");
            if (await _storage.HasSavedScoresAsync() == false)
            {
                CustomBasicList<string> players = await _storage.GetDefaultPlayersAsync();
                if (players.Count != Players.Count)
                    throw new BasicBlankException("Did not reconcile the players for init players async");
                int index = 0;
                foreach (var player in Players)
                {
                    string data = players[index];
                    player.Name = data;
                    index++;
                }
            }
        }
    }
}