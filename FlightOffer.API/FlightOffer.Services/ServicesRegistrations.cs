using FlightOffer.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FlightOffer.Services
{
    public static class ServicesRegistrations
    {
        public static IServiceCollection AddServiceServices(this IServiceCollection services)
        {
            services.AddSingleton<IOfferService, OfferServices>();

            return services;
        }

    }
}
