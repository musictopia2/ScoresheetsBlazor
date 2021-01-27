using BasicScoresheetLibrary.Models;
using BasicScoresheetLibrary.SignalRInterfaces;
using CommonBasicStandardLibraries.CollectionClasses;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using js = CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.JsonSerializers.NewtonJsonStrings;
namespace ScoresheetSignalRLibrary
{
    public class ScoresheetBasicDisplayNetworkClass : ScoresheetBaseNetworkClass, IScoresheetBasicDisplayNetworking
    {
        public ScoresheetBasicDisplayNetworkClass(NavigationManager navigation) : base(navigation) { }
        public CustomBasicList<PlayerModel> Players { get; set; } = new CustomBasicList<PlayerModel>();
        public event Action? StateHasChanged;
        public override void Initialize()
        {
            BuildUp();
            Hub!.On<string>("UpdatedPlayers", data =>
            {
                CustomBasicList<string> players = js.DeserializeObject<CustomBasicList<string>>(data);
                if (Players.Count != players.Count)
                {
                    return;
                }
                Players.ForEach(player =>
                {
                    int index = Players.IndexOf(player);
                    player.Name = players[index];
                });
                StateHasChanged?.Invoke();
            });
            Hub.On<string>("UpdatedScores", data =>
            {
                CustomBasicList<PlayerModel> scores = js.DeserializeObject<CustomBasicList<PlayerModel>>(data);
                Players = scores;
                StateHasChanged?.Invoke();
            });
        }
    }
}