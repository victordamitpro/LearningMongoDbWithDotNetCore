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
    public class CreateGateWayHandler : IRequestHandler<CreateGateWayCommand, Response<string>>
    {
        private readonly IMongoRepository<GateWay> _repository;
        private readonly ILoggerManager _logger;

        public CreateGateWayHandler(IMongoRepository<GateWay> repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<Response<string>> Handle(CreateGateWayCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInfo($"CreateGateWayHandler(seriaNumber:{request.SeriaNumber})");

            var gateWay = DeviceMapper.Mapper.Map<GateWay>(request);

            await _repository.InsertOneAsync(gateWay);

            return new Response<string> { Data = gateWay.Id, ErrorMessage = string.Empty };
        }
    }
}
