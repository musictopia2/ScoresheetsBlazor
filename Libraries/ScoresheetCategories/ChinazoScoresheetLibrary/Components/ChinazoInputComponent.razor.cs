using ChinazoScoresheetLibrary.Helpers;
using ChinazoScoresheetLibrary.StorageClasses;
using Microsoft.AspNetCore.Components;
namespace ChinazoScoresheetLibrary.Components
{
    public partial class ChinazoInputComponent
    {
        [Inject]
        private IChinazoStorage? Storage { get; set; }
        protected override string Title => ChinazoGlobalClass.Title;
    }
}