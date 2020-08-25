using ElectricWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElectricWebApp.Services.Interfaces
{
    public interface IDeviceService
    {
        Task<ResponseDataModel<string>> Create(DeviceViewModel electricModel);
        Task<DeviceViewModel> Edit(DeviceViewModel electricModel);
        Task<ResponseDataModel<string>> Delete(string id);
        Task<DeviceViewModel> GetDetail(string id);
        Task<IEnumerable<DeviceViewModel>> GetAll();
    }
}
