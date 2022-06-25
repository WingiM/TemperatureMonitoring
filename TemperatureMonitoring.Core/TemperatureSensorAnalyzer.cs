using System;
using System.IO;
using System.Linq;

namespace TemperatureMonitoring.Core
{
    public class TemperatureSensorAnalyzer : ITemperatureAnalyzer
    {
        internal static TimeSpan AnalyzingTimeInterval { get; } = TimeSpan.FromMinutes(10);

        public AnalyzeResult AnalyzeFromFile(Product product, string filename)
        {
            try
            {
                using StreamReader fs = new(File.Open(filename, FileMode.Open, FileAccess.Read));
                DateTime initiateDateTime = DateTime.Parse(fs.ReadLine());
                int[] temperatureValues = fs.ReadLine().Split().Select(int.Parse).ToArray();

                return AnalyzeFromInput(product, initiateDateTime, temperatureValues);
            }
            catch (Exception e)
            {
                throw new FileReadException($"Error reading file {filename}", e);
            }
        }

        public AnalyzeResult AnalyzeFromInput(Product product, DateTime initiateDateTime, int[] temperatureValues)
        {
            AnalyzeResult result = new(product);
            foreach (var temp in temperatureValues)
            {
                var res = IsTemperatureRight(product, temp);
                if (res.IsOk)
                {
                    initiateDateTime += AnalyzingTimeInterval;
                    continue;
                }
                
                result.AccountTransportingMistake(initiateDateTime, res.FactTemperature, res.NormTemperature);
                initiateDateTime += AnalyzingTimeInterval;
            }

            return result;
        }

        private ComparisionResult IsTemperatureRight(Product product, int temp)
        {
            if (temp < product.MinTemperature)
                return new ComparisionResult(false, temp, product.MinTemperature);
            if (temp > product.MaxTemperature)
                return new ComparisionResult(false, temp, product.MaxTemperature);
            return new ComparisionResult(true, temp,
                Math.Abs(temp - product.MinTemperature) < Math.Abs(product.MaxTemperature - temp)
                    ? product.MinTemperature
                    : product.MaxTemperature);
        }
    }
}