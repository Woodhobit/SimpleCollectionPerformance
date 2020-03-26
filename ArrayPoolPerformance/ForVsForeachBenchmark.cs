using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;

namespace ArrayPoolPerformance
{
    [MemoryDiagnoser]
    [Config(typeof(CustomConfig))]
    public class ForVsForeachBenchmark
    {
        [Params(
            10, 
            100, 
            1000,
            10000
          // 100000,
           // 1000000
            )]
        public int Capacity { get; set; }

        private List<double> DoubleList;
        private List<User> UserList;
        private byte[] DoubleArray;
        private User[] UserArray;

        [GlobalSetup]
        public void GlobalSetup()
        {
            var random = new Random();

            this.DoubleList = new List<double>(this.Capacity);
            this.DoubleList.ForEach(x => x = random.NextDouble());

            this.DoubleArray = new byte[this.Capacity];
            random.NextBytes(this.DoubleArray);

            this.UserList = new List<User>(this.Capacity);
            this.UserList.ForEach(x => x = new User());

            this.UserArray = UserList.ToArray();
        }

        [Benchmark(Description = "Foreach with a list of value type")]
        public void ForeachValueType()
        {
            foreach (var item in this.DoubleList)
            {
                // var temp = item;
            }
        }

        [Benchmark(Description = "Foreach with a list of reference type")]
        public void ForeachReferenceType()
        {
            foreach (var item in this.UserList)
            {
              //  item.Age = 23;
            }
        }

        [Benchmark(Description = "Foreach with an array of reference type")]
        public void ForeachArrayReferenceType()
        {
            foreach (var item in this.UserArray)
            {
               // item.Age = 23;
            }
        }

        [Benchmark(Description = "For with an array of reference type")]
        public void ForReferenceType()
        {
            for (int i = 0; i < this.UserArray.Length; i++)
            {
                //  this.UserArray[i].Age = 23;
            }
        }

        [Benchmark(Description = "Foreach with an array of value type")]
        public void ForeachArrayValueType()
        {
            foreach (var item in this.DoubleArray)
            {
               // var temp = item;
            }
        }

        [Benchmark(Description = "For with an array of value type")]
        public void ForValueType()
        {
            for (int i = 0; i < this.DoubleArray.Length; i++)
            {
               // var temp = this.DoubleArray[i];
            }
        }
    }
}
