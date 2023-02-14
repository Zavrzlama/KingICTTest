namespace FlightOffer.DAL.Entities
{
    public class Segment
    {
        public Departure Departure { get; set; }
        public Arrival Arrival { get; set; }
        public int NumberOfStops { get; set; }
    }
}
