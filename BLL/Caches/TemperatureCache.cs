using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Text;
using BLL.Interfaces;
using BO;
using Microsoft.Extensions.Caching.Memory;
using MemoryCache = Microsoft.Extensions.Caching.Memory.MemoryCache;

namespace BLL.Caches
{
    public class TemperatureCache : ICacheFacade<TempUnits, List<AggeratorResult>>
    {
        private IMemoryCache _memoryCache;
        public TemperatureCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public List<AggeratorResult> Get(TempUnits key)
        {
            var list = (List<AggeratorResult>)_memoryCache.Get(key);
            return list ?? new List<AggeratorResult>();
        }

        public void Add(TempUnits key, List<AggeratorResult> value)
        {
            _memoryCache.Set(key, value);

        }

        public void Update(TempUnits key, List<AggeratorResult> value)
        {
            throw new NotImplementedException();
        }
    }
}
