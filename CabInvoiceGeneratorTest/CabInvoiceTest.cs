using NUnit.Framework;
using CabInvoiceGeneratorTest;
using CabInvoiceGenerator;

namespace CabInvoiceGeneratorTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test case 1.1
        /// Creating an object of InvoiceGenerator
        /// sending two parameters as cabRunningDistance and canRunningTime
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeToInvoiceGenerator_WhenCalculate_ShouldReturnTotalFare()
        {
            double cabRunningDistance = 5.0;
            double cabRunningTime = 2.0;
            InvoiceGenerator invoice = new InvoiceGenerator(cabRunningDistance, cabRunningTime);
            Assert.AreEqual(52, invoice.CalculateCabFare());
        }
    }
}