using InnoloftAPI.Core.Interface;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoloftAPI.Service.Service
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache _cache;

        public CacheService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<string> GetValueAsync(string key)
        {
            try
            {
                return await _cache.GetStringAsync(key)
;
            }
            catch (Exception ex)
            {
                // Handle exception
                throw new Exception($"Error getting cached value: {ex.Message}");
            }
        }

        public async Task SetValueAsync(string key, string value)
        {
            try
            {
                await _cache.SetStringAsync(key, value);
            }
            catch (Exception ex)
            {
                // Handle exception
                throw new Exception($"Error setting cached value: {ex.Message}");
            }
        }

        public async Task RemoveValueAsync(string key)
        {
            try
            {
                await _cache.RemoveAsync(key)
;
            }
            catch (Exception ex)
            {
                // Handle exception
                throw new Exception($"Error removing cached value: {ex.Message}");
            }
        }
    }
}
