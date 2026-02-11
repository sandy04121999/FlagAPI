using FeatureFlags.Core.Models;
using FeatureFlags.Core.Services;
using FeatureFlags.Infrastructure.Stores;
using Flag.Core.Services;
using Flags.Infrastructure.Stores;
using Xunit;

namespace Flags.Tests
{
    public class FeatureEvaluatorTests
    {
        [Fact]
        public void Region_override_wins_over_default()
        {
            var db = new InMemoryDbFeatureStore();
            var store = new RedisFeatureStore(db);
            var evaluator = new FeatureEvaluator(store);

            var enabled = evaluator.IsEnabled(
                "NewDashboard",
                user: null,
                group: null,
                region: "IN");

            Assert.IsTrue(enabled);
        }
    }

}
