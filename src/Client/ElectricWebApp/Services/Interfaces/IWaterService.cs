using ElectricWebApp.Models;
using System.Threading.Tasks;

namespace ElectricWebApp.Services.Interfaces
{
    public interface IWaterService
    {
        Task<ResponseDataModel<string>> Create(DeviceViewModel electricModel);
        Task<object> Edit(DeviceViewModel electricModel);
        Task<ResponseDataModel<string>> Delete(string id);
        Task<DeviceViewModel> GetDetail(string id);
    }
}
