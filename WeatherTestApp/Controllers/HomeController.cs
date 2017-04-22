using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.Interfaces;
using BO;
using Microsoft.AspNetCore.Mvc;

namespace WeatherTestApp.Controllers
{
    public class HomeController : Controller
    {
        private IWeatherFacade _weatherFacade;

        public HomeController(IWeatherFacade weatherFacade)
        {
            _weatherFacade = weatherFacade;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult GetWeather(WeatherRequest request)
        {
            return new ObjectResult(_weatherFacade.GetWeatherResult(request));
        }
    }
}
