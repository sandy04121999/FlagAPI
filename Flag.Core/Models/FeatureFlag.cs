using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flag.Core.Models
{
    public class FeatureFlag
    {
        public string Key { get; set; } = string.Empty;
        public bool DefaultState { get; set; }
        public List<FeatureOverride> Overrides { get; set; } = new();
    }
}
