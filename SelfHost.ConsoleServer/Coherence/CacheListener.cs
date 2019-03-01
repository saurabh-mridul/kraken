using System;
using SelfHost.ConsoleServer.Interfaces;

namespace SelfHost.ConsoleServer.Coherence
{
    public class CacheListener : ICacheListener
    {
        public ConnectionDataEvent<string, string> CacheChanges { get; set; }
    }
}
