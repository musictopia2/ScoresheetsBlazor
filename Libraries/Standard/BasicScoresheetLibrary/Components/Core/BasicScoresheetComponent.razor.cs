using BasicBlazorLibrary.Components.NavigationMenus;
using BasicScoresheetLibrary.Models;
using BasicScoresheetLibrary.StorageClasses;
using CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.BasicExtensions;
using CommonBasicStandardLibraries.CollectionClasses;
using CommonBasicStandardLibraries.Exceptions;
using CommonBasicStandardLibraries.MVVMFramework.UIHelpers;
using Microsoft.AspNetCore.Components;
using System.Linq;
using System.Threading.Tasks;
using aa = BasicBlazorLibrary.Components.CssGrids.Helpers;
namespace BasicScoresheetLibrary.Components.Core
{
    public partial class BasicScoresheetComponent
    {
        [Parameter]
        public bool ReadOnly { get; set; } = false; //if readonly, then can't click anywhere to do any actions.  also will influence how the screen looks like.
        [Parameter]
        public CustomBasicList<string> Categories { get; set; } = new CustomBasicList<string>();
        [Parameter]
        public CustomBasicList<PlayerModel> Players { get; set; } = new CustomBasicList<PlayerModel>(); //i think for this version, minimum players will be the players set here.
        [Parameter]
        public EventCallback ClearClicked { get; set; }
        [Parameter]
        public EventCallback AddRowClicked { get; set; } //use logic to decide if i will have the button option.
        [Parameter]
        public EventCallback BackClicked { get; set; } //sometimes it has it and sometimes it does not.
        //needs to for now transfer to somebody else.
        /// <summary>
        /// if its readonly this would never be used.  the purpose of this would be so if anything changed, then can send via signal r in order to reflect
        /// </summary>
        [Parameter]
        public EventCallback OnPersonChange { get; set; }
        [Parameter]
        public EventCallback OnScoreChange { get; set; }
        [Parameter]
        public IScoreStorage? ScoreStorage { get; set; } //was going to use di here but decided that something else that uses it should be responsible for it.
        [Parameter]
        public string CategoryRowWidth { get; set; } = "28vmin";
        [Parameter]
        public string TextSize { get; set; } = "5vmin";
        [Parameter]
        public string CellSize { get; set; } = "13vmin";
        private bool _visible;
        private int _obtained;
        private int _indexworked = -1;
        private bool _needsConfirm = false;
        private PlayerModel? _player = null;
        private string _name = "";
        private string _category = "";
        private readonly CustomBasicList<MenuItem> _menus = new CustomBasicList<MenuItem>();
        //i think that this can handle the popup.  beats having lots of repeating code.
        private bool _needsDefaultPlayers;
        private bool _needsRefresh = true;
        private async Task RefreshScores()
        {
            await OnScoreChange.InvokeAsync();
            _needsRefresh = false;
        }
        protected override void OnInitialized()
        {
            _needsConfirm = false;
            _needsRefresh = true;
            _menus.Add(new MenuItem()
            {
                Text = "Default Players",
                Clicked = PrivateDefaultPlayerProcess
            });
            base.OnInitialized();
        }
        private void PrivateDefaultPlayerProcess()
        {
            _needsDefaultPlayers = true;
            StateHasChanged(); //maybe does need this afterall.
        }
        private void FinalConfirm(bool rets)
        {
            if (ReadOnly)
            {
                throw new BasicBlankException("Cannot clear because its read only");
            }
            _needsConfirm = false;
            if (rets == true)
            {
                if (ClearClicked.HasDelegate == false)
                {
                    throw new BasicBlankException("Did not register a clearclicked.");
                }
                ClearClicked.InvokeAsync();
            }
        }
        private int GetPlayerColumn(PlayerModel player)
        {
            int index = Players.IndexOf(player);
            if (Categories.Count == 0)
            {
                return index + 1;
            }
            return index + 2;
        }
        private string GetColumns
        {
            get
            {
                string lasts = aa.RepeatContentLength(Players.Count, CellSize);
                if (Categories.Count > 0)
                {
                    return $"{CategoryRowWidth} {lasts}";
                }
                return lasts;
            }
        }
        private void ShowPopup(int index, PlayerModel player, string category)
        {
            _player = player;
            _visible = true;
            _obtained = player.Scores[index];
            _name = _player.Name;
            _indexworked = index;
            _category = category;
        }
        private void ValueChanged(int value)
        {
            if (_player == null)
            {
                throw new BasicBlankException("Cannot change value because player was nothing");
            }
            if (_indexworked == -1)
            {
                throw new BasicBlankException("Cannot change value because index was not set");
            }
            _player.Scores[_indexworked] = value;
            if (OnScoreChange.HasDelegate)
            {
                OnScoreChange.InvokeAsync(); //so can be updated via signal r.
            }
        }
        private string GetRows => aa.RepeatAuto(Players.Count); //maybe do based on players now.
        private void RefreshPlayers(CustomBasicList<string> players)
        {
            if (players.Count != Players.Count)
            {
                throw new BasicBlankException("Player list does not reconcile when refreshing the players");
            }
            if (DidPlayersChange(players))
            {
                ChangePlayers(players);
                OnPersonChange.InvokeAsync(); //to notify anybody of this
            }
            _needsDefaultPlayers = false;
        }
        private void ChangePlayers(CustomBasicList<string> players)
        {
            var updates = GetEmptyPlayers();
            foreach (var player in updates)
            {
                int index = Players.IndexOf(player);
                string updated = players[index];
                if (string.IsNullOrWhiteSpace(updated) == false)
                {
                    player.Name = updated;
                }
            }
        }

        private CustomBasicList<PlayerModel> GetEmptyPlayers()
        {
            var updates = Players.Where(xxx => string.IsNullOrWhiteSpace(xxx.Name) == true).ToCustomBasicList(); //if already there, then can ignore.
            return updates;
        }

        private bool DidPlayersChange(CustomBasicList<string> players)
        {
            var updates = GetEmptyPlayers();
            foreach (var player in updates)
            {
                int index = Players.IndexOf(player);
                string updated = players[index];
                if (string.IsNullOrWhiteSpace(updated) == false)
                {
                    return true;
                }
            }
            return false;
        }
        private async Task SaveAsync()
        {
            await ScoreStorage!.SaveScoresAsync(Players);
            ToastPlatform.ShowInfo("Saved the scores successfully"); //even if its mock, i think the message should be here.
        }
    }
}