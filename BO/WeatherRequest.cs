using System;
using System.Collections.Generic;
using System.Text;

namespace BO
{
    public class WeatherRequest
    {
        public string TempUnit { get; set; }
        public string WindUnit { get; set; }
        public string Location { get; set; }
    }
}
