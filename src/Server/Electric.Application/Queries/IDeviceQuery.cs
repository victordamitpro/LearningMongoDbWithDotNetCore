using Electric.Application.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Electric.Application.Queries
{
    public interface IDeviceQuery
    {
        Task<IEnumerable<DeviceResponse>> GetAlls();
        Task<DeviceResponse> GetDetailElectric(string id);
        Task<DeviceResponse> GetDetailWater(string id);
        Task<DeviceResponse> GetDetailGateWay(string id);
        Task<DeviceResponse> GetDuplicateItems(string serialNumber);
        Task<DeviceResponse> GetDuplicateWaterItem(string serialNumber);
        Task<DeviceResponse> GetDuplicateGateWayItem(string serialNumber);
    }
}
