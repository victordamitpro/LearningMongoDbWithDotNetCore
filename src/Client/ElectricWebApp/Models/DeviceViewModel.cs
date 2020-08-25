using ElectricWebApp.Commons;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectricWebApp.Models
{
    public class DeviceViewModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Seria Number is Required")]
        [Display(Name = "Seria Number")]
        public string SeriaNumber { get; set; }
        [Required(ErrorMessage = "Firmware version is Required")]
        [Display(Name = "Firmware version")]
        public string FirmwareVersion { get; set; }
        [Display(Name = "State")]
        public string State { get; set; }
        public GateWayViewModel GateWay { get; set; }
        public int Type { get; set; }
        public string TypeName
        {
            get
            {
                if (Type == 0)
                    return Constant.Type.Electric;
                if (Type == 1)
                    return Constant.Type.Water;
                if (Type == 2)
                    return Constant.Type.Gateways;

                return "";
            }
        }
        [Display(Name = "Type")]
        public List<SelectListItem> Types { get; } = new List<SelectListItem>
           {
              new SelectListItem { Value = "0", Text = "Electric metter" },
              new SelectListItem { Value = "1", Text = "Water metter" },
              new SelectListItem { Value = "2", Text = "Gateways" },
           };

        public DeviceViewModel()
        {
            GateWay = new GateWayViewModel();
        }
    }
}
