using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Infrastructure.Cache.Redis
{
    public class RedisManager: IRedisService  
    {
        private readonly IConnectionMultiplexer _redisConnection;
        private readonly IDatabase _redisDB;
        public RedisManager(IConnectionMultiplexer redisConnection)
        {
            _redisConnection = redisConnection;
            _redisDB = redisConnection.GetDatabase();
        }

        public bool SetKey(string key,string value,double expireSecond)
        {

           return _redisDB.StringSet(key, value, TimeSpan.FromSeconds(expireSecond));
        }
        public bool SetKey(string key, string value)
        {

            return _redisDB.StringSet(key, value);
        }


        public string GetKey(string key)
        {

            return _redisDB.StringGet(key);
        }

    }
}
