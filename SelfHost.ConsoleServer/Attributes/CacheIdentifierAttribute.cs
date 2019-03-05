using System;

namespace SelfHost.ConsoleServer.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CacheIdentifierAttribute : Attribute
    {
        public CacheIdentifierAttribute(string cacheName)
        {

        }
    }
}
