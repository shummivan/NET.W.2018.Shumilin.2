using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_day2;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 33, 13, 430, 3030, 003 };

            Tasks h = new Tasks();

            List<int> l = h.FindDigit(numbers, 3);

            foreach(int t in l)
            {
                Console.WriteLine(t);
            }

            //Console.WriteLine(h.FindNextBiggerNumber(14);

            Console.WriteLine(h.InsertNumber(8, 15, 3, 8));

            Console.WriteLine(h.FindNthRoot(0.04100625, 4, 0.0001));

            Console.ReadKey();
        }
    }
}
