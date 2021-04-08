using Microsoft.Extensions.DependencyInjection;
using UrnaEletronica.Domain.Services.Contracts;
using UrnaEletronica.Domain.Services.Implementation;

namespace UrnaEletronica.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainsServices(this IServiceCollection services)
        {
            // Services
            services.AddTransient<ICandidateService, CandidateService>();
            services.AddTransient<IVoteService, VoteService>();

            return services;
        }
    }
}
