namespace ElectricWebApp.Settings
{
    public class ApiSettings : IApiSettings
    {
        public string BaseAddress { get; set; }
        public string ElectricPath { get; set; }
        public string GateWayPath { get; set; }
        public string WaterPath { get; set; }
    }
}
