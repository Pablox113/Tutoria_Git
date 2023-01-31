using AccesoDatos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PL.Models;
using System.Diagnostics;

namespace PL.Controllers
{
    public class GerenteController : Controller
    {
        private readonly ILogger<GerenteController> _logger;

        public GerenteController(ILogger<GerenteController> logger)
        {
            _logger = logger;
        }

      //  [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            return View();
        }

        //        public IActionResult Privacy()
        //        {
        //            return View();
        //        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
