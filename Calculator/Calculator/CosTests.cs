using NUnit.Framework;
using CSharpCalculator;
using System;

namespace CalculatorProject
{
	[TestFixture(Category = "Cos")]
	class CosTests
	{
		private Calculator calculator;

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			calculator = new Calculator();
		}

		private static readonly object[] positiveTests =
		{
			new double[] { 1 , Math.Cos(1)},
			new double[] { double.MaxValue, Math.Cos(double.MaxValue)},
			new double[] { double.MinValue, Math.Cos(double.MinValue)},
			new double[] { 0, Math.Cos(0)},
			new double[] { 0.22, Math.Cos(0.22)},
			new object[] { "0.15", Math.Cos(0.15)}
		};

		[Test, TestCaseSource("positiveTests", Category = "Positive")]
		public void Tests_positiveCases(object angle, double expected)
		{
			Assert.AreEqual(calculator.Cos(angle), expected) ;
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
			Assert.That(() => calculator.Cos(angle), Throws.TypeOf(expected));
		}

	}
}
