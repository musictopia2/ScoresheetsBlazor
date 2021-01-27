using BasicScoresheetLibrary.Models;
using CommonBasicStandardLibraries.CollectionClasses;
using System;
using System.Threading.Tasks;
namespace BasicScoresheetLibrary.SignalRInterfaces
{
    public interface IScoresheetBasicDisplayNetworking : IScoresheetCoreNetworking
    {
        //this is for the display portion.
        CustomBasicList<PlayerModel> Players { get; set; }
        event Action? StateHasChanged; //i think doing as event is fine for this time.
    }
}