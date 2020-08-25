using Electric.Application.Mappers;
using Electric.Application.Responses;
using Electric.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Electric.Application.Queries
{
    public class DeviceQuery : IDeviceQuery
    {
        private readonly IDeviceRepository _electricRepository;

        public DeviceQuery(IDeviceRepository electricRepository)
        {
            _electricRepository = electricRepository;
        }

        public async Task<DeviceResponse> GetDetail(string id)
        {
            var result = await _electricRepository.GetDevide(id);

            return DeviceMapper.Mapper.Map<DeviceResponse>(result);
        }

        public async Task<DeviceResponse> GetDuplicateItems(string serialNumber)
        {
            var result = await _electricRepository.GetDeviceBySeriaNumber(serialNumber);

            if (result == null)
                return null;

            return DeviceMapper.Mapper.Map<DeviceResponse>(result);
        }

        public async Task<IEnumerable<DeviceResponse>> GetAlls()
        {
            var result = await _electricRepository.GetAllDevice();

            return DeviceMapper.Mapper.Map<IEnumerable<DeviceResponse>>(result);
        }
    }
}
