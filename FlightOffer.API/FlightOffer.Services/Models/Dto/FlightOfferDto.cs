namespace FlightOffer.Services.Models.Dto
{
    public class FlightOfferDto
    {
        public string Id { get; set; }
        public string OriginLocation { get; set; }
        public string DestinationLocation { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int NumberOfStops { get; set; }
        public int Persons { get; set; }
        public string Price { get; set; }
        public string Currency { get; set; }
    }
}
