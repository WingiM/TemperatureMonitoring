using System;
using System.IO;
using System.Linq;
using TemperatureMonitoring.Core.IntermediateClasses;
using TemperatureMonitoring.Core.Interfaces;

namespace TemperatureMonitoring.Core
{
    public class FileWorker : IFileWorker
    {
        public FileParsingResult ParseFile(string filename)
        {
            try
            {
                using StreamReader fs = new(File.Open(filename, FileMode.Open, FileAccess.Read));
                DateTime initiateDateTime = DateTime.Parse(fs.ReadLine());
                int[] temperatureValues = fs.ReadLine().Split().Select(int.Parse).ToArray();

                return new FileParsingResult { InitiateDate = initiateDateTime, Temperatures = temperatureValues};
            }
            catch (Exception e)
            {
                throw new FileReadException($"Error reading file {filename}", e);
            }
        }

        public void SaveToFile(AnalyzeResult result, string verdict, string filename)
        {
            try
            {
                using StreamWriter sw = new(File.Open(filename, FileMode.Create, FileAccess.Write));
                foreach (var line in result.Results)
                {
                    sw.WriteLine(line);
                }
                sw.WriteLine(verdict);
            }
            catch (Exception e)
            {
                throw new FileReadException($"Error reading file {filename}", e);
            }
        }
    }
}