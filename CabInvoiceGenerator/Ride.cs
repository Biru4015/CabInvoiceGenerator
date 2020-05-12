namespace CabInvoiceGenerator
{
    public class Ride
    {
        //// Variable
        readonly public double rideDistance;
        readonly public double rideTime;
        public Ride(double runningDistance, double runningTime)
        {
            this.rideDistance = runningDistance;
            this.rideTime = runningTime;
        }
    }
}