using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
namespace MainScoresheetOnline.Server.Hubs
{
    public class ScoreHub : Hub
    {
        public async Task RegisterGroupAsync(string group)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, group);
        }
        public async Task SendPlayersAsync(string group, string players) //bad news is the serializing/deserializing does not work.  therefore, has to be this way unfortunately.
        {
            await Clients.OthersInGroup(group).SendAsync("UpdatedPlayers", players);
        }


        public async Task SendScoresAsync(string group, string scores)
        {
            await Clients.OthersInGroup(group).SendAsync("UpdatedScores", scores);
        }

    }
}
