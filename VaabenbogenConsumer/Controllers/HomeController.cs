using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VaabenbogenConsumer.Helpers;
using VaabenbogenConsumer.Models;
using VaabenbogenConsumer.Models.ViewModels;

namespace VaabenbogenConsumer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.StatusOptions = DropdownHelper.VaabenStatusDropdownOptions();
            ViewBag.LadefunktionOptions = DropdownHelper.LadefunktionDropdownOptions();
            ViewBag.TypeOptions = DropdownHelper.VaabenTypeDropdownOptions();
            ViewBag.SoegVaabenObject = new SoegVaaben();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
