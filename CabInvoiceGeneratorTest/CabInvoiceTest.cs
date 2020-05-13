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
        RideRepository rideRepository = new RideRepository();

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
            Assert.AreEqual(52, invoice.CalculateCabFare(Ride.RideType.normal, cabRunningDistance, cabRunningTime));
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
            Assert.AreEqual(5, invoice.CalculateCabFare(Ride.RideType.normal,cabRunningDistance, cabRunningTime));
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
                new Ride(Ride.RideType.normal,2.0,1.0),
                new Ride(Ride.RideType.normal,2.5,1.5)
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
                new Ride(Ride.RideType.normal,2.0,1.0),
                new Ride(Ride.RideType.normal,2.5,1.5)
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
                new Ride(Ride.RideType.normal,5.0,1.0),
                new Ride(Ride.RideType.normal,2.5,1.5)
            };
            Ride[] rides1 =
            {
                new Ride(Ride.RideType.normal,2.0,5.0),
                new Ride(Ride.RideType.normal,2.5,1.5)
            };
            rideRepository.AddRides(userId, rides);
            rideRepository.AddRides(userId, rides1);
            InvoiceSummary retunTotal = invoice.CalculateCabFare(rideRepository.GetRides(userId));
            Assert.AreEqual(129, retunTotal.totalFare);
        }

        /// <summary>
        /// Test case 4.2
        /// Invoice service
        /// Given inputs without userID 
        /// And return exception
        /// </summary>
        [Test]
        public void GivenInputWithoutUserId_WhenCalculated_ShouldReturnsException()
        {
            string userId = null;
            Ride[] rides =
            {
                new Ride(Ride.RideType.normal,2.0,1.0),
                new Ride(Ride.RideType.normal,2.5,1.5)
            };
            try
            {
                rideRepository.AddRides(userId, rides);
                InvoiceSummary retunTotal = invoice.CalculateCabFare(rideRepository.GetRides(userId));
            }
            catch (CustomException exception)
            {
                Assert.AreEqual("USERID_NOT_BE_NULL", exception.Message);
            }
        }

        /// <summary>
        /// Test case 4.3
        /// When given multiple userId with Multiple Rides
        /// Should Returns invoice
        /// </summary>
        [Test]
        public void GivenMultipleUserIdWithMultipleRides_WhenCalculated_ShouldReturnsInvoiceSummary()
        {
            String userId1 = "Birendra@123";
            Ride[] rides1 =
            {
                new Ride(Ride.RideType.normal,2.0,1.0),
                new Ride(Ride.RideType.normal,2.5,1.5)
            };
            String userId2 = "Ankit@321";
            Ride[] rides2 =
            {
                new Ride(Ride.RideType.normal,5.0,7.0),
                new Ride(Ride.RideType.normal,2.5,1.5)
            };
            rideRepository.AddRides(userId1, rides1);
            rideRepository.AddRides(userId2, rides2);
            InvoiceSummary retunTotal = invoice.CalculateCabFare(rideRepository.GetRides(userId1));
            InvoiceSummary retunTotal1 = invoice.CalculateCabFare(rideRepository.GetRides(userId2));
            Assert.AreEqual(131, retunTotal.totalFare + retunTotal1.totalFare);

        }

        /// <summary>
        /// Test case 5.1
        /// Invoice Service
        /// Given a user id, will have 'normal' and 'premimun' ridethe Invoice Service gets the List of rides from the RideRepository,
        /// and returns Total Average of normalFare and premimumFare.
        /// </summary>
        [Test]
        public void GivenUserIdOfPremiumAndNormalUser_WhenCalculated_ShouldReturnsTotalFare()
        {
            string userId = "Birendra@12345";
            Ride[] rides =
            {
                new Ride(Ride.RideType.normal,2.0,1.0),
                new Ride(Ride.RideType.premium,2.5,1.5)
            };
            rideRepository.AddRides(userId, rides);
            InvoiceSummary retunTotal = invoice.CalculateCabFare(rideRepository.GetRides(userId));
            Assert.AreEqual(61.5, retunTotal.totalFare);
        }
    }
}