using CommonShare.Logger;
using Electric.Application.Commands;
using Electric.Application.Responses;
using Electric.Core.Entities;
using Electric.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Electric.Application.Handlers
{
    public class DeleteGateWayHandler : IRequestHandler<DeleteGateWayCommand, Response<string>>
    {
        private readonly IMongoRepository<GateWay> _repository;
        private readonly ILoggerManager _logger;

        public DeleteGateWayHandler(IMongoRepository<GateWay> repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Response<string>> Handle(DeleteGateWayCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInfo($"DeleteGateWayHandler(Id:{request.Id})");

            await _repository.DeleteByIdAsync(request.Id);

            return new Response<string> { Data = request.Id, ErrorMessage = string.Empty };
        }
    }
}
