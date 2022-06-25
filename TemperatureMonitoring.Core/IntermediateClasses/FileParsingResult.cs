using System;

namespace TemperatureMonitoring.Core.IntermediateClasses
{
    public class FileParsingResult
    {
        public DateTime InitiateDate { get; init; }
        public int[] Temperatures { get; init; }
    }
}