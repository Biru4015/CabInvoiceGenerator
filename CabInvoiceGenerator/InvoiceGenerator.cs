using System;
using System.Collections.Generic;
using System.Text;
using CabInvoiceGenerator;

namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        // Declared and Initialised Variables
        readonly private double distance;
        readonly private double time;
        readonly private double COST_PER_KILO_METER = 10.0;
        readonly private double COST_PER_MININUTES = 1.0;
        readonly private double MINIMUM_FARE = 5.0;

        /// <InvoiceGenerator>
        /// Parameterised Constructor
        /// </InvoiceGenerator>
        /// <param name="runningDistance"></param>
        /// <param name="runningTime"></param>
        public InvoiceGenerator(double runningDistance, double runningTime)
        {
            this.distance = runningDistance;
            this.time = runningTime;
        }

        /// <CalculateCabFare>
        /// Calculating Total Fare of a journey.
        /// </CalculateCabFare>
        /// <minimumFare></returns>
        /// <totalFare></returns>
        public double CalculateCabFare()
        {
            double totalFare = (distance * COST_PER_KILO_METER) + (time * COST_PER_MININUTES);
            if (totalFare < MINIMUM_FARE)
            {
                return MINIMUM_FARE;
            }
            return totalFare;
        }
    }
}
