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
    public class DeleteWaterMetterHandler : IRequestHandler<DeleteWaterMetterCommand, Response<string>>
    {
        private readonly IMongoRepository<WaterMetter> _repository;
        private readonly ILoggerManager _logger;

        public DeleteWaterMetterHandler(IMongoRepository<WaterMetter> repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Response<string>> Handle(DeleteWaterMetterCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInfo($"DeleteDeviceHandler(Id:{request.Id})");

            await _repository.DeleteByIdAsync(request.Id);

            return new Response<string> { Data = request.Id, ErrorMessage = string.Empty };
        }
    }
}
