using System;
using System.Collections.Generic;
using System.Text;
using CabInvoiceGenerator;

namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        //// Constant Variables
        public const double COST_PER_KILO_METER = 10.0;
        public const double COST_PER_MININUTES = 1.0;
        public const double MINIMUM_FARE = 5.0;

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
        public double CalculateCabFare(double runningDistance, double runningTime)
        {
            double totalFare = (runningDistance * COST_PER_KILO_METER) + (runningTime * COST_PER_MININUTES);
            if (totalFare < MINIMUM_FARE)
            {
                return MINIMUM_FARE;
            }
            return totalFare;
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
                totalFare += CalculateCabFare(ride.rideDistance, ride.rideTime);
                totalNumberOfRides += 1;
            }
            InvoiceSummary invoiceSummery = new InvoiceSummary();
            invoiceSummery.totalNumberOfRides = totalNumberOfRides;
            invoiceSummery.totalFare = totalFare;
            invoiceSummery.CalulateAverageFare();
            return invoiceSummery;
        }
    }
}