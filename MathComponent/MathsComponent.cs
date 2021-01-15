using System;
using System.Collections.Generic;
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


    public class diverse
    {
        private void Method()
        {
            System.Collections.ArrayList myArrayList = new System.Collections.ArrayList();
            myArrayList.Add(System.Drawing.Color.Red);
            myArrayList.Add(new System.Drawing.Point(0, 0));
            myArrayList.Add(System.Drawing.Color.Green);
            myArrayList.Add(new System.Drawing.Point(10, 20));
            myArrayList.Add(System.Drawing.Color.Blue);
            myArrayList.Add(new System.Drawing.Point(20, 30));

            //var query = from color in myArrayList.OfType<System.Drawing.Color>() > ()
            //            select color;

            //foreach (var currentResult in query)
            //    Console.WriteLine(currentResult.Name);
        }
    }
    class ProgramTuto
    {
        static void Main(string[] args)
        {
            List<string> aMembres = new List<string>()
                   {
                       "Jérôme",
                       "Louis-Guillaume",
                       "Vincent",
                       "Benjamin"
                   };

            var query = aMembres.OrderBy(membre => membre);

            Console.WriteLine("Résultat query Avant");
            Console.WriteLine("********************");
            foreach (string currentMembre in query)
            {
                Console.WriteLine(currentMembre);
            }

            aMembres.Add("Thomas");

            Console.WriteLine("\nRésultat query Après");
            Console.WriteLine("********************");
            foreach (string currentMembre in query)
            {
                Console.WriteLine(currentMembre);
            }

            Console.Read();
        }

        static void Main2(string[] args)
        {
            List<string> aMembres = new List<string>()

                   {
                "Jérôme",
                       "Louis-Guillaume",
                       "Vincent",
                       "Benjamin"

                   };

            var query = aMembres.OrderBy(membre => membre);

            Console.WriteLine("Résultat query Avant");
            Console.WriteLine("********************");
            foreach (string currentMembre in query)
            {
                Console.WriteLine(currentMembre);
            }

            // Mise à  jour des membres
            aMembres[0] = aMembres[0] + " Lambert";
            aMembres[1] = aMembres[1] + " Morand";
            aMembres[2] = aMembres[2] + " Lainé";
            aMembres[3] = aMembres[3] + " Broux";

            Console.WriteLine("\nRésultat query Après");
            Console.WriteLine("********************");
            foreach (string currentMembre in query)
            {
                Console.WriteLine(currentMembre);
            }

            Console.Read();
        }
    }



}
