using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace ArrayPoolPerformance
{
    [MemoryDiagnoser]
    [Config(typeof(CustomConfig))]
    public class FixedListBenchmark
    {
        [Params(9,17,35,65,130,260,560,1052, 2200, 4500)]
        public int Capacity { get; set; }


        [Benchmark(Description = "Without size initialization")]
        public void WithoutInit()
        {
            var userToEdit = new List<User>();

            for (int i = 0; i < Capacity; i++)
            {
                // Do something

                userToEdit.Add(new User());
            }
        }

        [Benchmark(Description = "With size initialization")]
        public void WithInit()
        {
            var userToEdit = new List<User>(this.Capacity);

            for (int i = 0; i < Capacity; i++)
            {
                // Do something

                userToEdit.Add(new User());
            }
        }
    }
}
