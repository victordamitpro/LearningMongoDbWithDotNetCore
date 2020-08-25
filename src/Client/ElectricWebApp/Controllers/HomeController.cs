using ElectricWebApp.Models;
using ElectricWebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ElectricWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IElectricService _service;

        public HomeController(ILogger<HomeController> logger, IElectricService gateWayService)
        {
            _logger = logger;
            _service = gateWayService;
        }

        public async Task<ActionResult> Index()
        {
            var electrics = await  _service.GetAll();

            var homeViewModelData = new HomeViewModel { Devices = electrics };

            return View(homeViewModelData);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
