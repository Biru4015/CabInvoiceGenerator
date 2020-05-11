using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class InvoiceSummary
    {
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