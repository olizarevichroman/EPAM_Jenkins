using NUnit.Framework;
using CSharpCalculator;

namespace CalculatorProject
{
	[TestFixture(Category = "Sum")]
	class SumTests
	{
		private Calculator calculator;

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			calculator = new Calculator();
		}

		private static readonly object[] positiveTests =
		{
			new double[] { 1 ,0 ,1},
			new double[] { double.MaxValue, double.MinValue, 0},
			new double[] { double.MaxValue, double.MaxValue, double.PositiveInfinity},
			new double[] { double.MinValue, double.MinValue, double.NegativeInfinity},
		};

		[Test, TestCaseSource("positiveTests",Category ="Positive")]
		public void Tests_positidsfveCases(object firstTerm, object secondTerm, object expected)
		{
			Assert.AreEqual(calculator.Add(firstTerm,secondTerm),expected);
		}

		private static readonly object[] positiveaTests =
		{
			new double[] { 10, 10 , 20},
			new double[] { -100, 50, -50}
		};

		[Test, TestCaseSource("positiveaTests", Category = "Positive")]
		public void Tests_positiveaCases(object firstTerm, object secondTerm, object expected)
		{
			Assert.AreEqual(calculator.Add(firstTerm, secondTerm), expected);
		}

	}
}
