using CommonShare.Enums;
using ElectricWebApp.Models;
using ElectricWebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ElectricWebApp.Controllers
{
    public class DeviceController : Controller
    {
        private readonly IDeviceService _electricService;

        public DeviceController(IDeviceService electricService)
        {
            _electricService = electricService;
        }
        public async Task<ActionResult> Index(string id)
        {
            var result = new DeviceViewModel { Type = 1 };
            if (!string.IsNullOrEmpty(id))
            {
                result = await _electricService.GetDetail(id);
                return View("Edit", result);
            }
            return View("Index", result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(DeviceViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if(viewModel.Type != (int)ElectricType.GateWay)
                {
                    var newDevice = new DeviceViewModel
                    {
                        SeriaNumber = viewModel.SeriaNumber,
                        FirmwareVersion = viewModel.FirmwareVersion,
                        State = viewModel.State,
                        Type = viewModel.Type,
                    };

                    var response = await _electricService.Create(newDevice);

                    return RedirectToPage(response);
                }
                else
                {
                    var newGateWay = new DeviceViewModel
                    {
                        SeriaNumber = viewModel.SeriaNumber,
                        FirmwareVersion = viewModel.FirmwareVersion,
                        State = viewModel.State,
                        Type = viewModel.Type,
                        GateWay = new GateWayViewModel{
                            Port = viewModel.GateWay.Port,
                            IP = viewModel.GateWay.IP
                        }
                    };

                    var response = await _electricService.Create(newGateWay);

                    return RedirectToPage(response);
                }
            }

            return View("Error");
        }

        private ActionResult RedirectToPage(ResponseDataModel<string> response)
        {
            if (response.Data == null && !string.IsNullOrEmpty(response.ErrorMessage))
            {
                return RedirectToAction("Duplicate", "Device");
            }

            return RedirectToAction("Index", "Home");
        }

        public  ActionResult Duplicate()
        {
            return View("DuplicateFound");
        }

        [HttpPost]
        public async Task<ActionResult> Edit(DeviceViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if(viewModel.Type != (int)ElectricType.GateWay)
                {
                    var updateDevice = new DeviceViewModel
                    {
                        Id = viewModel.Id,
                        SeriaNumber = viewModel.SeriaNumber,
                        FirmwareVersion = viewModel.FirmwareVersion,
                        State = viewModel.State,
                        Type = viewModel.Type,
                    };

                    await _electricService.Edit(updateDevice);
                }
                else
                {
                    var updateGateWay = new DeviceViewModel
                    {
                        Id = viewModel.Id,
                        SeriaNumber = viewModel.SeriaNumber,
                        FirmwareVersion = viewModel.FirmwareVersion,
                        State = viewModel.State,
                        Type = viewModel.Type,
                        GateWay = new GateWayViewModel
                        {
                            Port = viewModel.GateWay.Port,
                            IP = viewModel.GateWay.IP
                        }
                    };

                    await _electricService.Edit(updateGateWay);
                }

                return RedirectToAction("Index", "Home");
            }

            return View("Error");
        }

        public async Task<ActionResult> Delete(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                await _electricService.Delete(id);

                return RedirectToAction("Index", "Home");
            }

            return View("Error");
        }
    }
}
