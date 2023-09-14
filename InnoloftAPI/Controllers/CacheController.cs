using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace InnoloftAPI.Controllers
{
    [ApiController]
    [Route("api/cache")]
    public class CacheController : ControllerBase
    {
        private readonly IDistributedCache _cache;

        public CacheController(IDistributedCache cache)
        {
            _cache = cache;
        }

        [HttpGet("{key}")]
        public async Task<IActionResult> Get(string key)
        {
            try
            {
                var cachedValue = await _cache.GetStringAsync(key)
;
                if (cachedValue == null)
                {
                    return NotFound();
                }

                return Ok(cachedValue);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPost("{key}")]
        public async Task<IActionResult> Set(string key, [FromBody] string value)
        {
            try
            {
                await _cache.SetStringAsync(key, value);
                return Ok("Value set in cache successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete("{key}")]
        public IActionResult Delete(string key)
        {
            try
            {
                _cache.Remove(key)
;
                return Ok("Value removed from cache.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }

        }

    }
    }
