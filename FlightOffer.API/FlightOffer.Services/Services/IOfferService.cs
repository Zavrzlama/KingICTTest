using FlightOffer.Services.Models.Dto;

namespace FlightOffer.Services.Services
{
    public interface IOfferService
    {
        Task<IList<FlightOfferDto>> GetOffers(FilterDto filter);
    }
}
