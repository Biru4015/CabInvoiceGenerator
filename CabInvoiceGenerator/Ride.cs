namespace CabInvoiceGenerator
{
    public class Ride
    {
        //// Variable
        readonly public double rideDistance;
        readonly public double rideTime;

        readonly public  RideType rideType;
        public enum RideType
        {
            normal,premium
        }

        /// <summary>
        ///  Parameterised Constructor
        /// </summary>
        /// <param name="runningDistance"></param>
        /// <param name="runningTime"></param>
        public Ride(RideType rideType, double runningDistance, double runningTime)
        {
            this.rideType = rideType;
            this.rideDistance = runningDistance;
            this.rideTime = runningTime;
        }
    }
}