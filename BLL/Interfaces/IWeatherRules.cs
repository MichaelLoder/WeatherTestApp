using System;
using System.Collections.Generic;
using System.Text;
using BO;

namespace BLL.Interfaces
{
    public interface IWeatherRule
    {
        WeatherResult ProcessAnyRule(WeatherResult result);
    }
}
