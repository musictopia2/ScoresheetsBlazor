using BasicBlazorLibrary.Components.BaseClasses;
using BasicBlazorLibrary.Helpers;
using BasicScoresheetLibrary.Helpers;
using BasicScoresheetLibrary.SignalRInterfaces;
using BasicScoresheetLibrary.ViewModels;
using CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.BasicExtensions;
using CommonBasicStandardLibraries.CollectionClasses;
using CommonBasicStandardLibraries.Exceptions;
using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace BasicScoresheetLibrary.Components.Core
{
    public abstract class BaseInputComponent<V> : JavascriptComponentBase, IAsyncDisposable
        where V : IScoreViewModel
    {
        [Inject]
        private IScoresheetBasicInputNetworking? Networks { get; set; }
        [Inject]
        protected V? DataContext { get; set; }
        protected abstract string Title { get; }
        protected override async Task OnInitializedAsync()
        {
            await DataContext!.InitPlayersAsync();
            await JS!.StorageSetStringAsync(BaseGlobalClass.PreviousPageKey, Title); //this is what the previous page was.  this will help to make sure it can reload the proper page.
            Networks!.Title = Title;
            Networks!.Initialize();
            await Networks.StartAsync();
            await Networks.RegisterAsync();
        }
        protected async Task ClearAsync()
        {
            await DataContext!.ClearScoresAsync();
            await UpdateScoresAsync();
        }
        protected async Task UpdateScoresAsync()
        {
            await Networks!.UpdateScoresAsync(DataContext!.Players);
        }
        protected async Task UpdatePlayersAsync()
        {
            CustomBasicList<string> players = DataContext!.Players.Select(xxx => xxx.Name).ToCustomBasicList();
            await Networks!.UpdatePlayersAsync(players);
        }
        protected async Task BackClickedAsync()
        {
            if (BaseGlobalClass.HasMainPage == false)
            {
                throw new BasicBlankException("There was no main page.  Therefore, should not have allowed the back clicked");
            }
            if (BaseGlobalClass.ReloadMainPage == null)
            {
                throw new BasicBlankException("Nobody is handling the reloading of the main page");
            }
            await JS!.StorageRemoveItemAsync(BaseGlobalClass.PreviousPageKey); //has to remove from storage
            BaseGlobalClass.ReloadMainPage.Invoke();
        }
        public async ValueTask DisposeAsync()
        {
            await Networks!.DisposeAsync();
        }
    }
}