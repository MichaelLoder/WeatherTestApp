using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BLL.Interfaces;
using BO;

namespace BLL.WeatherAggregators
{
    public class BbcAggregator : IWeatherAggregator
    {
        private readonly IAggeratorClient _aggeratorClient;

        public BbcAggregator(IAggeratorClient aggeratorClient)
        {
            _aggeratorClient = aggeratorClient;
        }

        private async Task<AggeratorResult> GetResultAsync(string location, TempUnits tempUnitUsed, WindUnits windUnitUsed)
        {
            var accuWeatherResult = await _aggeratorClient.GetAggergatorResult<BbcWeatherResult>("http://localhost:50341/api/weather/", location);
            Random _rand = new Random();
            Thread.Sleep(_rand.Next(1000, 3000));
            return new AggeratorResult()
            {
                TempUnitChoosen = tempUnitUsed,
                WindUnits = windUnitUsed,
                Temp = accuWeatherResult.TemperatureCelsius,
                Wind = accuWeatherResult.WindSpeedKph,
                Location = accuWeatherResult.Where
            };
        }

        public Task<AggeratorResult> GetWeatherResult(string location, TempUnits tempUnitUsed, WindUnits windUnitUsed)
        {
            return GetResultAsync(location, tempUnitUsed, windUnitUsed);
        }
    }
}
