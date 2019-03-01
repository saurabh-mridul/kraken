using SelfHost.ConsoleServer.Coherence;

namespace SelfHost.ConsoleServer.Interfaces
{
    public interface ICacheListener
    {
        ConnectionDataEvent<string,string> CacheChanges { get; set; }
    }
}
