using CommonShare.Logger;
using Electric.Application.Commands;
using Electric.Application.Responses;
using Electric.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Electric.Application.Handlers
{
    public class DeleteDeviceHandler : IRequestHandler<DeleteDeviceCommand, Response<string>>
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly ILoggerManager _logger;

        public DeleteDeviceHandler(IDeviceRepository deviceRepository, ILoggerManager logger)
        {
            _deviceRepository = deviceRepository;
            _logger = logger;
        }

        public async Task<Response<string>> Handle(DeleteDeviceCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInfo($"DeleteDeviceHandler(Id:{request.Id})");

            var result = await _deviceRepository.DeleteDevice(request.Id);

            return new Response<string> { Data = result, ErrorMessage = string.Empty };
        }
    }
}
