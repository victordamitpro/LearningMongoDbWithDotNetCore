namespace ElectricWebApp.Settings
{
    public interface IApiSettings
    {
        string BaseAddress { get; set; }
        string DevicePath { get; set; }
    }
}
