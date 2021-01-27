using BasicScoresheetLibrary.ViewModels;
using Microsoft.AspNetCore.Components;
namespace BasicScoresheetLibrary.Components.Loaders
{
    public partial class BasicScoresheetDisplayLoaderComponent
    {
        [Inject]
        public IScorePageList? DataContext { get; set; } //this means more to register but that should be okay.
        [Inject]
        private NavigationManager? Navigates { get; set; }
        public void ChoseScore(string title)
        {
            //has to do without spaces though.
            //also has to show display at the end as well.
            string modified = title.Replace(" ", "");
            modified = $"{modified}display";
            Navigates!.NavigateTo(modified);
        }
    }
}