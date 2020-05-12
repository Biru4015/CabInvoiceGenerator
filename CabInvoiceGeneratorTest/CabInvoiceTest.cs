using NUnit.Framework;
using CabInvoiceGeneratorTest;
using CabInvoiceGenerator;
using System;
using System.Collections.Generic;

namespace CabInvoiceGeneratorTest
{
    public class Tests
    {
        InvoiceGenerator invoice = new InvoiceGenerator();

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
            Assert.AreEqual(5, invoice.CalculateCabFare(cabRunningDistance, cabRunningTime));
        }

        /// <summary>
        /// Test case 2.1
        /// sending two parameters as cabRunningDistance and canRunningTime
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeOfMultiRidesToInvoiceGenerator_WhenCalculate_ShouldReturnTotalFare()
        {
            /// Multiple ride array
            Ride[] rides =
                {
                new Ride(2.0,1.0),
                new Ride(2.5,1.5)
                };
            var exceptedSummery = 47.5;
            InvoiceSummary returnSummery = invoice.CalculateCabFare(rides);
            Assert.AreEqual(exceptedSummery, returnSummery.totalFare);
        }

        /// <summary>
        /// Test case 3.1
        /// Creating an object of InvoiceGenerator
        /// sending two parameters as cabRunningDistance and canRunningTime
        /// Total Number of Rides- Total Fare- Average Fare Per Ride
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeOfMultiRidesToInvoiceGenerator_WhenCalculated_ShouldInhancedInvoice()
        {
            //// Local variables
            bool exceptedInvoice = true;
            bool returnInvoice = false;
            //// sending two rides distance in double and also time in double
            Ride[] rides =
            {
                new Ride(2.0,1.0),
                new Ride(2.5,1.5)
            };
            InvoiceSummary returnSummery = invoice.CalculateCabFare(rides);
            InvoiceSummary expectedSummery = new InvoiceSummary
            {
                totalNumberOfRides = 2,
                totalFare = 47.5,
                averageFarePerRide = 23.75
            };
            //// Checkoing all three returnSummary values are equal to exceptedSummary
            //// IF yes then returnInvoice will be 'true'
            if (returnSummery.totalNumberOfRides == expectedSummery.totalNumberOfRides && returnSummery.totalFare == expectedSummery.totalFare && returnSummery.averageFarePerRide == expectedSummery.averageFarePerRide)
            {
                returnInvoice = true;
            }
            Assert.AreEqual(exceptedInvoice, returnInvoice);
        }

        /// <summary>
        /// Test case 4.1
        /// Invoice Service
        /// Given a user id, the Invoice Service gets the List of rides from the RideRepository,
        /// And returns theInvoice.
        /// </summary>
        [Test]
        public void GivenUserIDandRides_WhenCalculated_ShouldReturnInvoiceSummary()
        {
            string userId = "Biru@123";
            Ride[] rides =
            {
                new Ride(2.0,1.0),
                new Ride(2.5,1.5)
            };
            RideRepository rideRepository = new RideRepository();
            rideRepository.AddRides(userId, rides);
            InvoiceSummary retunTotal = invoice.CalculateCabFare(rideRepository.GetRides(userId));
            Assert.AreEqual(47.5, retunTotal.totalFare);
        }
    }
}