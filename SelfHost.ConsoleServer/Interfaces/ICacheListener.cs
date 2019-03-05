using SelfHost.ConsoleServer.Coherence;
using System;

namespace SelfHost.ConsoleServer.Interfaces
{
    public interface ICacheListener
    {
        IObservable<ConnectionDataEvent<string,string>> CacheChanges { get; set; }
    }
}
