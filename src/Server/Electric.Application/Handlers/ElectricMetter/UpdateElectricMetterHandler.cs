using CommonShare.Logger;
using Electric.Application.Commands;
using Electric.Application.Mappers;
using Electric.Core.Entities;
using Electric.Core.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Electric.Application.Handlers
{
    public class UpdateElectricMetterHandler : IRequestHandler<UpdateElectricMetterCommand>
    {
        private readonly IMongoRepository<ElectricMetter> _repository;
        private readonly ILoggerManager _logger;

        public UpdateElectricMetterHandler(IMongoRepository<ElectricMetter> repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<Unit> Handle(UpdateElectricMetterCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInfo($"UpdateDeviceHandler(Id:{request.Id}, SeriaNumber:{request.SeriaNumber})");

            var electricEntity = DeviceMapper.Mapper.Map<ElectricMetter>(request);

            if (electricEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            await _repository.ReplaceOneAsync(electricEntity);

            return Unit.Value;
        }
    }
}
