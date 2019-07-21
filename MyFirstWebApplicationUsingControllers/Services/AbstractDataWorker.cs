using System.Collections.Generic;
using MyFirstWebApplicationUsingControllers.Models;

namespace MyFirstWebApplicationUsingControllers.Services
{
    public abstract class AbstractDataWorker : IDataWorker
    {
        public abstract void AddData(int value);
        public abstract int GetSum(int from, int till);

        protected static int GetSum(int from, int till, List<Record> records)
        {
            if (records == null || records.Count == 0)
                return 0;
            var fromIndex = FindFromIndex(from, records);
            var tillIndex = FindTillIndex(till, records);
            if (fromIndex == -1 || tillIndex == -1)
                return 0;
            var result = 0;
            for (var i = fromIndex; i <= tillIndex; i++)
            {
                result += records[i].Value;
            }

            return result;
        }
        private static int FindFromIndex(int from, List<Record> records)
        {
            if (records[0].Time >= from)
                return 0;
            for (var i = 1; i < records.Count; i++)
            {
                if (records[i - 1].Time < from && from <= records[i].Time)
                    return i;
            }

            return -1;
        }

        private static int FindTillIndex(int till, List<Record> records)
        {
            var lastIndex = records.Count - 1;
            if (lastIndex != 0)
                if (records[lastIndex].Time <= till)
                    return lastIndex;
            for (var i = 0; i < lastIndex; i++)
            {
                if (records[i].Time <= till && till < records[i + 1].Time)
                    return i;
            }

            return -1;
        }
    }
}
