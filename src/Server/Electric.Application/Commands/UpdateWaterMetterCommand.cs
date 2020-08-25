using MediatR;

namespace Electric.Application.Commands
{
    public class UpdateWaterMetterCommand : IRequest
    {
        public string Id { get; set; }
        public string SeriaNumber { get; set; }
        public string FirmwareVersion { get; set; }
        public string State { get; set; }
        public int Type { get; set; }
    }
}
