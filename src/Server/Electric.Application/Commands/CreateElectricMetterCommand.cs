using Electric.Application.Responses;
using MediatR;

namespace Electric.Application.Commands
{
    public class CreateElectricMetterCommand: IRequest<Response<string>>
    {
        public string SeriaNumber { get; set; }
        public string FirmwareVersion { get; set; }
        public string State { get; set; }
        public int Type { get; set; }
    }
}
