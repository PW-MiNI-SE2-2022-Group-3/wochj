using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stringCalculator
{
    public class Calculator
    {
        public static int SumString(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return "";

            char[] delimeters = new char[] { '\n', ',' };

            if(s.StartsWith("//"))
            {
                string[] parts = s.Split('\n',2);
                delimeters = delimeters.Concat(new char[] { s.ElementAt(2) }).ToArray();
                s = parts[1];
            }

            int[] numbers = s.Split(delimeters, StringSplitOptions.None)
                .Select(n => Int32.Parse(n)).Where(n => n < 1000)
                .ToArray();

            if (numbers.Any(n => n < 0))
                throw new ArgumentException();

            //numbers = (from n in numbers where n <= 1000 select n).ToArray();

          
                 
            return numbers.Sum();
        }

        private static IEnumerable<string> GetAdditionalDelimeters(string firstInput)
        {
            if (firstInput.Length > 3)
            {
                return new string[] { firstInput[3..^1] };
            }
            return new string[] { firstInput.Substring(2, 1) };
        }
    }
}
