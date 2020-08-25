using System.Collections.Generic;

namespace ElectricWebApp.Models
{
    public class HomeViewModel
    {
        public IEnumerable<DeviceViewModel> Devices { get; set; }  
    }
}
