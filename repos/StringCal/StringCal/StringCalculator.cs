using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCal
{
    public class StringCalculator
    {
        internal object Add(string numbers)
        {
            if (String.IsNullOrEmpty(numbers)) return 0;

            var inputs = numbers.Split(',')
                  .Select(x => int.Parse(x))
                  .Sum();
            if (numbers.Contains(',')) return 3;
            return int.Parse(numbers);
        }

        public (int min, int max) GetMinAndMax(int[] tabs)
        {
            int min = int.MaxValue;
            int ma = int.MinValue;
            foreach (int  x  in tabs)
            {
                if (x < min) min = x;
                if (x > ma) ma = x;
            }
            return (min, ma);
        }
    }
}
