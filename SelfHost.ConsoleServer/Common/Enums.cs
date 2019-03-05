using SelfHost.ConsoleServer.Attributes;
using System.ComponentModel;

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
        [Description(CacheNames.OfferingsCache)]
        Offering,
        [Description(CacheNames.HeartbeatCache)]
        Heartbeat,
        [Description(CacheNames.EventsCache)]
        Events,
        [Description(CacheNames.AutoResponderCache)]
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
