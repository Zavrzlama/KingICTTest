namespace FlightOffer.Services.Models.Dto
{
    public class FilterDto
    {
        public string OriginLocation { get; set; }
        public string DestinationLocation { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public int? Adults { get; set; }
        public string? Currency { get; set; }


        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            FilterDto other = (FilterDto)obj;
            return OriginLocation == other.OriginLocation && DestinationLocation == other.DestinationLocation && DepartureDate == other.DepartureDate && ArrivalDate == other.ArrivalDate
                && Adults == other.Adults && Currency == other.Currency;
        }
    }
}
