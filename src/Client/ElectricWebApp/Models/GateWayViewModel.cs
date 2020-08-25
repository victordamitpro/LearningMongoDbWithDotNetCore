using System.ComponentModel.DataAnnotations;

namespace ElectricWebApp.Models
{
    public class GateWayViewModel 
    {
        [Display(Name = "IP")]
        public string IP { get; set; }
        [Display(Name = "Port")]
        public int? Port { get; set; }
        public string PortTitle { get {
                return !Port.HasValue || Port.Value == 0 ? "" : Port.Value.ToString();
            }
        }
    }
}
