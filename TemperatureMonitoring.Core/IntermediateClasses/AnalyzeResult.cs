using System;
using System.Collections.Generic;

namespace TemperatureMonitoring.Core.IntermediateClasses
{
    public class AnalyzeResult
    {
        public readonly List<string> Results;
        public readonly Product Product;
        public TimeSpan MinimumTemperatureStoringTime;
        public TimeSpan MaximumTemperatureStoringTime;

        internal AnalyzeResult(Product product)
        {
            Results = new();
            Product = product;
        }

        internal void AccountTransportingMistake(DateTime dateTime, int fact, int? norm)
        {
            if (norm == Product.MaxTemperature)
                MaximumTemperatureStoringTime += TemperatureSensorAnalyzer.AnalyzingTimeInterval;
            else
                MinimumTemperatureStoringTime += TemperatureSensorAnalyzer.AnalyzingTimeInterval;
            
            Results.Add($"{dateTime:dd.MM.yyyy HH:mm};{fact};{norm};{fact - norm}");
        }
    }
}