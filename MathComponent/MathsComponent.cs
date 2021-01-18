using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

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
            var myArrayList = new System.Collections.ArrayList
            {
                System.Drawing.Color.Red,
                new System.Drawing.Point(0, 0),
                System.Drawing.Color.Green,
                new System.Drawing.Point(10, 20),
                System.Drawing.Color.Blue,
                new System.Drawing.Point(20, 30)
            };

            var query1 = myArrayList.OfType<System.Drawing.Color>().Select(color => color);

            foreach (var currentResult in query1)
                Console.WriteLine(currentResult.Name);



            var procesArray = new System.Collections.ArrayList();
            var query = procesArray.Cast<System.Diagnostics.Process>().Select(process => process);

        }
    }
    public class ProgramTuto
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

    public interface ITest1
    {
        void Method1();
        int Method2(bool isvalid);

    }
}
