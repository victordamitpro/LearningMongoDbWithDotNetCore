using CommonShare.Enums;
using ElectricWebApp.Models;
using ElectricWebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ElectricWebApp.Controllers
{
    public class DeviceController : Controller
    {
        private readonly IElectricService _electricService;
        private readonly IGateWayService _gateWayService;
        private readonly IWaterService _waterService;

        public DeviceController(IElectricService electricService, IGateWayService gateWayService, IWaterService waterService)
        {
            _electricService = electricService;
            _gateWayService = gateWayService;
            _waterService = waterService;
        }
        public async Task<ActionResult> Index(string id, int type)
        {
            var result = new DeviceViewModel { Type = (int)ElectricType.Electric };

            if (!string.IsNullOrEmpty(id))
            {
                if (type == (int)ElectricType.Electric)
                {
                    result = await _electricService.GetDetail(id);
                }
                else if (type == (int)ElectricType.Water)
                {
                    result = await _waterService.GetDetail(id);
                }
                else if (type == (int)ElectricType.GateWay)
                {
                    result = await _gateWayService.GetDetail(id);
                }
                
                return View("Edit", result);
            }
            return View("Index", result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(DeviceViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if(viewModel.Type == (int)ElectricType.Electric)
                {
                    return await CreateElectricMetter(viewModel);
                }
                else if(viewModel.Type == (int)ElectricType.Water)
                {
                    return await CreateWaterMetter(viewModel);
                }
                else if (viewModel.Type == (int)ElectricType.GateWay)
                {
                    return await CreateGateWayMetter(viewModel);
                }
            }

            return View("Error");
        }

        public async Task<ActionResult> CreateElectricMetter(DeviceViewModel viewModel)
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

        public async Task<ActionResult> UpdateElectricMetter(DeviceViewModel viewModel)
        {
            var newDevice = new DeviceViewModel
            {
                Id = viewModel.Id,
                SeriaNumber = viewModel.SeriaNumber,
                FirmwareVersion = viewModel.FirmwareVersion,
                State = viewModel.State,
                Type = viewModel.Type,
            };

            await _electricService.Edit(newDevice);

            return RedirectToAction("Index", "Home");
        }

        public async Task<ActionResult> UpdateWaterMetter(DeviceViewModel viewModel)
        {
            var newDevice = new DeviceViewModel
            {
                Id = viewModel.Id,
                SeriaNumber = viewModel.SeriaNumber,
                FirmwareVersion = viewModel.FirmwareVersion,
                State = viewModel.State,
                Type = viewModel.Type,
            };

            await _waterService.Edit(newDevice);

            return RedirectToAction("Index", "Home");
        }

        public async Task<ActionResult> UpdateGateWay(DeviceViewModel viewModel)
        {
            var newDevice = new DeviceViewModel
            {
                Id = viewModel.Id,
                SeriaNumber = viewModel.SeriaNumber,
                FirmwareVersion = viewModel.FirmwareVersion,
                State = viewModel.State,
                Type = viewModel.Type,
                Port = viewModel.Port,
                IP = viewModel.IP
            };

            await _gateWayService.Edit(newDevice);

            return RedirectToAction("Index", "Home");
        }

        public async Task<ActionResult> CreateWaterMetter(DeviceViewModel viewModel)
        {
            var newDevice = new DeviceViewModel
            {
                SeriaNumber = viewModel.SeriaNumber,
                FirmwareVersion = viewModel.FirmwareVersion,
                State = viewModel.State,
                Type = viewModel.Type,
            };

            var response = await _waterService.Create(newDevice);

            return RedirectToPage(response);
        }

        public async Task<ActionResult> CreateGateWayMetter(DeviceViewModel viewModel)
        {
            var newDevice = new DeviceViewModel
            {
                SeriaNumber = viewModel.SeriaNumber,
                FirmwareVersion = viewModel.FirmwareVersion,
                State = viewModel.State,
                Type = viewModel.Type,
            };

            var response = await _gateWayService.Create(newDevice);

            return RedirectToPage(response);
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
                if(viewModel.Type == (int)ElectricType.Electric)
                {
                    return await UpdateElectricMetter(viewModel);
                }
                else if(viewModel.Type == (int)ElectricType.Water)
                {
                    return await UpdateWaterMetter(viewModel);
                }
                else if (viewModel.Type == (int)ElectricType.GateWay)
                {
                    return await UpdateGateWay(viewModel);
                }

                return RedirectToAction("Index", "Home");
            }

            return View("Error");
        }

        public async Task<ActionResult> Delete(string id,int type)
        {
            if (!string.IsNullOrEmpty(id))
            {
                if (type == (int)ElectricType.Electric)
                {
                    await _electricService.Delete(id);
                }
                else if (type == (int)ElectricType.Water)
                {
                    await _waterService.Delete(id);
                }
                else if (type == (int)ElectricType.GateWay)
                {
                    await _gateWayService.Delete(id);
                }
                

                return RedirectToAction("Index", "Home");
            }

            return View("Error");
        }
    }
}
