using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {   string myListNum = "8, 18, 23, 1, 104, 212, 92, 152, 33, 11";


            int[] myArrayNum = { 8, 18, 23, 1, 104, 212, 92, 152, 33, 11};
            int maxNum = myArrayNum.Max();
            Console.WriteLine(maxNum);
        }
    }
}
