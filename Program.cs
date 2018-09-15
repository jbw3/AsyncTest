using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AsyncTest
{
    class Program
    {
        static void Main()
        {
            TestClass tc = new TestClass();

            Stopwatch sw = new Stopwatch();
            sw.Start();

            // int sum = tc.DoWork1(1, 2);
            int sum = tc.DoWork2(1, 2);

            sw.Stop();

            Console.WriteLine($"Sum: {sum}, Time: {sw.Elapsed}");
        }
    }
}
