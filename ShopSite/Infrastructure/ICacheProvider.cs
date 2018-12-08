using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSite.Infrastructure
{
    public interface ICacheProvider
    {
        // Interface to maintain key methods in cache classes
        object Get(string key);
        void Set(string key, object data, int cacheTime);
        bool IsSet(string key);
        void Invalidate(string key);
    }
}
