using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.Interfaces;
using BO;
using Microsoft.AspNetCore.Mvc;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Error()
        {
            return View();
        }

        public IActionResult GetWeather(WeatherRequest request)
        {
            IWeatherFacade _weatherFacade = new WeatherFacade(new WeatherAggregatorFactory());
           return new ObjectResult( _weatherFacade.GetWeatherResult(request));
        }
    }
}
