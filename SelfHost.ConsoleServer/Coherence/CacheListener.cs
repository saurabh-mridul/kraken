using System;
using SelfHost.ConsoleServer.Interfaces;

namespace SelfHost.ConsoleServer.Coherence
{
    public class CacheListener : ICacheListener
    {
        public CacheListener()
        {
            Initialize();
        }

        private void Initialize()
        {
          
        }

        public IObservable<ConnectionDataEvent<string, string>> CacheChanges { get; set; }
    }
}
