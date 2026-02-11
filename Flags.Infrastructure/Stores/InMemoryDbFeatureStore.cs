using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flags.Infrastructure.Stores
{
    public class InMemoryDbFeatureStore
    {
        public List<FeatureFlag> Load()
        {
            return new()
        {
            new FeatureFlag
            {
                Key = "NewDashboard",
                DefaultState = false,
                Overrides =
                {
                    new FeatureOverride
                    {
                        Type = OverrideType.Region,
                        Target = "IN",
                        IsEnabled = true
                    }
                }
            }
        };
        }
    }
}
