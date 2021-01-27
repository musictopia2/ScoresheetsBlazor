using CousinsScoresheetLibrary.Helpers;
using CousinsScoresheetLibrary.StorageClasses;
using Microsoft.AspNetCore.Components;
namespace CousinsScoresheetLibrary.Components
{
    public partial class CousinsInputComponent
    {
        [Inject]
        private ICousinsStorage? Storage { get; set; }
        protected override string Title => CousinsGlobalClass.Title;
    }
}