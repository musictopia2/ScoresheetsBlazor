using BasicScoresheetLibrary.Models;
using BasicScoresheetLibrary.StorageClasses;
using CommonBasicStandardLibraries.CollectionClasses;
using Microsoft.AspNetCore.Components;
namespace BasicScoresheetLibrary.Components.Core
{
    public abstract partial class BaseCategoryScoreComponent<S>
        where S : IBaseCategoryScoreStorage
    {
        [Parameter]
        public bool ReadOnly { get; set; } = false;
        [Parameter]
        public CustomBasicList<PlayerModel> Players { get; set; } = new CustomBasicList<PlayerModel>();
        [Parameter]
        public CustomBasicList<string> Categories { get; set; } = new CustomBasicList<string>();
        [Parameter]
        public EventCallback OnPersonChange { get; set; }
        [Parameter]
        public EventCallback OnScoreChange { get; set; }
        [Parameter]
        public EventCallback BackClicked { get; set; }
        [Parameter]
        public EventCallback ClearClicked { get; set; }
        [Parameter]
        public S? ScoreStorage { get; set; } //something else can be more specific.
        protected virtual string CategoryRowHeight => "28vmin"; //default at this but can change it if necessary (the chinazo requires more).
        protected virtual string TextSize => "5vmin";
        protected virtual string CellSize => "13vmin";
    }
}