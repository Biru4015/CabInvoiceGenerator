using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    /// <summary>
    /// This class contains the code for interface of RideRepository
    /// </summary>
    public interface IRideRepository
    {
        public void AddRides(string userId, Ride[] rides);
        public Ride[] GetRides(string userId);
    }
}
