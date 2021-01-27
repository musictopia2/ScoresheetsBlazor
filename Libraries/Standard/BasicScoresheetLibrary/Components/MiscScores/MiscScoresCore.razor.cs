using BasicScoresheetLibrary.Models;
using BasicScoresheetLibrary.StorageClasses;
using CommonBasicStandardLibraries.CollectionClasses;
using CommonBasicStandardLibraries.Exceptions;
using CommonBasicStandardLibraries.MVVMFramework.UIHelpers;
using Microsoft.AspNetCore.Components;
using System.Linq;
namespace BasicScoresheetLibrary.Components.MiscScores
{
    public partial class MiscScoresCore
    {
        [Parameter]
        public bool ReadOnly { get; set; } = false;
        [Parameter]
        public CustomBasicList<PlayerModel> Players { get; set; } = new CustomBasicList<PlayerModel>();
        [Parameter]
        public EventCallback OnPersonChange { get; set; }
        [Parameter]
        public EventCallback OnScoreChange { get; set; }
        [Parameter]
        public EventCallback BackClicked { get; set; }
        [Parameter]
        public EventCallback ClearClicked { get; set; }
        [Parameter]
        public IMiscScoreStorage? ScoreStorage { get; set; }
        private void AddRow()
        {
            if (IsScoreFilled() == false)
            {
                ToastPlatform.ShowError("Must fill out the scores for at least one player before adding new row");
                return;
            }
            foreach (var player in Players)
            {
                player.Scores.Add(0); //will be 0 to start with for this row.
            }
            OnScoreChange.InvokeAsync(); //because you added another row.
        }
        private bool IsScoreFilled()
        {
            if (Players.Count == 0)
            {
                throw new BasicBlankException("Must have at least one player in order to fill the scores out");
            }
            foreach (var player in Players)
            {
                if (player.Scores.Last() is not 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}