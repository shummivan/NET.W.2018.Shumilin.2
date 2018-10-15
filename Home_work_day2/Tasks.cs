using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks_day2
{
    public class Tasks
    {
        #region Insert Number

        /// <summary>
        /// Check input params
        /// </summary>
        /// <param name="number1">Source number</param>
        /// <param name="number2">Number in</param>
        /// <param name="left">Left position</param>
        /// <param name="right">Right position</param>
        private static void CheckInputParams(int number1, int number2, int left, int right)
        {
            if (number1 <= 0 || number2 <= 0 || left > right || left < 0 || right < 0 || left > 31 || right > 31)
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// Insert number
        /// </summary>
        /// <param name="number1">Source number</param>
        /// <param name="number2">Number in</param>
        /// <param name="left">Left position</param>
        /// <param name="right">Right position</param>
        /// <returns></returns>
        public int InsertNumber(int number1, int number2, int left, int right)
        {
            CheckInputParams(number1, number2, left, right);
            int[] binary1 = new int[32];
            int[] binary2 = new int[32];

            binary1 = Convert.ToString(number1, 2).PadLeft(16, '0').Select(c => int.Parse(c.ToString())).ToArray();
            binary2 = Convert.ToString(number2, 2).PadLeft(16, '0').Select(c => int.Parse(c.ToString())).ToArray();

            for (int i = binary1.Length - 1 - left, j = binary2.Length - 1; i >= binary1.Length - 1 - right; i--, j--)
            {
                binary1[i] = binary2[j];
            }

            string result = String.Join("", binary1.Select(p => p.ToString()));

            return Convert.ToInt32(result, 2);
        }

        #endregion

        #region Find Next Bigger Number

        /// <summary>
        /// Find next bigger number
        /// </summary>
        /// <param name="target">Input number</param>
        /// <returns>Next bigger number</returns>
        public int FindNextBiggerNumber(int target, ref long elapsedTime)
        {
            Stopwatch sw = Stopwatch.StartNew();
            long startTime = sw.ElapsedMilliseconds;

            var arr = GetDigitArr(target);
            int temp = 0;
            int num = 0;

            for(int i = arr.Length - 1; i >= 0; i--)
            {
                temp = arr[i];
                arr[i] = arr[i - 1];
                arr[i - 1] = temp;

                num = GetInt(arr);

                if(target < num)
                {
                    Array.Sort(arr, i, arr.Length - i);
                    num = GetInt(arr);
                    elapsedTime = sw.ElapsedMilliseconds - startTime;

                    return num;                    
                }

                if(i == 1)
                {
                    elapsedTime = sw.ElapsedMilliseconds - startTime;
                    return -1;
                }
                

                arr = GetDigitArr(target);
            }

            elapsedTime = sw.ElapsedMilliseconds - startTime;
            return -1;
        }

        /// <summary>
        /// Get integet number from array
        /// </summary>
        /// <param name="arr">Array</param>
        /// <returns>Integer value</returns>
        private static int GetInt(int[] arr)
        {
            int finalScore = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                finalScore += arr[i] * Convert.ToInt32(Math.Pow(10, arr.Length - i - 1));
            }
            return finalScore;
        }

        /// <summary>
        /// Get digit array from number
        /// </summary>
        /// <param name="target">Integer number</param>
        /// <returns>Array digits of input number</returns>
        private static int[] GetDigitArr(int target)
        {
            if (target == 0)
            {
                return new int[1] { 0 };
            }

            var digits = new List<int>();

            for(; target != 0; target /= 10)
            {
                digits.Add(target % 10);
            }

            var arr = digits.ToArray();

            Array.Reverse(arr);

            return arr;
        }

        #endregion

        #region Find Digit
        /// <summary>
        /// Find digit in number
        /// </summary>
        /// <param name="numbers">List of numbers</param>
        /// <param name="target">Digit</param>
        /// <returns></returns>
        public List<int> FindDigit(List<int> numbers, int target)
        {            
            List<int> numbersWithDigit = new List<int>();

            int temp = 0;
            int[] arr = numbers.ToArray();

            CheckInputParams(arr, target);

            for(int i = 0; i < arr.Length; i++)
            {
                temp = arr[i];

                while(temp != 0)
                {
                    if(temp % 10 == target)
                    {
                        numbersWithDigit.Add(arr[i]);
                        break;                        
                    }

                    temp /= 10;
                }
            }
            return numbersWithDigit;
        }

        /// <summary>
        /// Check input params
        /// </summary>
        /// <param name="arr">List of numbers</param>
        /// <param name="target">Digit</param>
        private static void CheckInputParams(int[] arr, int target)
        {
            if (arr == null)
            {
                throw new ArgumentNullException();
            }

            if(target < 0 || target > 10)
            {
                throw new ArgumentException();
            }
        }
        #endregion

        #region FindNthRoot
        /// <summary>
        /// Find root degree by the Newton method 
        /// </summary>
        /// <param name="number">Number</param>
        /// <param name="rootDegree">Root degree</param>
        /// <param name="precision">Precision</param>
        /// <returns></returns>
        public double FindNthRoot(double number, int rootDegree, double precision)
        {
            CheckInputParams(rootDegree, precision);

            double currValue = number / rootDegree;
            double nextValue = ((rootDegree - 1) * currValue + number / Math.Pow(currValue, rootDegree - 1)) / rootDegree;

            while (Math.Abs(currValue - nextValue) > precision)
            {
                currValue = nextValue;
                nextValue = ((rootDegree - 1) * currValue + number / Math.Pow(currValue, rootDegree - 1)) / rootDegree;
            }
            return Math.Round(nextValue, 3);
        }

        /// <summary>
        /// Check input params
        /// </summary>
        /// <param name="rootDegree">Root degree</param>
        /// <param name="precision">Precision</param>
        private static void CheckInputParams(int rootDegree, double precision)
        {
            if(rootDegree <= 0 || precision <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        #endregion
    }

}
