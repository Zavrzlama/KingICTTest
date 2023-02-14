using FlightOffer.DAL.Entities;
using FlightOffer.DAL.Repositories.Interfaces;
using FlightOffer.Services.Models;
using FlightOffer.Services.Models.Dto;
using FlightOffer.Services.RestUtils;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace FlightOffer.Services.Services
{
    public class OfferServices : IOfferService
    {

        private readonly IConfiguration _configuration;
        private readonly IAsyncRepository<Data> _repository;

        public OfferServices(IConfiguration configuration, IAsyncRepository<Data> repository)
        {
            _configuration = configuration;
            _repository = repository;
        }

        public async Task<IList<FlightOfferDto>> GetOffers(FilterDto filterDto)
        {
            var filter = MapFilter(filterDto);
            var data = _repository.Search(filter);
            if (data.Count > 0)
            {
                return MapOffers(data);
            }

            var apiData = await GetApiOffers(filterDto);
            _repository.AddMultiple(apiData.Data);
            
            return MapOffers(apiData.Data);
        }

        public async Task<Offer> GetApiOffers(FilterDto filter)
        {
           
            string authUrl = _configuration["authUrl"];
            string clientId = _configuration["clientId"];
            string clientSecret = _configuration["clientSecret"];

            var rest = new FlightOfferRest();
            var token = await rest.OpenIdPost<Token>(authUrl, clientId, clientSecret);

            var url = CreateUrl(filter);

            return await rest.JwtGet<Offer>(url, token.AccessToken);
        }

        private string CreateUrl(FilterDto filter)
        {
            string baseUrl = _configuration["offerUrlBase"];
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(baseUrl);
            urlBuilder.Append("originLocationCode=" + filter.OriginLocation.ToUpper());
            urlBuilder.Append("&destinationLocationCode=" + filter.DestinationLocation.ToUpper());
            urlBuilder.Append("&departureDate=" + filter.DepartureDate.ToString("yyyy-MM-dd"));
            urlBuilder.Append("&adults=" + filter.Adults);

            if (filter.ArrivalDate.HasValue) urlBuilder.Append("&returnDate=" + filter.ArrivalDate.Value.ToString("yyyy-MM-dd"));

            return urlBuilder.ToString();
        }

        private IList<FlightOfferDto> MapOffers(IList<Data> data)
        {
            var list = new List<FlightOfferDto>();
            foreach (var item in data)
            {
                var dto = new FlightOfferDto();
                dto.Id = Guid.NewGuid().ToString();
                dto.Persons = item.NumberOfBookableSeats;
                dto.Price = item.Price.GrandTotal;
                dto.Currency = item.Price.Currency;
                foreach (var itinary in item.Itineraries)
                {
                    foreach (var segment in itinary.Segments)
                    {
                        dto.OriginLocation = segment.Arrival.IataCode;
                        dto.ArrivalDate = segment.Arrival.At;
                        dto.DestinationLocation = segment.Departure.IataCode;
                        dto.DepartureDate = segment.Departure.At;
                        dto.NumberOfStops = segment.NumberOfStops;
                    }
                    list.Add(dto);
                }
            }
            return list;
        }

        private Filter MapFilter(FilterDto filterDto)
        {
            var filter = new Filter();
            filter.OriginLocation = filterDto.OriginLocation;
            filter.DestinationLocation = filterDto.DestinationLocation;
            filter.DepartureDate = filterDto.DepartureDate;
            filter.Adults = filterDto.Adults;
            filter.ArrivalDate = filterDto.ArrivalDate;
            filter.Currency = filterDto.Currency;

            return filter;
        }

    }
}
