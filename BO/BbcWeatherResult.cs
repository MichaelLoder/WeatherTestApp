using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BO
{
    public class BbcWeatherResult
    {
        [JsonProperty("location")]
        public string Where { get; internal set; }
        [JsonProperty("temperatureCelsius")]
        public double TemperatureCelsius { get; internal set; }
        [JsonProperty("windSpeedKph")]
        public double WindSpeedKph { get; internal set; }
    }
}
