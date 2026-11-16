using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jamera.Items.Stores;
using Jamera.Properties;
namespace Jamera.Collections
{
    public class AggrementsCollection
    {
        public AggrementsCollection() { }

        public String getRefPrefix(Store store)
        {
            String prefix = store.Ref_Prefix+Settings.Default.ref_prefix_year;
            return prefix;
        }
    }
}
