using NUnit.Framework;
using System;
using Calculator;
using System.Configuration;

namespace CalculatorTest
{
    [TestFixture]
    public class TestCalculator
    {
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Starting TestHelloWorld tests");
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("TestHelloWorld tests are finished");
        }


        [Category("SumTests")]
        [Test]
        public void OneCanSumPositiveIntegers()
        {
            Assert.That(Calc.Sum(5, 5), Is.EqualTo(10));
        }

        [Category("SumTests")]
        [Test]
        public void OneCanSumNegativeIntegers()
        {
            Assert.That(Calc.Sum(-5, -5), Is.EqualTo(-10));
        }

        [Category("SubstractTests")]
        [Test]
        public void OneCanSubstractPositiveIntegers()
        {
            Assert.That(Calc.Substract(5, 5), Is.EqualTo(0));
        }

        [Category("SubstractTests")]
        [Test]
        public void OneCanSubstractNegativeIntegers()
        {
            Assert.That(Calc.Substract(-5, -5), Is.EqualTo(0));
        }     
        
        [Category("SubstractTests")]
        [Test]
        public void OneCanSubstracPositiveIntegertFromZero()
        {
            Assert.That(Calc.Substract(0, 100), Is.EqualTo(-100));
        }

        [Category("SubstractTests")]
        [Test]
        public void OneCanSubstracNegativeIntegertFromZero()
        {
            Assert.AreNotEqual(Calc.Substract(0, -100),99);
        }
        
        [Ignore("Ignoring")]
        [Category("SubstractTests")]
        [Test]
        public void OneCanDevideByZero()
        {
            Assert.That(Calc.Devide(1, 0), Is.EqualTo(0));
        }

        [Category("Configuration")]
        [Test]
        public void OneCanReadAppConfig()
        {
            string browserName = ConfigurationSettings.AppSettings["BrowserName"];
            Console.WriteLine("Browser: " + browserName);
            string timeout = ConfigurationSettings.AppSettings["TimeoutSeconds"];
            Console.WriteLine("Timeout: " + timeout);
        }
    }
}
