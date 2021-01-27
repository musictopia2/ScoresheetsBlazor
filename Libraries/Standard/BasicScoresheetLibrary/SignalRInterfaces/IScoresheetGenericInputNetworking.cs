using CommonBasicStandardLibraries.CollectionClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicScoresheetLibrary.SignalRInterfaces
{
    public interface IScoresheetGenericInputNetworking : IScoresheetCoreNetworking
    {
        Task UpdatePlayersAsync(CustomBasicList<string> players); //i think a list of players is still fine
        Task UpdateScoresAsync(object scores); //i think as object is fine this time.
    }
}
