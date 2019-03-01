namespace SelfHost.ConsoleServer.Coherence
{
    public class ConnectionDataEvent<TKey, TValue>
    {
        public enum ConnectionDataAction
        {
            Unknown,
            Added,
            Inserted,
            Updated
        }

        public ConnectionDataEvent(ConnectionDataAction action, TKey key, TValue cValue, TValue oValue)
        {
            Action = action;
            Key = key;
            CurrentValue = cValue;
            OldValue = oValue;
        }

        public TKey Key { get; set; }
        public TValue CurrentValue { get; set; }
        public TValue OldValue { get; set; }
        public ConnectionDataAction Action { get; set; }
    }
}
