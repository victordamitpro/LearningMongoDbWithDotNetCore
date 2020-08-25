using Electric.Core.Entities;
using Electric.Core.Repositories;
using Electric.Infrastructure.Data.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Electric.Infrastructure.Repository
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly IElectricContext _context;

        public DeviceRepository(IElectricContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); ;
        }
        public async Task<string> CreateDevice(Device electric)
        {
            await _context.Devices.InsertOneAsync(electric);
            return electric.Id;
        }

        public async Task<string> DeleteDevice(string id)
        {
            FilterDefinition<Device> filter = Builders<Device>.Filter.Eq(m => m.Id, id);

            DeleteResult deleteResult = await _context
                                                .Devices
                                                .DeleteOneAsync(filter);

            return id;
        }

        public async Task<Device> GetDevide(string id)
        {
            return await _context
                           .Devices
                           .Find(p => p.Id == id)
                           .FirstOrDefaultAsync();
        }

        public async Task<Device> GetDeviceBySeriaNumber(string seriaNumber)
        {
            return await _context
                           .Devices
                           .Find(p => p.SeriaNumber == seriaNumber)
                           .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Device>> GetAllDevice()
        {
            return await _context
                          .Devices
                          .Find(e => true)
                          .ToListAsync();
        }

        public async Task<Device> UpdateDevice(Device electric)
        {
            var updateResult = await _context
                                      .Devices
                                      .ReplaceOneAsync(filter: e => e.Id == electric.Id, replacement: electric);

            if (updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0)
                return Core.Entities.Device.Create(electric);

            return Core.Entities.Device.New();
        }
    }
}
