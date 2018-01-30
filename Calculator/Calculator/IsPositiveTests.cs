using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CSharpCalculator;
using NUnit.Framework.Constraints;

namespace CalculatorEPAM
{
    [TestFixture(Category = "IsPositive")]
    class IsPositiveTests
    {
        private Calculator calculator;

        [OneTimeSetUp]
        public void SetUpFixture()
        {
            calculator = new Calculator();
        }

        private static object[] positiveTests =
        {
            new object[] { 0, false},
            new object[] { 1, true},
            new object[] {"1,23", true},
            new object[] { -double.Epsilon, false},
            new object[] { double.Epsilon, true},
            new object[] { double.NegativeInfinity, false},
            new object[] { double.PositiveInfinity, true},
            new object[] { double.MaxValue , true},
            new object[] { double.MinValue, false},
            new object[] { "1E+10", true},
        };

        [Test]
        [Category("Positive"),TestCaseSource("positiveTests")]
        public void Test_PositiveCases(object checkedValue, bool expected)
        {
            Assert.AreEqual(calculator.isPositive(checkedValue), expected);
        }

        private static object[] negativeTests =
        {
            new object[] { "0xFFF", typeof(NotFiniteNumberException)},
            new object[] { "number" , typeof(NotFiniteNumberException)},
            new object[] { string.Empty, typeof(NotFiniteNumberException)},
            new object[] { new StringBuilder(), typeof(NotFiniteNumberException)},
        };

        [Test]
        [Category("Negative"), TestCaseSource("negativeTests")]
        public void Test_NegativeCases(object checkedValue, Type exception)
        {
            Assert.That(() => calculator.isPositive(checkedValue), Throws.TypeOf(exception));
        }
    }
}
