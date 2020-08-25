using CommonShare.Logger;
using Electric.Application.Commands;
using Electric.Application.Mappers;
using Electric.Application.Responses;
using Electric.Core.Entities;
using Electric.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Electric.Application.Handlers
{
    public class CreateElectricMetterHandler : IRequestHandler<CreateElectricMetterCommand, Response<string>>
    {
        private readonly IMongoRepository<ElectricMetter> _electricRepository;
        private readonly ILoggerManager _logger;

        public CreateElectricMetterHandler(IMongoRepository<ElectricMetter> electricRepository, ILoggerManager logger)
        {
            _electricRepository = electricRepository;
            _logger = logger;
        }
        public async Task<Response<string>> Handle(CreateElectricMetterCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInfo($"CreateDeviceHandler(seriaNumber:{request.SeriaNumber})");

            var electricEntity = DeviceMapper.Mapper.Map<ElectricMetter>(request);

            await _electricRepository.InsertOneAsync(electricEntity);

            return new Response<string> { Data = electricEntity.Id, ErrorMessage = string.Empty };
        }
    }
}
