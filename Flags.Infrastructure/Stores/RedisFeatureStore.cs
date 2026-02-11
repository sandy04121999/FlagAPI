using Flag.Core.Interfaces;
using Flag.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flags.Infrastructure.Stores
{
    public class RedisFeatureStore : IFeatureStore
    {
        private readonly Dictionary<string, FeatureFlag> _cache;

        public RedisFeatureStore(InMemoryDbFeatureStore db)
        {
            // Simulate Redis warm-up from DB
            _cache = db.Load().ToDictionary(f => f.Key);
        }

        public FeatureFlag Get(string key) => _cache[key];
        public IEnumerable<FeatureFlag> GetAll() => _cache.Values;
    }
}
