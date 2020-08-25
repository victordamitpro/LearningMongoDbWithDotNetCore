namespace ElectricWebApp.Settings
{
    public interface IApiSettings
    {
        string BaseAddress { get; set; }
        string ElectricPath { get; set; }
        string GateWayPath { get; set; }
        string WaterPath { get; set; }
    }
}
