using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Infrastructure.Cache.Redis
{
    public interface IRedisService
    {
        bool SetKey(string key, string value, double expireSecond);
        bool SetKey(string key, string value);
        string GetKey(string key);
    }
}
