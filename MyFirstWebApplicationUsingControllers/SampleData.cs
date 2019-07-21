using System.Linq;
using MyFirstWebApplicationUsingControllers.Models;

namespace MyFirstWebApplicationUsingControllers
{
    public static class SampleData
    {
        public static void Initialize(RecordContext context)
        {
            if (context.Records.Any()) return;
            context.Records.AddRange(
                new Record(100, 1000),
                new Record(100, 1060),
                new Record(100,1111)
            );
            context.SaveChanges();
        }
    }
}
