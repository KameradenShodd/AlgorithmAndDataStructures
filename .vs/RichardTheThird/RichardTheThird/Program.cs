namespace Prog
{
    internal class Program
    {
        static void Main(string[] args) {
            string str1 = "asd dsa";
            string str2 = "asdsa";
            string str3 = "asd";
            Console.WriteLine(ActuallyAPerfectDamnSolution(str1));
            Console.WriteLine(ActuallyAPerfectDamnSolution(str2));
            Console.WriteLine(ActuallyAPerfectDamnSolution(str3));
            Console.WriteLine();
            Console.WriteLine(ThatSolutionIsQuiteCringeIwouldSay(str1));
            Console.WriteLine(ThatSolutionIsQuiteCringeIwouldSay(str2));
            Console.WriteLine(ThatSolutionIsQuiteCringeIwouldSay(str3));
            int[] arr = { 1, 2, 3, 2, 1, 5, 10, 1, 2, 3, 1, 1, 1 };
            Console.WriteLine(AnotherQuestOhGOD(arr, 10) );
        }
        public static bool ActuallyAPerfectDamnSolution(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return false;
            string rev = "";
            foreach(var ch in str)
            {
                rev = ch+ rev;
            }
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != rev[i]) return false;
            }
            return true;
        }
        public static bool ThatSolutionIsQuiteCringeIwouldSay(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) { return false; }
            for (int left = 0, right = str.Length -1; left < right; left++, right--)
            {
                if (str[left] != str[right]) return false;
            }
            return true;
        }
        public static int AnotherQuestOhGOD(int[] arr, int k)
        {
            if (arr is null || arr.Length == 0) return 0;


            int top = 0, bottom = 0;
            int max = 0, sum = 0;
            while (true)
            {
                if (sum <= k && top < arr.Length)
                {
                    sum += arr[top];
                    top++;
                }
                else { max = max > top - bottom - 1 ? max : top - bottom - 1; sum -= arr[bottom]; bottom++; }
                if (top == arr.Length) break;
            }
            while (bottom < arr.Length)
            { max = max > top - bottom ? max : top - bottom;
                sum -= arr[bottom]; bottom++; }
            return max;
        }
    }
}