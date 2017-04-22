using System;
using System.Collections.Generic;
using System.Text;

namespace BO
{
    public class WeatherResult
    {
        public string Location { get; set; }
        public double AverageTemp { get; set; }

        public double AverageWindSpeed { get; set; }

        public TempUnits TempUnitChoosen { get; set; }
        public WindUnits WindUnits { get; set; }
    }
}
