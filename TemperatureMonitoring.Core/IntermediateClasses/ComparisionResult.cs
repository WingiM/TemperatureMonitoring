namespace TemperatureMonitoring.Core.IntermediateClasses
{
    internal class ComparisionResult
    {
        public bool IsOk { get; }
        public int FactTemperature { get; }
        public int? NormTemperature { get; }

        public ComparisionResult(bool isOk, int factTemperature, int? normTemperature)
        {
            IsOk = isOk;
            FactTemperature = factTemperature;
            NormTemperature = normTemperature;
        }
    }
}