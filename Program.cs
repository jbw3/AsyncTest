using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncTest
{
    public class Program
    {
        public static async Task Main()
        {
            await WhenAllTest();
        }

        public static Task WhenAllTest()
        {
            IEnumerable<Task> tasks = Enumerable.Range(0, 128).Select(i => Task.Delay(1000).ContinueWith(t => Console.Write($"{i} ")));

            Task masterTask = Task.WhenAll(tasks).ContinueWith(t => Console.WriteLine());
            return masterTask;
        }

        public static void FileTest(ICsvReader csvReader)
        {
            Stopwatch sw = Stopwatch.StartNew();

            long count = csvReader.Rows.LongCount();

            sw.Stop();

            Console.WriteLine($"Count: {count}, Time: {sw.Elapsed}");
        }

        public static void BasicTest()
        {
            TestClass tc = new TestClass();

            Stopwatch sw = new Stopwatch();
            sw.Start();

            int sum = tc.CalcSum(1, 2);

            sw.Stop();

            Console.WriteLine($"Sum: {sum}, Time: {sw.Elapsed}");
        }

        public static async Task BasicTestAsync()
        {
            TestClass tc = new TestClass();

            Stopwatch sw = new Stopwatch();
            sw.Start();

            int sum = await tc.CalcSumAsync(1, 2);

            sw.Stop();

            Console.WriteLine($"Sum: {sum}, Time: {sw.Elapsed}");
        }
    }
}
