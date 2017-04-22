using System;
using System.Collections.Generic;
using System.Text;

namespace BO
{
    public class AggeratorResult
    {
        public double Temp { get;  set; }
        public double Wind { get;  set; }

        public string Location { get; set; }

        public TempUnits TempUnitChoosen { get; set; }
        public WindUnits WindUnits { get; set; }
    }
}
