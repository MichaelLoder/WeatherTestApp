using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BLL.Interfaces;
using BO;
using Newtonsoft.Json;

namespace BLL.WeatherAggregators
{
    public class AccuAggregator : IWeatherAggregator
    {
        private readonly IAggeratorClient _aggeratorClient;

        public AccuAggregator(IAggeratorClient aggeratorClient)
        {
            _aggeratorClient = aggeratorClient;
        }


        private async Task<AggeratorResult> GetResultAsync(string location, TempUnits tempUnitUsed, WindUnits windUnitUsed)
        {
            var accuWeatherResult =  await _aggeratorClient.GetAggergatorResult<AccuWeatherResult>("http://localhost:50370/api/weather/", location);
            Random _rand = new Random();
            Thread.Sleep(_rand.Next(1000,3000));
            return new AggeratorResult()
            {
                TempUnitChoosen = tempUnitUsed,
                WindUnits = windUnitUsed,
                Temp = accuWeatherResult.TemperatureFahrenheit,
                Wind = accuWeatherResult.WindSpeedMph,
                Location = accuWeatherResult.Where
            };
        }

        public Task<AggeratorResult> GetWeatherResult(string location, TempUnits tempUnitUsed, WindUnits windUnitUsed)
        {
            return GetResultAsync(location, tempUnitUsed,windUnitUsed);
           
        }
    }
}
