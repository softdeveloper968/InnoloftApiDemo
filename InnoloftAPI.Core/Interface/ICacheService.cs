using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoloftAPI.Core.Interface
{
    public interface ICacheService
    {
        Task<string> GetValueAsync(string key);
        Task SetValueAsync(string key, string value);
        Task RemoveValueAsync(string key);
    }
}
