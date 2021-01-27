using BasicScoresheetLibrary.StorageClasses;
using CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.BasicExtensions;
using CommonBasicStandardLibraries.CollectionClasses;
using CommonBasicStandardLibraries.Exceptions;
using CommonBasicStandardLibraries.MVVMFramework.UIHelpers;
using Microsoft.AspNetCore.Components;
using System.Linq;
using System.Threading.Tasks;
namespace BasicScoresheetLibrary.Components.Modals
{
    public partial class DefaultPlayerPopup
    {
        private class PlayerClass
        {
            public string Name { get; set; } = "";

        }

        [Parameter]
        public IScoreStorage? ScoreStorage { get; set; }

        [Parameter]
        public EventCallback<CustomBasicList<string>> OnSaveAsync { get; set; } //this is the new player list.

        //this will save.  however, the old scores will not change.

        [Parameter]
        public EventCallback OnCancelAsync { get; set; }

        private readonly CustomBasicList<PlayerClass> _players = new CustomBasicList<PlayerClass>();

        protected override void OnInitialized()
        {
            if (ScoreStorage != null)
                ScoreStorage!.MinimumPlayers.Times(xxx => _players.Add(new PlayerClass()));
            base.OnInitialized();
        }

        private async Task SavePlayersAsync()
        {
            if (ScoreStorage == null)
                throw new BasicBlankException("Did not set the score storage");
            CustomBasicList<string> players = _players.Select(xxx => xxx.Name).ToCustomBasicList();
            await ScoreStorage.SaveDefaultPlayersAsync(players);
            ToastPlatform.ShowInfo("Saved default players"); //this is what i would always do though.
            await OnSaveAsync.InvokeAsync(players); //so something else will have to decide what to do.
        }

        //i think this one will be a centered one.
        //since we have the x button, i think i should use the standard one.


    }
}