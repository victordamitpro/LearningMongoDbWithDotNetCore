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
    public class CreateDeviceHandler : IRequestHandler<CreateDeviceCommand, Response<string>>
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly ILoggerManager _logger;

        public CreateDeviceHandler(IDeviceRepository deviceRepository, ILoggerManager logger)
        {
            _deviceRepository = deviceRepository;
            _logger = logger;
        }
        public async Task<Response<string>> Handle(CreateDeviceCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInfo($"CreateDeviceHandler(seriaNumber:{request.SeriaNumber})");

            var electricEntity = DeviceMapper.Mapper.Map<Device>(request);

            if (electricEntity == null)
                throw new ArgumentNullException($"Entity could not be mapped.");

            var result = await _deviceRepository.CreateDevice(electricEntity);

            return new Response<string> { Data = result, ErrorMessage = string.Empty };
        }
    }
}
