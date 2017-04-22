using System;
using System.Collections.Generic;
using System.Text;
using BO;

namespace BLL.Interfaces
{
    public interface IWeatherAggregatorFactory
    {
        List<IWeatherAggregator> GetWeatherAggregator(TempUnits unit, WindUnits windUnit, IAggeratorClient aggeratorClient);
    }
}
