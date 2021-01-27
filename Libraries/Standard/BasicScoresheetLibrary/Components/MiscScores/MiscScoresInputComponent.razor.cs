using BasicScoresheetLibrary.Models;
using BasicScoresheetLibrary.StorageClasses;
using Microsoft.AspNetCore.Components;
namespace BasicScoresheetLibrary.Components.MiscScores
{
    public partial class MiscScoresInputComponent
    {
        protected override string Title => MiscScoresGlobalClass.Title;
        [Inject]
        private IMiscScoreStorage? Storage { get; set; } //for sure needs the miscscore one.
    }
}