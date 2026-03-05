using System.Security.Cryptography.X509Certificates;

namespace ArrayAndFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetSumDigitOfNumber(123));
            Console.WriteLine(GetSumDigitOfNumber(-15));
        }
        public static void Swap(ref int left,ref int right)
        {
            int tmp = left;
            left = right;
            right = tmp;
        }
    public static int GetSumDigitOfNumber(int number)
    {
            int sum = 0;
            number = number < 0 ? -number : number;
            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }
            return sum;
        }
}
}