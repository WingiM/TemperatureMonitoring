using System;

namespace TemperatureMonitoring.Core
{
    public class Product
    {
        public string Name { get; set; }
        public int MinTemperature { get; set; }
        public TimeSpan MinTemperatureTimeToStore { get; set; }
        public int MaxTemperature { get; set; }
        public TimeSpan MaxTemperatureTimeToStore { get; set; }

        public Product(string name, int minTemperature, TimeSpan minTemperatureTimeToStore, int maxTemperature, TimeSpan maxTemperatureTimeToStore)
        {
            Name = name;
            MinTemperature = minTemperature;
            MinTemperatureTimeToStore = minTemperatureTimeToStore;
            MaxTemperature = maxTemperature;
            MaxTemperatureTimeToStore = maxTemperatureTimeToStore;
        }
    }
}