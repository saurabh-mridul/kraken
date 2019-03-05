namespace SelfHost.ConsoleServer.Common
{
    public enum DestinationEnum
    {
        CBOT,
        CME, 
        BBG, 
        TW
    }

    public enum CacheName
    {
        Offering,
        Heartbeat,
        Events,
        AutoResponder
    }

    public enum ConnectionDataAction
    {
        Unknown,
        Added,
        Inserted,
        Updated
    }

}
