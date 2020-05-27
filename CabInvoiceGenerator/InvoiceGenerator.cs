using System;
using System.Collections.Generic;
using System.Text;
using CabInvoiceGenerator;

namespace CabInvoiceGenerator
{
    /// <summary>
    /// This class contains the code for generating invoice
    /// </summary>
    public class InvoiceGenerator
    {
        IRideRepository rideRepository = null;
        
        public InvoiceGenerator(IRideRepository rideRepository)
        {
            this.rideRepository = rideRepository;
        }

        public void AddRide(string userId, Ride[] rides)
        {
            this.rideRepository.AddRides(userId,rides);
        }

        public Ride[] GetRide(string userId)
        {
            return this.rideRepository.GetRides(userId);
        }

        /// <InvoiceGenerator>
        /// Default Constructor
        /// </InvoiceGenerator>
        /// <param name="runningDistance"></param>
        /// <param name="runningTime"></param>
        public InvoiceGenerator()
        {
        }

        /// <CalculateCabFare>
        /// Calculating Total Fare of a journey.
        /// </CalculateCabFare>
        /// <minimumFare></returns>
        /// <totalFare></returns>
        public double CalculateCabFare(CabRide cabRide, double runningDistance, double runningTime)
        {
            double totalFare = runningDistance * cabRide.CostPerKilometer + runningTime * cabRide.CostPerMininutes;
            return Math.Max(totalFare, cabRide.MinimumFare);
        }

        /// <CalculateCabFare>
        /// Method to calculated fare of multiple rides
        /// </CalculateCabFare>
        /// <param name="rides"></param>
        /// <returns></returns>
        public InvoiceSummary CalculateCabFare(Ride[] rides)
        {

            int totalNumberOfRides = 0;
            double totalFare = 0;
            foreach (Ride ride in rides)
            {
                totalFare += this.CalculateCabFare(ride.rideType,ride.rideDistance, ride.rideTime);
                totalNumberOfRides += 1;
            }
            //// Object of InvoiceSummery and accessing data from class
            InvoiceSummary invoiceSummary = new InvoiceSummary();
            invoiceSummary.totalNumberOfRides = totalNumberOfRides;
            invoiceSummary.totalFare = totalFare;
            invoiceSummary.CalulateAverageFare();
            return invoiceSummary;
        }
    }
}