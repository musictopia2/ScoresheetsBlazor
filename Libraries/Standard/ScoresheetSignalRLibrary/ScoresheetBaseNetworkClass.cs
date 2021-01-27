using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoresheetSignalRLibrary
{
    public abstract class ScoresheetBaseNetworkClass : IAsyncDisposable
    {

        public ScoresheetBaseNetworkClass(NavigationManager navigation)
        {
            _navigation = navigation;
        }
        public string Title { get; set; } = ""; //for now, just title is needed.  may change later.
        protected HubConnection? Hub;
        private readonly NavigationManager _navigation; //decided to make it as simple as possible this time.

        protected void BuildUp()
        {
            Hub = new HubConnectionBuilder()
              .WithUrl(_navigation!.ToAbsoluteUri("/scorehub"))
              .Build();
        }

        public abstract void Initialize();
        public async Task RegisterAsync()
        {
            await Hub.SendAsync("RegisterGroupAsync", Title);
        }
        public async Task StartAsync()
        {
            await Hub!.StartAsync();
        }
        public async ValueTask DisposeAsync()
        {
            await Hub!.DisposeAsync();
        }
    }
}
