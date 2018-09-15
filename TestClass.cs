using System.Threading;
using System.Threading.Tasks;

namespace AsyncTest
{
    public class TestClass
    {
        public TestClass()
        {
        }

        public int DoWork1(int num1, int num2)
        {
            return CalcSum(num1, num2);
        }

        public int DoWork2(int num1, int num2)
        {
            Task<int> task = CalcSumAsync(num1, num2);
            task.Wait();
            return task.Result;
        }

        public int CalcNumber(int num)
        {
            Thread.Sleep(1500);

            return num;
        }

        public async Task<int> CalcNumberAsync(int num)
        {
            Task<int> task = Task.Run(() => CalcNumber(num));
            return await task;
        }

        public int CalcSum(int num1, int num2)
        {
            int result1 = CalcNumber(num1);
            int result2 = CalcNumber(num2);
            int sum = result1 + result2;

            return sum;
        }

        public async Task<int> CalcSumAsync(int num1, int num2)
        {
            Task<int> task1 = CalcNumberAsync(num1);
            Task<int> task2 = CalcNumberAsync(num2);
            int result1 = await task1;
            int result2 = await task2;
            int sum = result1 + result2;

            return sum;
        }
    }
}
