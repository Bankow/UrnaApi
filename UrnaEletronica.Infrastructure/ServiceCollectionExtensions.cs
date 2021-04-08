using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UrnaEletronica.Domain.Repositories;
using UrnaEletronica.Infrastructure.Repositories;
using UrnaEletronica.Infrastructure.Repositories.Core;

namespace UrnaEletronica.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services)
        {
            if (services is null)
            {
                throw new System.ArgumentNullException(nameof(services));
            }

            services.AddDbContext<UrnaEletronicaContext>((serviceProvider, options) =>
            {
                var connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;;Initial Catalog=UrnaEletronica;Integrated Security=True";
                options.UseSqlServer(connectionString);
            });

            return services;
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICandidateRepository, CandidateRepository>();
            services.AddTransient<IVoteRepository, VoteRepository>();

            return services;
        }
    }

}
