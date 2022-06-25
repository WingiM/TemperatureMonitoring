using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TemperatureMonitoring.Core.Interfaces;

namespace TemperatureMonitoring.Core.Tests
{
    public class Tests
    {
        private static string TestFile = @"C:\Users\wingi\RiderProjects\TemperatureMonitoring\TemperatureMonitoring.Core.Tests\testFiles\test1.txt";
        private static string WrongFormatFile = @"C:\Users\wingi\RiderProjects\TemperatureMonitoring\TemperatureMonitoring.Core.Tests\testFiles\test2.txt";
        private static string NotExistingFile = @"C:\Users\202026\source\repos\TemperatureMonitoring\TemperatureMonitoring.Core.Tests\testFiles\test123.txt";
        private ITemperatureAnalyzer _analyzer;
        private IFileWorker _fileWorker;
        [SetUp]
        public void Setup()
        {
            _analyzer = new TemperatureSensorAnalyzer();
            _fileWorker = new FileWorker();
        }

        [Test]
        public void BadShipmentWithAllTemperatures()
        {
            DateTime initiateDate = new DateTime(2022, 6, 12, 12, 23, 0);
            int[] temperatures = { 1, 2, 3, 3, 4, 3, 5, 4, 2, 1, 1, 1, 1, 0, -1, -2, -2, -3, -4, -4, -5, -5, -4, -4, -4, -3 };
            Product product = new Product
            {
                Name = "Семга", MaxTemperature = 5, MaxTemperatureTimeToStore = TimeSpan.FromMinutes(20),
                MinTemperature = -3, MinTemperatureTimeToStore = TimeSpan.FromMinutes(60)
            };

            List<string> expectedLines = new()
            {
                "12.06.2022 15:23;-4;-3;-1",
                "12.06.2022 15:33;-4;-3;-1",
                "12.06.2022 15:43;-5;-3;-2",
                "12.06.2022 15:53;-5;-3;-2",
                "12.06.2022 16:03;-4;-3;-1",
                "12.06.2022 16:13;-4;-3;-1",
                "12.06.2022 16:23;-4;-3;-1"
            };
            var expectedMinTempDuration = TimeSpan.FromMinutes(70);
            
            var result = _analyzer.Analyze(product, initiateDate, temperatures);
            
            Assert.That(result.MinimumTemperatureStoringTime, Is.EqualTo(expectedMinTempDuration), "Wrong storing time");
            Assert.IsTrue(result.Results.SequenceEqual(expectedLines), "Wrong result lines");
        }

        [Test]
        public void BadShipmentWithNoMinTemperature()
        {
            DateTime initiateDate = new DateTime(2022, 6, 14, 06, 17, 0);
            int[] temperatures = { -10, -8, -4, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -2, -4, -4, -5, -5, -4, -4, -4 };
            Product product = new Product
            {
                Name = "Минтай", MaxTemperature = -5, MaxTemperatureTimeToStore = TimeSpan.FromMinutes(20)
            };

            List<string> expectedLines = new()
            {
                "14.06.2022 06:37;-4;-5;1",
                "14.06.2022 06:47;-2;-5;3",
                "14.06.2022 06:57;-2;-5;3",
                "14.06.2022 07:07;-2;-5;3",
                "14.06.2022 07:17;-2;-5;3",
                "14.06.2022 07:27;-2;-5;3",
                "14.06.2022 07:37;-2;-5;3",
                "14.06.2022 07:47;-2;-5;3",
                "14.06.2022 07:57;-2;-5;3",
                "14.06.2022 08:07;-2;-5;3",
                "14.06.2022 08:17;-2;-5;3",
                "14.06.2022 08:27;-2;-5;3",
                "14.06.2022 08:37;-2;-5;3",
                "14.06.2022 08:47;-2;-5;3",
                "14.06.2022 08:57;-2;-5;3",
                "14.06.2022 09:07;-2;-5;3",
                "14.06.2022 09:17;-4;-5;1",
                "14.06.2022 09:27;-4;-5;1",
                "14.06.2022 09:57;-4;-5;1",
                "14.06.2022 10:07;-4;-5;1",
                "14.06.2022 10:17;-4;-5;1"
            };
            var expectedMaxTempDuration = TimeSpan.FromMinutes(210);
            
            var result = _analyzer.Analyze(product, initiateDate, temperatures);
            
            Assert.That(result.MaximumTemperatureStoringTime, Is.EqualTo(expectedMaxTempDuration), "Wrong storing time");
            Assert.IsTrue(result.Results.SequenceEqual(expectedLines), "Wrong result lines");
        }

        [Test]
        public void BadShipmentFromFile()
        {
            Product product = new Product
            {
                Name = "Семга", MaxTemperature = 5, MaxTemperatureTimeToStore = TimeSpan.FromMinutes(20),
                MinTemperature = -3, MinTemperatureTimeToStore = TimeSpan.FromMinutes(60)
            };

            List<string> expectedLines = new()
            {
                "12.06.2022 15:23;-4;-3;-1",
                "12.06.2022 15:33;-4;-3;-1",
                "12.06.2022 15:43;-5;-3;-2",
                "12.06.2022 15:53;-5;-3;-2",
                "12.06.2022 16:03;-4;-3;-1",
                "12.06.2022 16:13;-4;-3;-1",
                "12.06.2022 16:23;-4;-3;-1"
            };
            var expectedMinTempDuration = TimeSpan.FromMinutes(70);

            var parsingResult = _fileWorker.ParseFile(TestFile);
            var result = _analyzer.Analyze(product, parsingResult);
            
            Assert.That(result.MinimumTemperatureStoringTime, Is.EqualTo(expectedMinTempDuration), "Wrong storing time");
            Assert.IsTrue(result.Results.SequenceEqual(expectedLines), "Wrong result lines");
        }

        [Test]
        public void NoTemperatures()
        {
            Product product = new Product();
            
            var parsingResult = _fileWorker.ParseFile(TestFile);
            var result = _analyzer.Analyze(product, parsingResult);
            
            Assert.That(result.MaximumTemperatureStoringTime, Is.EqualTo(TimeSpan.Zero));
            Assert.That(result.MinimumTemperatureStoringTime, Is.EqualTo(TimeSpan.Zero));
            Assert.IsTrue(result.Results.Count == 0);
        }

        [Test]
        public void NotExistingFileParsing()
        {
            Assert.Throws<FileReadException>(() => _fileWorker.ParseFile(NotExistingFile));
        }

        [Test]
        public void WrongFormatFileParsing()
        {
            Assert.Throws<FileReadException>(() => _fileWorker.ParseFile(WrongFormatFile));
        }
    }
}