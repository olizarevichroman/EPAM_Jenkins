using NUnit.Framework;
using CSharpCalculator;

namespace CalculatorProject
{
	[TestFixture(Category ="Multiply")]
	class MultiplyTests
	{
		private Calculator calculator;

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			calculator = new Calculator();
		}

		private static object[] positiveTests =
		{
			new object[] { double.MaxValue, 2 , double.PositiveInfinity},
			new object[] { double.MaxValue, 0, 0},
			new object[] { double.PositiveInfinity,0,double.NaN},
			new object[] { double.PositiveInfinity, double.NegativeInfinity, double.NaN},
			new object[] { double.NaN, double.NaN, double.NaN}
		};

		[Test]
		[TestCaseSource("positiveTests",Category = "Positive")]
		public void Tests_PositiveCases(double firstMultiplier, double secondMultiplier, double expected)
		{
			Assert.AreEqual(calculator.Multiply(firstMultiplier, secondMultiplier), expected);
		}

	}
}
