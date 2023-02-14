using FlightOffer.Services.Models.Dto;
using FlightOffer.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlightOffer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightOfferController : ControllerBase
    {
        private readonly IOfferService _service;

        public FlightOfferController(IOfferService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetFlightOffers(string originLocation, string destinationLocation, DateTime departureDate, int adults, DateTime? arrivalDate, string? currency)
        {
            var filter = new FilterDto
            {
                OriginLocation = originLocation,
                DestinationLocation = destinationLocation,
                DepartureDate = departureDate,
                ArrivalDate = arrivalDate,
                Adults = adults,
                Currency = currency
            };

            var validationError = ValidateIput(filter);
            if (!string.IsNullOrEmpty(validationError)) return BadRequest(validationError);
                
            var list = await _service.GetOffers(filter);
            return Ok(list);
        }

        private string ValidateIput(FilterDto filter)
        {
            if (filter.DepartureDate < DateTime.Today) return "Datum mora biti veći od današnjeg";
            if (filter.DepartureDate > filter.ArrivalDate) return "Datum polaska mora biti manji od datuma dolaska";
            if (string.IsNullOrEmpty(filter.OriginLocation)) return "Polazišni aerodrom je obavezan";
            if (string.IsNullOrEmpty(filter.DestinationLocation)) return "Dolazišni aerodrom je obavezan";
            
            return string.Empty;
        }
    }
}
