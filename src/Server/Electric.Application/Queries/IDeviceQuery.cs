using Electric.Application.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Electric.Application.Queries
{
    public interface IDeviceQuery
    {
        Task<IEnumerable<DeviceResponse>> GetAlls();
        Task<DeviceResponse> GetDetail(string id);
        Task<DeviceResponse> GetDuplicateItems(string serialNumber);
    }
}
