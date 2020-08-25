using Electric.Application.Mappers;
using Electric.Application.Responses;
using Electric.Core.Entities;
using Electric.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electric.Application.Queries
{
    public class DeviceQuery : IDeviceQuery
    {
        private readonly IMongoRepository<ElectricMetter> _electricRepository;
        private readonly IMongoRepository<WaterMetter> _waterRepository;
        private readonly IMongoRepository<GateWay> _gateWayRepository;

        public DeviceQuery(IMongoRepository<ElectricMetter> electricRepository, IMongoRepository<WaterMetter> waterRepository, IMongoRepository<GateWay> gateWayRepository)
        {
            _electricRepository = electricRepository;
            _waterRepository = waterRepository;
            _gateWayRepository = gateWayRepository;
        }

        public async Task<DeviceResponse> GetDetailElectric(string id)
        {
            var result = await _electricRepository.FindOneAsync(p => p.Id == id);

            return DeviceMapper.Mapper.Map<DeviceResponse>(result);
        }

        public async Task<DeviceResponse> GetDetailWater(string id)
        {
            var result = await _waterRepository.FindOneAsync(p => p.Id == id);

            return DeviceMapper.Mapper.Map<DeviceResponse>(result);
        }

        public async Task<DeviceResponse> GetDetailGateWay(string id)
        {
            var result = await _gateWayRepository.FindOneAsync(p => p.Id == id);

            return DeviceMapper.Mapper.Map<DeviceResponse>(result);
        }

        public async Task<DeviceResponse> GetDuplicateItems(string serialNumber)
        {
            var result = await _electricRepository.FindOneAsync(e => e.SeriaNumber == serialNumber);

            if (result == null)
                return null;

            return DeviceMapper.Mapper.Map<DeviceResponse>(result);
        }

        public async Task<DeviceResponse> GetDuplicateWaterItem(string serialNumber)
        {
            var result = await _waterRepository.FindOneAsync(e => e.SeriaNumber == serialNumber);

            if (result == null)
                return null;

            return DeviceMapper.Mapper.Map<DeviceResponse>(result);
        }

        public async Task<DeviceResponse> GetDuplicateGateWayItem(string serialNumber)
        {
            var result = await _gateWayRepository.FindOneAsync(e => e.SeriaNumber == serialNumber);

            if (result == null)
                return null;

            return DeviceMapper.Mapper.Map<DeviceResponse>(result);
        }

        public async Task<IEnumerable<DeviceResponse>> GetAlls()
        {
            var electrics = await _electricRepository.FindAllAsync();

            var electricMapDatas =  DeviceMapper.Mapper.Map<IEnumerable<DeviceResponse>>(electrics);

            var waters = await _waterRepository.FindAllAsync();

            var waterMapDatas = DeviceMapper.Mapper.Map<IEnumerable<DeviceResponse>>(waters);

            var gateWays = await _gateWayRepository.FindAllAsync();

            var electricMappingResponse = DeviceMapper.Mapper.Map<IEnumerable<DeviceResponse>>(gateWays);

            var result = electricMapDatas
                    .Concat(waterMapDatas)
                    .Concat(electricMappingResponse);

            return result;
        }
    }
}
