using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    /// <summary>
    /// This class contains the code for generating invoice summary
    /// </summary>
    public class InvoiceSummary
    {
        //// Getters and Setters
        public int totalNumberOfRides { get; set; }
        public double totalFare { get; set; }
        public double averageFarePerRide { get; set; }


        /// <CalulateAverageFare>
        /// Calculating averageFare among totalNumberof rides.
        /// and Accessing averageFarePer Ride with help of class InvoiceSummery's object
        /// </CalulateAverageFare>
        public void CalulateAverageFare()
        {
            averageFarePerRide = totalFare / totalNumberOfRides;
        }
    }
}