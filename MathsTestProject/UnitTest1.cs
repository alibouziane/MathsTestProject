using System;
using MathComponent;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace MathsTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAdd()
        {
            var obj = new MathsComponent();
            int result = obj.Add(10, 10);
            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void TestSubstruct()
        {
            var obj = new MathsComponent();
            int result = obj.Substruct(10, 10);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void WHenMultipleFiveReturnBuzz()
        {
            var obj = new MathsComponent();
            string result = obj.FizzBuz(5);
            Assert.AreEqual(result, "Buzz");
        }

        [TestMethod]
        public void WhenMultipleThreeReturnFizz()
        {
            var obj = new MathsComponent();
            string result = obj.FizzBuz(3);
            Assert.AreEqual(result, "Fizz");
        }

        [TestMethod]
        public void WHenMultipleFiveAndMultipleThreeThanReturnFizzBuzz()
        {
            var obj = new MathsComponent();
            string result = obj.FizzBuz(15);
            Assert.AreEqual(result, "FizBuzz");
        }

        [TestMethod]
        public void WhenGreatherThan100ReturnException()
        {
            var obj = new MathsComponent();
            try
            {
                string result = obj.FizzBuz(1000);
                Assert.Fail("no exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "Not Allowed beacause it is Greather Than 100");
            }
        }

        [TestMethod]
        public void IspalindromTest()
        {
            var obj = new MathsComponent();
            bool result = obj.IsPalindrom("civic");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IspalindromTest2()
        {
            var obj = new MathsComponent();
            bool result = obj.IsPalindrom2("civic");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void WhenNumbersSeparatedWithEitherNewLineANdCommaReturnSum()
        {
            string input = "3\n4,-2";
            int expected = 5;

            var obj = new MathsComponent();
            int result = obj.StringCalculator(input);
            Assert.AreEqual(result, expected);


        }

    }
}
