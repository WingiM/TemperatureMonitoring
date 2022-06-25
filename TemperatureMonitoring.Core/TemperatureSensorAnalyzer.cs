using System;
using TemperatureMonitoring.Core.IntermediateClasses;
using TemperatureMonitoring.Core.Interfaces;

namespace TemperatureMonitoring.Core
{
    public class TemperatureSensorAnalyzer : ITemperatureAnalyzer
    {
        internal static TimeSpan AnalyzingTimeInterval { get; } = TimeSpan.FromMinutes(10);

        public AnalyzeResult Analyze(Product product, DateTime initiateDateTime, int[] temperatureValues)
        {
            AnalyzeResult result = new(product);
            for (int i = 0; i < temperatureValues.Length; ++i, initiateDateTime += AnalyzingTimeInterval)
            {
                var res = IsTemperatureRight(product, temperatureValues[i]);
                if (res.IsOk)
                    continue;

                result.AccountTransportingMistake(initiateDateTime, res.FactTemperature, res.NormTemperature);
            }

            return result;
        }

        public AnalyzeResult Analyze(Product product,
            FileParsingResult parsingResult)
        {
            return Analyze(product, parsingResult.InitiateDate,
                parsingResult.Temperatures);
        }

        private ComparisionResult IsTemperatureRight(Product product, int temp)
        {
            if (temp < product.MinTemperature)
                return new ComparisionResult(false, temp, product.MinTemperature);
            if (temp > product.MaxTemperature)
                return new ComparisionResult(false, temp, product.MaxTemperature);

            if (product.MinTemperature == int.MinValue && product.MaxTemperature == int.MaxValue)
                return new ComparisionResult(true, temp, null);
            
            return new ComparisionResult(true, temp,
                Math.Abs(temp - product.MinTemperature) < Math.Abs(product.MaxTemperature - temp)
                    ? product.MinTemperature
                    : product.MaxTemperature);
        }
    }
}