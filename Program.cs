using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncTest
{
    class Program
    {
        static void Main()
        {
            FileTest(new SyncCsvReader("test.csv"));
            FileTest(new AsyncCsvReader("test.csv"));
        }

        static void FileTest(ICsvReader csvReader)
        {
            Stopwatch sw = Stopwatch.StartNew();

            long count = csvReader.Rows.LongCount();

            sw.Stop();

            Console.WriteLine($"Count: {count}, Time: {sw.Elapsed}");
        }

        static void BasicTest()
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
