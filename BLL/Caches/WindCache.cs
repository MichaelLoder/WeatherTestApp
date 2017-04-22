using System;
using System.Collections.Generic;
using System.Text;
using BLL.Interfaces;
using BO;
using Microsoft.Extensions.Caching.Memory;

namespace BLL.Caches
{
    public class WindCache : ICacheFacade<WindUnits, List<AggeratorResult>>
    {
        private readonly IMemoryCache _memoryCache;

        public WindCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public List<AggeratorResult> Get(WindUnits key)
        {
            var list = (List<AggeratorResult>)_memoryCache.Get(key);
            return list ?? new List<AggeratorResult>();
        }

        public void Add(WindUnits key, List<AggeratorResult> value)
        {
            _memoryCache.Set(key, value);
        }

        public void Update(WindUnits key, List<AggeratorResult> value)
        {
            throw new NotImplementedException();
        }
    }
}
