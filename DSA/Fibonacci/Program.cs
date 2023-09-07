
namespace Algorrithms
{
    class Program
    {
        static void Main()
        {
            //Console.WriteLine(Fibonacci(8));
            //Console.WriteLine(Factorial(6));
            //Console.WriteLine(FibWithMemoization(8));
            //foreach (var item in FibWithMemoizationYieldReturn(100))
            //{
            //Console.WriteLine(item);
            //if (item < 0) { break; }
            //}
            foreach(var item in BradleyBubbleSort())
                Console.WriteLine(item);
        }
        static int Fibonacci(int input)
        {
            if (input == 0) return 0;
            if (input == 1) return 1;

            return Fibonacci(input - 1) + Fibonacci(input - 2);
        }
        static int Factorial(int input)
        {
            if (input == 0) return 0;
            if (input == 1) return 1;


            return input * Factorial(input - 1);
        }
        static int[] FibWithMemoization(int input)
        {

            int[] fibKeeper = new int[input + 1];
            fibKeeper[0] = 0;
            fibKeeper[1] = 1;

            for (int i = 2; i <= fibKeeper.Length; i++)
            {
                fibKeeper[i] = fibKeeper[i - 1] + fibKeeper[i - 2];
            }
            return fibKeeper;
        }
        static IEnumerable<int> FibWithMemoizationYieldReturn(int input)
        {

            int[] fibKeeper = new int[input + 1];
            fibKeeper[0] = 0;
            fibKeeper[1] = 1;

            for (int i = 2; i <= fibKeeper.Length; i++)
            {
                fibKeeper[i] = fibKeeper[i - 1] + fibKeeper[i - 2];
                yield return fibKeeper[i];
            }
        }
        public static int[] BradleyBubbleSort()
        {
            int[] numArray = { 21, 13, 1, 54, 8, 66, 43, 12 };
            var n = numArray.Length;

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n - 1; j++)
                    if (numArray[j] > numArray[i])
                    {
                        int temp = numArray[j];
                        numArray[j] = numArray[i];
                        numArray[i] = temp;
                    }
                return numArray;
         }
    }
}