using Flag.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flag.Core.Interfaces
{
    public interface IFeatureStore
    {
        FeatureFlag Get(string key);
        IEnumerable<FeatureFlag> GetAll();
    }
}
