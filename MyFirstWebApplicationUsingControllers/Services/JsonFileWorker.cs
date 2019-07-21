using System;
using System.Collections.Generic;
using System.IO;
using MyFirstWebApplicationUsingControllers.Models;
using Newtonsoft.Json;

namespace MyFirstWebApplicationUsingControllers.Services
{
    public class JsonFileWorker : AbstractDataWorker
    {
        private const string Filename = "values.json";
        public override void AddData(int value)
        {
            ClearFileIfNewDayStarted();
            using (var streamWriter = new StreamWriter(Filename, true))
            {
                streamWriter.WriteLine(JsonConvert.SerializeObject(new Record(value)));
            }
        }

        public override int GetSum(int from, int till)
        {
            ClearFileIfNewDayStarted();
            return GetSum(from, till, ReadJson());
        }

        private static void ClearFileIfNewDayStarted()
        {
            var now = DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second;
            var clear = false;
            using (var streamReader = new StreamReader(Filename))
            {
                var first = streamReader.ReadLine();
                if (!string.IsNullOrEmpty(first))
                {
                    var firstObject = JsonConvert.DeserializeObject<Record>(first);
                    if (now < firstObject.Time)
                        clear = true;
                }
            }
            if (clear)
                File.WriteAllText(Filename, string.Empty);
        }
        private static List<Record> ReadJson()
        {
            var json = new List<Record>();
            using (var streamReader = new StreamReader(Filename))
            {
                var jRecord = streamReader.ReadLine();
                while (!string.IsNullOrEmpty(jRecord))
                {
                    json.Add(JsonConvert.DeserializeObject<Record>(jRecord));
                    jRecord = streamReader.ReadLine();
                }
            }

            return json;
        }
    }
}
