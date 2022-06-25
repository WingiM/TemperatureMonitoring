using System;
using System.Collections.Generic;

namespace TemperatureMonitoring.Core
{
    public class AnalyzeResult
    {
        private readonly List<string> _results;
        private readonly Product _product;
        private TimeSpan _minimumTemperatureStoringTime;
        private TimeSpan _maximumTemperatureStoringTime;

        public AnalyzeResult(Product product)
        {
            _results = new();
            _product = product;
        }

        internal void AccountTransportingMistake(DateTime dateTime, int fact, int norm)
        {
            if (norm == _product.MaxTemperature)
                _maximumTemperatureStoringTime += TemperatureSensorAnalyzer.AnalyzingTimeInterval;
            else
                _minimumTemperatureStoringTime += TemperatureSensorAnalyzer.AnalyzingTimeInterval;
            
            _results.Add($"{dateTime};{fact};{norm};{fact - norm}");
        }
    }
}