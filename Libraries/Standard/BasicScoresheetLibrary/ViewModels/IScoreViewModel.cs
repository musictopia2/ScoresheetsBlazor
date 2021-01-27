using BasicScoresheetLibrary.Models;
using CommonBasicStandardLibraries.CollectionClasses;
using System.Threading.Tasks;
namespace BasicScoresheetLibrary.ViewModels
{
    public interface IScoreViewModel
    {
        CustomBasicList<PlayerModel> Players { get; }
        Task ClearScoresAsync();
        Task InitPlayersAsync();
    }
}