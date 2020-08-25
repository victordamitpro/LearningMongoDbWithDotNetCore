using CommonShare.Logger;
using Electric.Application.Commands;
using Electric.Application.Mappers;
using Electric.Core.Entities;
using Electric.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Electric.Application.Handlers
{
    public class UpdateWaterMetterHandler : IRequestHandler<UpdateWaterMetterCommand>
    {
        private readonly IMongoRepository<WaterMetter> _repository;
        private readonly ILoggerManager _logger;

        public UpdateWaterMetterHandler(IMongoRepository<WaterMetter> repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<Unit> Handle(UpdateWaterMetterCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInfo($"UpdateDeviceHandler(Id:{request.Id}, SeriaNumber:{request.SeriaNumber})");

            var electricEntity = DeviceMapper.Mapper.Map<WaterMetter>(request);

            await _repository.ReplaceOneAsync(electricEntity);

            return Unit.Value;
        }
    }
}
