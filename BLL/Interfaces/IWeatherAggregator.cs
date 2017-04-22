using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace BLL.Interfaces
{
    public interface IWeatherAggregator
    {
        Task<AggeratorResult> GetWeatherResult(string location, TempUnits tempUnitUsed, WindUnits windUnitUsed);
    }
}
