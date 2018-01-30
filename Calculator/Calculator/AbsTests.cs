using NUnit.Framework;
using CSharpCalculator;

namespace CalculatorEPAM
{
    [TestFixture( Category = "Abs")]
    class AbsTests
    {
        private Calculator calculator;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            calculator = new Calculator();
        }

        private static object[] positiveCases =
        {
            new object[] { 0,0},
            new object[] { double.NegativeInfinity, double.PositiveInfinity},
            new object[] { -2,2},
            new object[] { double.Epsilon, double.Epsilon},
			new object[] { -1.23, 1.23},
			new object[] { -10.5, -10.5},
			new object[] { "-15", 15 },
			new object[] { "-17.2", 17.2}
		};

        [Test]
        [Category("Positive"),TestCaseSource("positiveCases")]
        public void Test_PositiveCases(object value, object expected)
        {
            Assert.AreEqual(calculator.Abs(value), expected);
        }

		[Test]
		[Category("Negative"),TestCaseSource("negativeCases")]
		public void Test_NegativeCases()
		{

		}
    }
}
