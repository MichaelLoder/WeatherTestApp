using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.Interfaces;
using BLL.WeatherAggregators;
using BO;

namespace BLL
{
    public class WeatherAggregatorFactory : IWeatherAggregatorFactory
    {
        // factory for returning api's based on the units passed through
        // new apis could be easily added by extending the switch statements and returning the new IWeatherAggregator
        public List<IWeatherAggregator> GetWeatherAggregator(TempUnits unit, WindUnits windUnit, IAggeratorClient aggeratorClient)
        {
            var aggregators = new List<IWeatherAggregator>();
            switch (windUnit)
            {
                case WindUnits.MPH:
                    if (!aggregators.OfType<BbcAggregator>().Any())
                    {
                        aggregators.Add(new BbcAggregator(aggeratorClient));
                    }
                    break;
                case WindUnits.KPH:
                    if (!aggregators.OfType<AccuAggregator>().Any())
                    {
                        aggregators.Add(new AccuAggregator(aggeratorClient));
                    }
                    break;
                default:
                    throw new NotImplementedException("Wind unit not found");
            }

            switch (unit)
            {
                case TempUnits.Celsius:
                    if (!aggregators.OfType<BbcAggregator>().Any())
                    {
                        aggregators.Add(new BbcAggregator(aggeratorClient));
                    }
                    break;
                case TempUnits.Fahrenheit:
                    if (!aggregators.OfType<AccuAggregator>().Any())
                    {
                        aggregators.Add(new AccuAggregator(aggeratorClient));
                    }
                    break;
                default:
                    throw new NotImplementedException("Temp unit not found");
            }
            return aggregators;
        }
    }
}
