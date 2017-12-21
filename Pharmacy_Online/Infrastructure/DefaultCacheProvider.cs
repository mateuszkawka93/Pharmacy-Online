using System;
using System.Web;
using Cache = System.Web.Caching.Cache;

namespace Pharmacy_Online.Infrastructure
{
    public class DefaultCacheProvider : ICacheProvider
    {
        private Cache cache { get { return HttpContext.Current.Cache; } }

        public object Get(string key)
        {
            return cache[key];
        }

        public void Set(string key, object data, int cacheTime)
        {
            var expirationTime = DateTime.Now + TimeSpan.FromMinutes(cacheTime);
            cache.Insert(key, data, null, expirationTime, Cache.NoSlidingExpiration);
        }

        public bool IsSet(string key)
        {
            return cache[key] != null;
        }

        public void Invalidate(string key)
        {
            cache.Remove(key);
        }
    }
}