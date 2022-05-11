using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Daekage_Server.Models
{
    public class DaekageDatabaseSettings : IDaekageDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string NoticesCollectionName { get; set; } = null!;
    }

    public interface IDaekageDatabaseSettings
    {
        string ConnectionString { get; set; }

        string DatabaseName { get; set; }

        string NoticesCollectionName { get; set; }
    }
}
