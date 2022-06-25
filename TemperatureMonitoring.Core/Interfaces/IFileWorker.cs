using TemperatureMonitoring.Core.IntermediateClasses;

namespace TemperatureMonitoring.Core.Interfaces
{
    public interface IFileWorker
    {
        public FileParsingResult ParseFile(string filename);
        public void SaveToFile(AnalyzeResult result, string verdict, string filename);
    }
}