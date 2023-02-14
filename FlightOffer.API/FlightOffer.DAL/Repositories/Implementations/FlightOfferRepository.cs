using FlightOffer.DAL.Entities;
using FlightOffer.DAL.Repositories.Interfaces;

namespace FlightOffer.DAL.Repositories.Implementations
{
    internal class FlightOfferRepository : IAsyncRepository<Data>
    {

        public static List<Data> Data { get; set; }

        public FlightOfferRepository()
        {
            Data = new List<Data>();
        }


        public void Add(Data item)
        {
            Data.Add(item);
        }

        public void Delete(Data item)
        {
            Data.Remove(item);
        }

        public IList<Data> GetAll()
        {
            return Data;
        }

        public IList<Data> Search(Filter filter)
        {
            var filtered = new List<Data>();

            foreach (var item in Data)
            {
                if (!string.IsNullOrEmpty(filter.Currency) && item.Price.Currency != filter.Currency) continue;

                foreach (var itinerary in item.Itineraries)
                {
                    var segment = itinerary.Segments.FirstOrDefault();
                    if (segment.Departure.IataCode != filter.OriginLocation) continue;
                    if (segment.Departure.At.ToString("yyyy-MM-dd") != filter.DepartureDate.ToString("yyyy-MM-dd")) continue;
                    if (segment.Arrival.IataCode != filter.DestinationLocation) continue;

                    if (filter.ArrivalDate.HasValue
                        && segment.Arrival.At.ToString("yyyy-MM-dd") != filter.ArrivalDate.Value.ToString("yyyy-MM-dd"))
                        continue;

                    filtered.Add(item);
                }
            }

            return filtered;
        }

        public Data GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Data item)
        {
            throw new NotImplementedException();
        }

        public void AddMultiple(IList<Data> data)
        {
            Data.AddRange(data);
        }
    }
}
