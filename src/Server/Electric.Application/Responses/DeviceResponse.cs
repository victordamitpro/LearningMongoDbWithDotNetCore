namespace Electric.Application.Responses
{
    public class DeviceResponse
    {
        public string Id { get; set; }
        public string SeriaNumber { get; set; }
        public string FirmwareVersion { get; set; }
        public string State { get; set; }
        public int Type { get; set; }
        public GateWayResponse GateWay { get; set; }
    }

    public class GateWayResponse {
        public string IP { get; set; }
        public int Port { get; set; }
    }
}
