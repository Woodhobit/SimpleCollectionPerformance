using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Loggers;

namespace ArrayPoolPerformance
{
    public class CustomConfig : ManualConfig
    {
        public CustomConfig()
        {
            Add(Job.Default
                .With(new GcMode()
                {
                    Force = false // tell BenchmarkDotNet not to force GC collections after every iteration
            }));

            Add(StatisticColumn.Max);
            Add(ConsoleLogger.Default); 
        }
    }
}
