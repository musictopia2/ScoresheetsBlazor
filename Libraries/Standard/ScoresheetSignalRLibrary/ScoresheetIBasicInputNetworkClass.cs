using BasicScoresheetLibrary.Models;
using BasicScoresheetLibrary.SignalRInterfaces;
using CommonBasicStandardLibraries.CollectionClasses;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System.Threading.Tasks;
using js = CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.JsonSerializers.NewtonJsonStrings;
namespace ScoresheetSignalRLibrary
{
    public class ScoresheetIBasicInputNetworkClass : ScoresheetBaseNetworkClass, IScoresheetBasicInputNetworking
    {
        public ScoresheetIBasicInputNetworkClass(NavigationManager navigation) : base(navigation) { }
        public override void Initialize()
        {
            BuildUp();
        }
        public async Task UpdatePlayersAsync(CustomBasicList<string> players)
        {
            string data = await js.SerializeObjectAsync(players);
            await Hub.SendAsync("SendPlayersAsync", Title, data);
        }
        public async Task UpdateScoresAsync(CustomBasicList<PlayerModel> scores)
        {
            string data = await js.SerializeObjectAsync(scores);
            await Hub.SendAsync("SendScoresAsync", Title, data); //if nobody is listening, will not care.
        }
    }
}