using System;

namespace TemperatureMonitoring.Core
{
    public class Product
    {
        public string Name { get; init; }
        public int MinTemperature { get; init; } = int.MinValue;
        public TimeSpan MinTemperatureTimeToStore { get; init; }
        public int MaxTemperature { get; init; } = int.MaxValue;
        public TimeSpan MaxTemperatureTimeToStore { get; init; }
    }
}