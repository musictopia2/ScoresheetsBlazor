using BasicScoresheetLibrary.Models;
using CommonBasicStandardLibraries.CollectionClasses;
using System.Threading.Tasks;
namespace BasicScoresheetLibrary.SignalRInterfaces
{
    public interface IScoresheetBasicInputNetworking : IScoresheetCoreNetworking
    {
        Task UpdateScoresAsync(CustomBasicList<PlayerModel> scores);
        Task UpdatePlayersAsync(CustomBasicList<string> players);
    }
}