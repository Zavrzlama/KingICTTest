namespace FlightOffer.DAL.Entities
{
    public class Departure
    {
        public string IataCode { get; set; }
        public string Terminal { get; set; }
        public DateTime At { get; set; }
    }
}
