using SelfHost.ConsoleServer.Common;

namespace SelfHost.ConsoleServer.Coherence
{
    public class ConnectionDataEvent<TKey, TValue>
    {
        public ConnectionDataEvent(CacheName cache, ConnectionDataAction action, TKey key, TValue cValue, TValue oValue)
        {
            Cache = cache;
            Action = action;
            Key = key;
            CurrentValue = cValue;
            OldValue = oValue;
        }

        public TKey Key { get; set; }
        public TValue CurrentValue { get; set; }
        public TValue OldValue { get; set; }
        public ConnectionDataAction Action { get; set; }
        public CacheName Cache { get; set; }
    }
}
