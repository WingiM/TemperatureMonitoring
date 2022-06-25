using System;

namespace TemperatureMonitoring.Core
{
    public interface ITemperatureAnalyzer
    {
        public AnalyzeResult AnalyzeFromFile(Product product, string filename);
        public AnalyzeResult AnalyzeFromInput(Product product, DateTime initiateDateTime, int[] temperatureValues);
        public void SaveToFile(AnalyzeResult result, string filename, string verdict);
    }
}