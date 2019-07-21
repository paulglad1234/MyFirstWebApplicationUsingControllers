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
            Time = time == -1 ? DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second : time;
        }
    }
}
