using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpCalculator;
using NUnit.Framework;

namespace CalculatorEPAM
{
    
    [TestFixture(Category = "Divide")]
    public class DivideTests
    {
        private Calculator calculator;

        [OneTimeSetUp]
        public void SetUpFixture()
        {
            calculator = new Calculator();
        }

        private static object[] positiveTests =
        {
            new double[] { 1, 2, 0.5},
            new double[] { double.PositiveInfinity, double.NegativeInfinity, double.NaN},
            new double[] { double.PositiveInfinity, 5, double.PositiveInfinity},
            new double[] { 5 , 0, double.PositiveInfinity},
            new double[] { 0 , double.NegativeInfinity, 0},
            new double[] { double.Epsilon, double.Epsilon, 1},
            new double[] { 1, 0.4, 2.5}
        };

        [Test, TestCaseSource("positiveTests")]
        [Category("Positive")]
        public void TestPositiveCases(double first, double second, double expected)
        {
            Assert.AreEqual(calculator.Divide(first, second), expected);
        }

        [Test]
        [Category("Negative")]
        public void Test_NegativeCases()
        {
          
        }
    }
}
