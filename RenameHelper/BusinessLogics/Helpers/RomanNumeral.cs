using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameHelper.BusinessLogics.Helpers
{
    public class RomanNumeral
    {
        const int MIN_ROMAN_NUMERAL = 1;
        const int MAX_ROMAN_NUMERAL = 3999;

        string[] ones, tens, hundreds, thousands;
        string[][] converter;

        public RomanNumeral()
        {
            ones = new string[] { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
            tens = new string[] { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            hundreds = new string[] { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
            thousands = new string[] { "", "M", "MM", "MMM" };
            converter = new string[][] { ones, tens, hundreds, thousands };
        }

        public string GetValue(int number)
        {
            if (number < MIN_ROMAN_NUMERAL || number > MAX_ROMAN_NUMERAL)
                throw new RenameErrorException(RenameErrorInfo.OutOfRomanNumeralsRange);

            // Get digits from ones to thousands
            var digits = number.ToString().Reverse().Select(c => Convert.ToInt32(c.ToString())).ToArray();
            // Converter to Roman numeral
            string romanNumeral = "";
            for (int idx = 0; idx < digits.Length; idx++)
            {
                romanNumeral += converter[idx][digits[idx]];
            }
            return romanNumeral;
        }
    }
}
