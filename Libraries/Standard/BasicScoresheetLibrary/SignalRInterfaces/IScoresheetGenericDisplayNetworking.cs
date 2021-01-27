using System;
namespace BasicScoresheetLibrary.SignalRInterfaces
{
    public interface IScoresheetGenericDisplayNetworking : IScoresheetCoreNetworking
    {
        //event Action<string>? StateHasChanged;
        event Action<string>? PlayerChanged;
        event Action<string>? ScoresChanged;
    }
}