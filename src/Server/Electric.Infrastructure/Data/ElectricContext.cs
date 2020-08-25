using Electric.Core.DbSettings;
using Electric.Core.Entities;
using Electric.Infrastructure.Data.Interfaces;
using MongoDB.Driver;

namespace Electric.Infrastructure.Data
{
    public class ElectricContext : IElectricContext
    {
        public ElectricContext(IMongoDbSetting settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            Devices = database.GetCollection<Device>(settings.CollectionName);
            ElectricContextSeedData.SeedData(Devices);
        }

        public IMongoCollection<Device> Devices { get; }
    }
}
