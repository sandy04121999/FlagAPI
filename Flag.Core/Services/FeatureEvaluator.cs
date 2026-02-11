using Flag.Core.Interfaces;
using Flag.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flag.Core.Services
{
    public class FeatureEvaluator
    {
        private readonly IFeatureStore _store;

        public FeatureEvaluator(IFeatureStore store)
        {
            _store = store;
        }

        // Precedence: User → Group → Region → Default
        public bool IsEnabled(
            string key,
            string? user,
            string? group,
            string? region)
        {
            var feature = _store.Get(key);

            var match = feature.Overrides
                .OrderBy(o => (int)o.Type)
                .FirstOrDefault(o =>
                    (o.Type == OverrideType.User && o.Target == user) ||
                    (o.Type == OverrideType.Group && o.Target == group) ||
                    (o.Type == OverrideType.Region && o.Target == region));

            return match?.IsEnabled ?? feature.DefaultState;
        }
    }
}
