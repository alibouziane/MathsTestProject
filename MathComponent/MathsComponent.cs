using System;
using System.Linq;

namespace MathComponent
{
    public class MathsComponent
    {
        public int Add(int num1, int num2)
        {
            return num1 + num2;
        }

        public int Substruct(int num1, int num2)
        {
            return num1 - num2;
        }

        public string FizzBuz(int value)
        {
            if (value >= 1000)
                throw new Exception("Not Allowed beacause it is Greather Than 100");
            if (value % 5 == 0 && value % 3 == 0) return "FizBuzz";
            if (value % 5 == 0) return "Buzz";
            else if (value % 3 == 0) return "Fizz";
            else return value.ToString();
        }


        public bool IsPalindrom(string input)
        {
            if (input == null) return false;
            var min = 0;
            var max = input.Length - 1;

            while (min < max)
            {
                if (input[min] != input[max]) return false;
                min++;
                max--;
            }
            return true;
        }

        public bool IsPalindrom2(string input)
        {
            return input != null && input.SequenceEqual(input.Reverse());
        }

        public int StringCalculator(string input)
        {

            var inputs = input.Split('\n', ',');

            return inputs.Sum(int.Parse);

        }
    }
}
