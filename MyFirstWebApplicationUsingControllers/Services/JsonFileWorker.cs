﻿using System;
using System.Collections.Generic;
using System.IO;
using MyFirstWebApplicationUsingControllers.Models;
using Newtonsoft.Json;

namespace MyFirstWebApplicationUsingControllers.Services
{
    public class JsonFileWorker : IDataWorker
    {
        private const string Filename = "values.json";
        public void AddData(int value)
        {
            ClearFileIfNewDayStarted();
            using (var streamWriter = new StreamWriter(Filename, true))
            {
                streamWriter.WriteLine(JsonConvert.SerializeObject(new Record(value)));
            }
        }

        public int GetSum(int from, int till)
        {
            ClearFileIfNewDayStarted();
            var json = ReadJson();
            var fromIndex = FindFromIndex(from, json);
            var tillIndex = FindTillIndex(till, json);
            if (fromIndex == -1 || tillIndex == -1)
                return 0;
            var result = 0;
            for (var i = fromIndex; i <= tillIndex; i++)
            {
                result += json[i].Value;
            }

            return result;
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

        private static int FindFromIndex(int from, List<Record> json)
        {
            if (json[0].Time >= from)
                return 0;
            for (var i = 1; i < json.Count; i++)
            {
                if (json[i - 1].Time < from && from <= json[i].Time)
                    return i;
            }

            return -1;
        }

        private static int FindTillIndex(int till, List<Record> json)
        {
            var lastIndex = json.Count - 1;
            if (lastIndex != 0)
                if (json[lastIndex].Time <= till)
                    return lastIndex;
            for (var i = 0; i < lastIndex; i++)
            {
                if (json[i].Time <= till && till < json[i + 1].Time)
                    return i;
            }

            return -1;
        }
    }
}
