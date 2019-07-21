using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyFirstWebApplicationUsingControllers.Models;

namespace MyFirstWebApplicationUsingControllers.Services
{
    public class DbWorker : AbstractDataWorker
    {
        private RecordContext _db;

        public DbWorker(RecordContext context)
        {
            _db = context;
        }
        public override void AddData(int value)
        {
            _db.Records.Add(new Record(value));
            _db.SaveChanges();
        }

        public override int GetSum(int from, int till)
        {
            return GetSum(from, till, _db.Records.ToList());
        }
    }
}
