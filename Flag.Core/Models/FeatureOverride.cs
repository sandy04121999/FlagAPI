using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flag.Core.Models
{
    public class FeatureOverride
    {
        public OverrideType Type { get; set; }
        public string Target { get; set; } = string.Empty;
        public bool IsEnabled { get; set; }
    }
}
