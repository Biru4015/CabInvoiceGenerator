using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    /// <summary>
    /// This is ride repository class for storing ride details.
    /// </summary>
    public class RideRepository:IRideRepository
    {
        public Dictionary<string, List<Ride>> userRideObj;
        public RideRepository()
        {
            this.userRideObj = new Dictionary<string, List<Ride>>();
        }

        /// <summary>
        /// This method is created for Adding rides in Dictionary
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="rides"></param>
        public void AddRides(string userId, Ride[] rides)
        {
            if (userId == null)
                throw new CustomException(CustomException.ExceptionType.USERID_NOT_NULL, "USERID_NOT_BE_NULL");
            bool checkRide = userRideObj.ContainsKey(userId);
            List<Ride> list = new List<Ride>();
            if (checkRide == false)
            {
                list.AddRange(rides);
                userRideObj.Add(userId, list);
            }
            else foreach (Ride ride in rides) userRideObj[userId].Add(ride);
        }

        /// <summary>
        /// This method is created for getting invoice for given UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Ride[] GetRides(string userId)
        {
            return userRideObj[userId].ToArray();
        }
    }
}
