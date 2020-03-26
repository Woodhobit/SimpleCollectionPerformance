using BenchmarkDotNet.Attributes;
using System;
using System.Buffers;

namespace ArrayPoolPerformance
{
    [MemoryDiagnoser]
    [Config(typeof(CustomConfig))]
    public class PoolingBenchmark
    {
        [Params(
            100,
            1000,     // 1 KB
            10000,    // 10 KB
            100000,   // 100 KB
            1000000,  // 1 MB
            10000000  // 10 MB
            )]
        public int SizeInBytes { get; set; }

        private const int COUNT = 1000;

        private Random byteGenerator { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            this.byteGenerator = new Random();
        }

        [Benchmark(Description = "Without pool")]
        public void WithoutPooling()
        {
            for (int i = 0; i < COUNT; i++)
            {
                var testArray = new byte[SizeInBytes];
                this.Payload(testArray);
            }
        }

        [Benchmark(Description = "Use array pool")]
        public void Pooling()
        {
            for (int i = 0; i < COUNT; i++)
            {
                var pool = ArrayPool<byte>.Shared;
                byte[] testArray = pool.Rent(SizeInBytes);
                this.Payload(testArray);
                pool.Return(testArray);
            }
        }

        private void Payload(byte[] array)
        {
            this.byteGenerator.NextBytes(array);
        }
    }
}
