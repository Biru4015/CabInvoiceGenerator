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
            InvoiceGenerator invoice = new InvoiceGenerator();
            Assert.AreEqual(52, invoice.CalculateCabFare(cabRunningDistance, cabRunningTime));
        }

        /// <summary>
        /// Test case 1.2
        /// When testing for minimum fare
        /// sending two parameters as cabRunningDistance and canRunningTime
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeToInvoiceGenerator_WhenCalculate_ShouldReturnMinimumFare()
        {
            double cabRunningDistance = 0.1;
            double cabRunningTime = 1.0;
            InvoiceGenerator invoice = new InvoiceGenerator();
            Assert.AreEqual(5, invoice.CalculateCabFare(cabRunningDistance, cabRunningTime));
        }

        /// <test 2>
        /// Creating an object of InvoiceGenerator
        /// sending two parameters as cabRunningDistance and canRunningTime
        /// </test 2>
        [Test]
        public void GivenDistanceAndTimeOfMultiRidesToInvoiceGenerator_WhenCalculate_ShouldReturnTotalFare()
        {
            Ride[] rides =
                {
                new Ride(2.0,1.0),
                new Ride(2.5,1.5)
                };
            InvoiceGenerator invoice = new InvoiceGenerator();
            Assert.AreEqual(47.5, invoice.CalculateCabFare(rides));
        }
    }
}