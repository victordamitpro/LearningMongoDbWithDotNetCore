using System.Collections.Generic;
using System.Threading.Tasks;

namespace Electric.Core.Repositories
{
    public interface IDeviceRepository
    {
        Task<IEnumerable<Entities.Device>> GetAllDevice();
        Task<Entities.Device> GetDevide(string id);
        Task<Entities.Device> GetDeviceBySeriaNumber(string seriaNumber);
        Task<Entities.Device> UpdateDevice(Entities.Device electric);
        Task<string> CreateDevice(Entities.Device electric);
        Task<string> DeleteDevice(string id);
    }
}
