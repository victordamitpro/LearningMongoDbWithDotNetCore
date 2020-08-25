using Electric.Application.Responses;
using MediatR;

namespace Electric.Application.Commands
{
    public class DeleteDeviceCommand : IRequest<Response<string>>
    {
        public string Id { get; set; }
    }
}
