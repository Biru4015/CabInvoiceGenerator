using System;
using System.Collections.Generic;
using System.Text;
using CabInvoiceGenerator;

namespace CabInvoiceGenerator
{
    public class CabRide
    {
        public static readonly CabRide NORMAL = new CabRide(10.0,1.0,5.0);
        public static readonly CabRide PREMIUM = new CabRide(15.0, 2.0, 20.0);

        public static IEnumerable<CabRide> Values
        {
            get
            {
                yield return NORMAL;
                yield return PREMIUM;
            }
        }

        public double CostPerKilometer { get; private set; }
        public double CostPerMininutes { get; private set; }
        public double MinimumFare { get; private set; }

       private CabRide(double costPerKilometer, double costPerMininutes, double minmumFare) 
            => (CostPerKilometer, CostPerMininutes, MinimumFare) = (costPerKilometer, costPerMininutes, minmumFare);

        public double CalculateCabFare(Ride ride)
        {
            double rideCost = ride.rideDistance * CostPerKilometer + ride.rideTime * CostPerMininutes;
            return Math.Max(rideCost, MinimumFare);
        }
    }
}
