using Electric.Application.Responses;
using Electric.Core.Entities;
using MediatR;

namespace Electric.Application.Commands
{
    public class UpdateDeviceCommand: IRequest<Response<Device>>
    {
        public string Id { get; set; }
        public string SeriaNumber { get; set; }
        public string FirmwareVersion { get; set; }
        public string State { get; set; }
        public int Type { get; set; }
        public GateWayCommand GateWay { get; set; }
    }
}
