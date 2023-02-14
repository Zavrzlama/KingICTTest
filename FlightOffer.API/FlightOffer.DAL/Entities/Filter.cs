namespace FlightOffer.DAL.Entities
{
    public class Filter
    {
        public string OriginLocation { get; set; }
        public string DestinationLocation { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public int? Adults { get; set; }
        public string? MaxPrice { get; set; }
        public string? Currency { get; set; }
    }
}
