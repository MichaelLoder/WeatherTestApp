using System;
using System.Collections.Generic;
using System.Text;
using BLL.Interfaces;
using BO;

namespace BLL.WeatherRules
{
    public class _4ComRule : IWeatherRule
    {
        public WeatherResult ProcessAnyRule(WeatherResult result)
        {
            switch (result.WindUnits)
            {
                case WindUnits.MPH:
                    if (Math.Abs(result.AverageWindSpeed - 10) < 0.5)
                    {
                        result.AverageWindSpeed = 7.5;
                    }
                    break;
                case WindUnits.KPH:
                    if (Math.Abs(result.AverageWindSpeed - 8) < 0.5)
                    {
                        result.AverageWindSpeed = 12;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            switch (result.TempUnitChoosen)
            {
                case TempUnits.Celsius:
                    if (Math.Abs(result.AverageTemp - 10) < 0.5)
                    {
                        result.AverageTemp = 15;
                    }
                    break;
                case TempUnits.Fahrenheit:
                    if (Math.Abs(result.AverageTemp - 68) < 0.5)
                    {
                        result.AverageTemp = 59;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return result;
        }
    }
}
