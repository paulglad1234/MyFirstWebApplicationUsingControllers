using System;

namespace MyFirstWebApplicationUsingControllers.Models
{
    public class Record
    {
        public int RecordId { get; set; }
        public int Value { get; set; }
        public int Time { get; set; }

        public Record(int value, int time = -1)
        {
            Value = value;
            var now = DateTime.Now;
            Time = time == -1 ? now.Hour * 3600 + now.Minute * 60 + now.Second : time;
        }
    }
}
