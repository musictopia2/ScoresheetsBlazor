using BasicScoresheetLibrary.Models;
using BasicScoresheetLibrary.SignalRInterfaces;
using CommonBasicStandardLibraries.CollectionClasses;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
namespace BasicScoresheetLibrary.Components.Core
{
    public abstract class BaseDisplayComponent : ComponentBase, IAsyncDisposable
    {
        [Inject]
        private IScoresheetBasicDisplayNetworking? Networks { get; set; } 
        protected abstract string Title { get; }
        protected CustomBasicList<PlayerModel> Players => Networks!.Players;
        protected override async Task OnInitializedAsync()
        {
            Networks!.StateHasChanged += Networks_StateHasChanged;
            Networks!.Title = Title;
            Networks!.Initialize();
            await Networks.StartAsync();
            await Networks.RegisterAsync();
        }
        private void Networks_StateHasChanged()
        {
            StateHasChanged();
        }
        public async ValueTask DisposeAsync()
        {
            await Networks!.DisposeAsync();
        }
    }
}