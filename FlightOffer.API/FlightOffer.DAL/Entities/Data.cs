namespace FlightOffer.DAL.Entities
{
    public class Data
    {
        public int NumberOfBookableSeats { get; set; }
        public IList<Itinerary> Itineraries { get; set; }
        public Price Price { get; set; }
    }
}
