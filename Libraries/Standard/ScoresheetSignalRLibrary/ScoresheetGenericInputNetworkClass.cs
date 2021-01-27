using BasicScoresheetLibrary.SignalRInterfaces;
using CommonBasicStandardLibraries.CollectionClasses;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System.Threading.Tasks;
using js = CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.JsonSerializers.NewtonJsonStrings;
namespace ScoresheetSignalRLibrary
{
    public class ScoresheetGenericInputNetworkClass : ScoresheetBaseNetworkClass, IScoresheetGenericInputNetworking
    {
        public ScoresheetGenericInputNetworkClass(NavigationManager navigation) : base(navigation)
        {
        }

        public override void Initialize()
        {
            BuildUp();
        }
        public async Task UpdatePlayersAsync(CustomBasicList<string> players)
        {
            string data = await js.SerializeObjectAsync(players);
            await Hub.SendAsync("SendPlayersAsync", Title, data);
        }
        public async Task UpdateScoresAsync(object scores)
        {
            string data = await js.SerializeObjectAsync(scores);
            await Hub.SendAsync("SendScoresAsync", Title, data); //if nobody is listening, will not care.
        }
    }
}
