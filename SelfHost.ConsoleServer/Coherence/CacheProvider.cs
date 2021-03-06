﻿using Newtonsoft.Json;
using System.Collections.Generic;
using Tangosol.Net;
using Tangosol.Util;
using Tangosol.Util.Extractor;

namespace SelfHost.ConsoleServer.Coherence
{
    public class CacheProvider
    {
        public static IEnumerable<TValue> GetSnapshot<TValue>(string cacheName)
        {
            var values = CacheFactory.GetCache(cacheName).GetValues(null);
            yield return JsonConvert.DeserializeObject<TValue>(values.ToString());
        }

        public static TValue GetEntry<TValue>(string cacheName, string key)
        {
            IValueExtractor extractor = new KeyExtractor(IdentityExtractor.Instance);
            IFilter filter = null;
            var entry = CacheFactory.GetCache(cacheName).GetValues(filter);
            return entry != null
                ? JsonConvert.DeserializeObject<TValue>(entry.ToString())
                : default(TValue);
        }

        public static void Add<TKey, TValue>(string cacheName, TKey key, TValue value)
        {
            CacheFactory.GetCache(cacheName).Add(key, value);
        }

        public static void Insert<TKey, TValue>(string cacheName, TKey key, TValue value)
        {
            CacheFactory.GetCache(cacheName).Insert(key, value);
        }

        public static void Remove<TKey>(string cacheName, TKey key)
        {
            CacheFactory.GetCache(cacheName).Remove(key);
        }
    }
}
