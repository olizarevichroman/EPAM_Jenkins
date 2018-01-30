using NUnit.Framework;
using CSharpCalculator;
using System;

namespace CalculatorProject
{
	[TestFixture(Category = "Sin")]
	class SinTests
	{
		private Calculator calculator;

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			calculator = new Calculator();
		}

		private static readonly object[] positiveTests =
		{
			new double[] { 1 , Math.Sin(1)},
			new double[] { double.MaxValue, Math.Sin(double.MaxValue)},
			new double[] { double.MinValue, Math.Sin(double.MinValue)},
			new double[] { 0, Math.Sin(0)},
			new double[] { 0.35, Math.Sin(0.35)},
			new object[] { "0.11", Math.Sin(0.11)}
		};

		[Test, TestCaseSource("positiveTests", Category = "Positive")]
		public void Tests_positiveCases(object angle, double expected)
		{
			Assert.AreEqual(calculator.Sin(angle), expected);
		}

		private static readonly object[] negativeTests =
		{
			new object[] { "sffdg", typeof(NotFiniteNumberException)},
			new object[] { new Calculator(), typeof(NotFiniteNumberException) },
			new object[] { double.NaN, typeof(NotFiniteNumberException)},
			new object[] { double.PositiveInfinity, typeof(NotFiniteNumberException)},
			new object[] { double.NegativeInfinity, typeof(NotFiniteNumberException) }
		};

		[Test, TestCaseSource("negativeTests", Category = "Negative")]
		public void Tests_negativeCases(object angle, Type expected)
		{
			Assert.That(() => calculator.Sin(angle), Throws.TypeOf(expected));
		}

	}
}
