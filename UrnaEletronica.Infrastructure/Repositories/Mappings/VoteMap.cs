using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using UrnaEletronica.Domain.Entities;

namespace UrnaEletronica.Infrastructure.Repositories.Mappings
{
    public class VoteMap : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Property(t => t.VoteId).HasColumnName("Id").IsRequired().HasColumnType("INT").ValueGeneratedOnAdd();
            builder.Property(t => t.CandidateId).HasColumnName("CandidateId").IsRequired().HasColumnType("INT");
            builder.Property(t => t.VoteDate).HasColumnName("VoteDate").IsRequired().HasColumnType("DATETIME");

            builder.HasKey(t => t.VoteId);
            builder.ToTable("Vote", "dbo");

            builder.HasOne(b => b.Candidate).WithMany(p => p.Votes).HasForeignKey(p => p.CandidateId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
