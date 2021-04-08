using Microsoft.EntityFrameworkCore;
using UrnaEletronica.Domain.Entities;
using UrnaEletronica.Infrastructure.Repositories.Mappings;

namespace UrnaEletronica.Infrastructure.Repositories.Core
{
    public class UrnaEletronicaContext : DbContext
    {
        public UrnaEletronicaContext(DbContextOptions<UrnaEletronicaContext> options) : base(options)
        {
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Vote> Votes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CandidateMap());
            modelBuilder.ApplyConfiguration(new VoteMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
