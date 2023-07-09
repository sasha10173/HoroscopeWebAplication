using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApplication.Controllers
{
    public class HomeController : Controller
    {
        
        ParsingURL pars = new ParsingURL("https://www.chita.ru/horoscope/daily/");
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Prediction(Horoscope horoscope)
        {
            #region xpath
            string xpath = $"//*[@class='IGRa5'][{horoscope.GetXpathId()}] //div[@class='BDPZt KUbeq']";
            #endregion
            horoscope.Description = pars.GetElementString(xpath);

            return View(horoscope);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
