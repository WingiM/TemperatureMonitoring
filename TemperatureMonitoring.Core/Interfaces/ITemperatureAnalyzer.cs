using System;
using TemperatureMonitoring.Core.IntermediateClasses;

namespace TemperatureMonitoring.Core.Interfaces
{
    public interface ITemperatureAnalyzer
    {
        public AnalyzeResult Analyze(Product product, DateTime initiateDateTime, int[] temperatureValues);
        public AnalyzeResult Analyze(Product product, FileParsingResult parsingResult);
    }
}