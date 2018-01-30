using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CSharpCalculator;

namespace CalculatorProject
{
	[TestFixture(Category = "Sub")]
	class SubTests
	{
		private Calculator calculator;

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			calculator = new Calculator();
		}

		private static readonly object[] positiveTests =
		{
			new double[] { 1 ,1 ,0},
			new double[] { double.MaxValue, double.MinValue, 0},
			new double[] { double.MaxValue, double.MaxValue, double.PositiveInfinity},
			new double[] { double.MinValue, double.MinValue, double.NegativeInfinity},
			new int[] { 10, 20, -10}
		};

		[Test, TestCaseSource("positiveTests", Category = "Positive")]
		public void Tests_positidsfveCases(object firstTerm, object secondTerm, object expected)
		{
			Assert.AreEqual(calculator.Sub(firstTerm, secondTerm), expected);
		}

		private static readonly object[] negativeTests =
		{
			new double[] { 10, 10 , 20},
			new double[] { -100, 50, -50}
		};

		[Test, TestCaseSource("negativeTests", Category = "Negative")]
		public void Tests_positiveaCases(object firstTerm, object secondTerm, object expected)
		{
			Assert.AreEqual(calculator.Add(firstTerm, secondTerm), expected);
		}

	}
}
