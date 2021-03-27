using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDB_dot_net_demo.Configurations
{
    public class DeveloperDatabaseConfiguration
    {
        public string CustomerCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
