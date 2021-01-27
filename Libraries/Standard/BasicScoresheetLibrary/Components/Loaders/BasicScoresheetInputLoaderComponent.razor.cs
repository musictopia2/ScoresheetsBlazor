using BasicBlazorLibrary.Helpers;
using BasicScoresheetLibrary.Helpers;
using BasicScoresheetLibrary.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BasicScoresheetLibrary.Components.Loaders
{
    public partial class BasicScoresheetInputLoaderComponent
    {
        [Inject]
        public ILoaderViewModel? DataContext { get; set; }

        private bool _loaded;

        protected override async Task OnInitializedAsync()
        {
            if (await JS!.ContainsKeyAsync(BaseGlobalClass.PreviousPageKey) == false)
            {
                DataContext!.CurrentPage = "";
            }
            else
            {
                DataContext!.CurrentPage = await JS!.StorageGetStringAsync(BaseGlobalClass.PreviousPageKey);
                DataContext.PopulateFragment(); //i think.
            }
            _loaded = true;
        }
        protected override void OnInitialized()
        {
            BaseGlobalClass.HasMainPage = true; //because you went through the loader.
            BaseGlobalClass.ReloadMainPage = () =>
            {
                DataContext!.CurrentPage = "";
                StateHasChanged();
            };

            base.OnInitialized();
        }
        private void ChoseScorePage(string title)
        {
            DataContext!.CurrentPage = title;
            DataContext.PopulateFragment();
        }
    }
}