using System;
using System.Collections.Generic;
using System.Text;

namespace Electric.Core.DbSettings
{
    public interface IMongoDbSetting
    {
        string CollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
