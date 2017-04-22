using System;
using System.Collections.Generic;
using System.Text;
using BLL.Interfaces;
using BO;
using System.Linq;
using BLL.WeatherRules;

namespace BLL
{
    public class WeatherFacade : IWeatherFacade
    {
        private readonly IWeatherAggregatorFactory _weatherAggregatorFactory;
        private readonly IAggeratorClient _aggeratorClient;
        private readonly ICacheFacade<TempUnits, List<AggeratorResult>> _tempCacheFacade;
        private readonly ICacheFacade<WindUnits, List<AggeratorResult>> _windCacheFacade;
        private readonly IWeatherRule _rule;

        public WeatherFacade(IWeatherAggregatorFactory weatherAggregatorFactory, IAggeratorClient aggeratorClient, ICacheFacade<TempUnits, List<AggeratorResult>> tempCacheFacade, 
            ICacheFacade<WindUnits, List<AggeratorResult>> windCacheFacade, IWeatherRule rule )
        {
            _weatherAggregatorFactory = weatherAggregatorFactory;
            _aggeratorClient = aggeratorClient;
            _tempCacheFacade = tempCacheFacade;
            _windCacheFacade = windCacheFacade;
            _rule = rule;
        }
       

        public WeatherResult GetWeatherResult(WeatherRequest request)
        {
            //refactor to extension method  - error checking
            var choosenWindUnit = (WindUnits) Enum.Parse(typeof(WindUnits), request.WindUnit);
            var choosenTempUnit = (TempUnits) Enum.Parse(typeof(TempUnits), request.TempUnit);
            // get list of every api we need to call
           var aggregators = _weatherAggregatorFactory.GetWeatherAggregator(choosenTempUnit, choosenWindUnit, _aggeratorClient);
            
            var results = new List<AggeratorResult>();
            // loop[ through each api
            foreach (var weatherAggregator in aggregators)
            {
                results.Add(weatherAggregator.GetWeatherResult(request.Location, choosenTempUnit, choosenWindUnit).Result);
            }
            // get previous queries of temperature
            var cachedTemp = _tempCacheFacade.Get(choosenTempUnit);
            // get previous queries of wind speeds
            var cahceWind = _windCacheFacade.Get(choosenWindUnit);

            // add only the results we are interested in
            cahceWind.Add(results.First(x => x.WindUnits == choosenWindUnit));
            cachedTemp.Add(results.First(x => x.TempUnitChoosen == choosenTempUnit));

           // add results to cache
            _tempCacheFacade.Add(choosenTempUnit, cachedTemp);
            _windCacheFacade.Add(choosenWindUnit, cahceWind);
          
            // return the result after processing them through rules
            return _rule.ProcessAnyRule(new WeatherResult()
            {
                AverageTemp = cachedTemp.CalculateTempAverage(choosenTempUnit),
                AverageWindSpeed = cahceWind.CalculateWindAverage(choosenWindUnit),
                Location = request.Location,
                WindUnits = choosenWindUnit,
                TempUnitChoosen = choosenTempUnit
            });

        }
    }
}
