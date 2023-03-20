using Challenge.SharedKernel.Repositories;
using StackExchange.Redis;
using System.Text.Json;

namespace Challenge.Infra.Data.Repositories
{
    public class CacheRepository : ICacheRepository
    {
        IConnectionMultiplexer Connection { get; }

        IDatabase Database { get; }

        public CacheRepository(IConnectionMultiplexer connection)
        {
            Connection = connection;
            Database = connection.GetDatabase();
        }
        public async Task<T?> GetAsync<T>(string key)
        {
            var value = await Database.StringGetAsync(key);

            if (value.IsNull) return default; 

            return JsonSerializer.Deserialize<T>(value.ToString());
        }

        public async Task SetAsync<T>(string key, T value)
        {
            var json = JsonSerializer.Serialize(value);
            await Database.StringSetAsync(key, json);
        }
    }
}
