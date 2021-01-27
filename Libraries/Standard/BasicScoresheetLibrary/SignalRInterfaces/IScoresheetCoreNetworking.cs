using System;
using System.Threading.Tasks;
namespace BasicScoresheetLibrary.SignalRInterfaces
{
    public interface IScoresheetCoreNetworking : IAsyncDisposable
    {
        void Initialize();
        Task StartAsync();
        string Title { get; set; } //something can set the title here.
        Task RegisterAsync(); //this will register.
    }
}