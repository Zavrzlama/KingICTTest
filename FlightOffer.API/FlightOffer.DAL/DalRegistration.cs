using FlightOffer.DAL.Entities;
using FlightOffer.DAL.Repositories.Implementations;
using FlightOffer.DAL.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FlightOffer.DAL
{
    public static class DalRegistration
    {
        
            public static IServiceCollection AddDalServices(this IServiceCollection services)
            {
                services.AddSingleton< IAsyncRepository<Data>, FlightOfferRepository>();
               
                return services;
            }

        
    }
}
