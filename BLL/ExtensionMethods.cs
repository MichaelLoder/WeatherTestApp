using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BO;

namespace BLL
{
    public static class ExtensionMethods
    {
        public static double CalculateTempAverage(this IEnumerable<AggeratorResult> results,
            TempUnits selectedUnit)
        {
            var aggeratorResults = results as IList<AggeratorResult> ?? results.ToList();
            return (aggeratorResults.Where(u => u.TempUnitChoosen == selectedUnit).Sum(x => x.Temp) /
                    aggeratorResults.Count(u => u.TempUnitChoosen == selectedUnit));
        }

        public static double CalculateWindAverage(this IEnumerable<AggeratorResult> results,
            WindUnits selectedUnit)
        {
            var aggeratorResults = results as IList<AggeratorResult> ?? results.ToList();
            return (aggeratorResults.Where(u => u.WindUnits == selectedUnit).Sum(x => x.Temp) /
                    aggeratorResults.Count(u => u.WindUnits == selectedUnit));
        }
    }
}
