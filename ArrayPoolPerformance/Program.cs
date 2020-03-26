using BenchmarkDotNet.Running;

namespace ArrayPoolPerformance
{
    class Program
    {
        static void Main(string[] args)
        {
           // BenchmarkRunner.Run<PoolingBenchmark>();
          //  BenchmarkRunner.Run<FixedListBenchmark>();
            BenchmarkRunner.Run<ForVsForeachBenchmark>();
        }
    }
}
