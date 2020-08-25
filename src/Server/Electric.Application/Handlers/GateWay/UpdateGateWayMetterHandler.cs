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
    public class UpdateGateWayHandler : IRequestHandler<UpdateGateWayCommand>
    {
        private readonly IMongoRepository<GateWay> _repository;
        private readonly ILoggerManager _logger;

        public UpdateGateWayHandler(IMongoRepository<GateWay> repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<Unit> Handle(UpdateGateWayCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInfo($"UpdateDeviceHandler(Id:{request.Id}, SeriaNumber:{request.SeriaNumber})");

            var electricEntity = DeviceMapper.Mapper.Map<GateWay>(request);

            await _repository.ReplaceOneAsync(electricEntity);

            return Unit.Value;
        }
    }
}
