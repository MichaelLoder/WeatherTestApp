using System;
using System.Collections.Generic;
using System.Text;
using BO;

namespace BLL.Interfaces
{
    public interface IWeatherFacade
    {
        WeatherResult GetWeatherResult(WeatherRequest request);
    }
}
