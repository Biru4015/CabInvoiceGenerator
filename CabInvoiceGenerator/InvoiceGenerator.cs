using System;
using System.Collections.Generic;
using System.Text;
using CabInvoiceGenerator;

namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        //// Constant for normal rides
        public const double NORMAL_COST_PER_KILO_METER = 10.0;
        public const double NORMAL_COST_PER_MININUTES = 1.0;
        public const double NORMAL_MINIMUM_FARE = 5.0;

        //// Constant for Premium rides
        public const double PREMIUM_COST_PER_KILO_METER = 15.0;
        public const double PREMIUM_COST_PER_MININUTES = 2.0;
        public const double PREMIUM_MINIMUM_FARE = 20.0;

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
        public double CalculateCabFare(Ride.RideType rideType, double runningDistance, double runningTime)
        {
            //// Calculated for Normal Fare
            if (rideType == Ride.RideType.normal)
            {
                double totalFare = (runningDistance * NORMAL_COST_PER_KILO_METER) + (runningTime * NORMAL_COST_PER_MININUTES);
                if (totalFare < NORMAL_MINIMUM_FARE)
                {
                    return NORMAL_MINIMUM_FARE;
                }
                return totalFare;
            }
            //// Calculated Premium fare
            if (rideType == Ride.RideType.premium)
            {
                double totalFare = (runningDistance * PREMIUM_COST_PER_KILO_METER) + (runningTime * PREMIUM_COST_PER_MININUTES);
                if (totalFare > PREMIUM_MINIMUM_FARE)
                {
                    return totalFare;
                }
            }
            return PREMIUM_MINIMUM_FARE;
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
                totalFare += CalculateCabFare(ride.rideType, ride.rideDistance, ride.rideTime);
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