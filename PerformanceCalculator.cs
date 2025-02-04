using System;
using System.Collections.Generic;
using System.Linq;

namespace PerformanceService
{
    public class PerformanceCalculator : IPerformanceCalculator
    {
        public double GetPerformance(List<Tuple<DateTime, double>> dataset, DateTime fromDate, DateTime toDate)
        {
            if (dataset == null || dataset.Count == 0)
                throw new ArgumentException("Dataset cannot be null or empty.");

            // Filtrer les données dans la plage de dates
            var filteredData = dataset.Where(d => d.Item1 >= fromDate && d.Item1 <= toDate)
                                      .OrderBy(d => d.Item1)
                                      .ToList();

            if (filteredData.Count < 2)
                throw new InvalidOperationException("Not enough data points in the specified range.");

            double firstValue = filteredData.First().Item2;
            double lastValue = filteredData.Last().Item2;

            if (firstValue == 0)
                throw new DivideByZeroException("First value in dataset is zero, cannot calculate performance.");

            return (lastValue / firstValue) - 1;
        }
    }
}
