using System;
using System.Collections.Generic;

namespace PerformanceService
{
    public interface IPerformanceCalculator
    {
        double GetPerformance(List<Tuple<DateTime, double>> dataset, DateTime fromDate, DateTime toDate);
    }
}
