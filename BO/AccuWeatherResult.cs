using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BO
{
    public class AccuWeatherResult
    {
        [JsonProperty("temperatureFahrenheit")]
        public double TemperatureFahrenheit { get; internal set; }
        [JsonProperty("where")]
        public string Where { get; internal set; }
        [JsonProperty("windSpeedMph")]
        public double WindSpeedMph { get; internal set; }
    }
}
