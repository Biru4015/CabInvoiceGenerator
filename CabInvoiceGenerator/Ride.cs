namespace CabInvoiceGenerator
{
    public class Ride
    {
        //// Variable
        readonly public double rideDistance;
        readonly public double rideTime;
        readonly public  CabRide rideType;
        
        /// <summary>
        ///  Parameterised Constructor
        /// </summary>
        /// <param name="runningDistance"></param>
        /// <param name="runningTime"></param>
        public Ride(CabRide rideType, double runningDistance, double runningTime)
        {
            this.rideType = rideType;
            this.rideDistance = runningDistance;
            this.rideTime = runningTime;
        }
    }
}