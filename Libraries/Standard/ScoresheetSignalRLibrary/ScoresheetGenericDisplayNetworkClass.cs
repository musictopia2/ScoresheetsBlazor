using BasicScoresheetLibrary.SignalRInterfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System;
namespace ScoresheetSignalRLibrary
{
    public class ScoresheetGenericDisplayNetworkClass : ScoresheetBaseNetworkClass, IScoresheetGenericDisplayNetworking
    {
        public ScoresheetGenericDisplayNetworkClass(NavigationManager navigation) : base(navigation)
        {
        }
        public event Action<string>? PlayerChanged;
        public event Action<string>? ScoresChanged;
        public override void Initialize()
        {
            BuildUp();
            Hub!.On<string>("UpdatedPlayers", data =>
            {
                PlayerChanged?.Invoke(data); //this time has to pass on the data it received.  since this does not know what objects its going to be or even how to compare.
            });
            Hub.On<string>("UpdatedScores", data =>
            {
                ScoresChanged?.Invoke(data); //this tiem has to pass on the data it received.  since this time does not know what objects its going to be.
            });
        }
    }
}