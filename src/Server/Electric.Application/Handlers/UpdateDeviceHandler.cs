using CommonShare.Logger;
using Electric.Application.Commands;
using Electric.Application.Mappers;
using Electric.Application.Responses;
using Electric.Core.Entities;
using Electric.Core.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Electric.Application.Handlers
{
    public class UpdateDeviceHandler : IRequestHandler<UpdateDeviceCommand, Response<Device>>
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly ILoggerManager _logger;

        public UpdateDeviceHandler(IDeviceRepository deviceRepository, ILoggerManager logger)
        {
            _deviceRepository = deviceRepository;
            _logger = logger;
        }
        public async Task<Response<Device>> Handle(UpdateDeviceCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInfo($"UpdateDeviceHandler(Id:{request.Id}, SeriaNumber:{request.SeriaNumber})");

            var electricEntity = DeviceMapper.Mapper.Map<Core.Entities.Device>(request);

            if (electricEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            var result =  await _deviceRepository.UpdateDevice(electricEntity);

            return new Response<Device> { Data = result, ErrorMessage = string.Empty };
        }
    }
}
