using Electric.Core.Entities;
using MongoDB.Driver;

namespace Electric.Infrastructure.Data.Interfaces
{
    public interface IElectricContext
    {
        IMongoCollection<Device> Devices { get; }
    }
}
