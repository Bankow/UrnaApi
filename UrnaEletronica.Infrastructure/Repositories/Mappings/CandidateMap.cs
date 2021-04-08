using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using UrnaEletronica.Domain.Entities;

namespace UrnaEletronica.Infrastructure.Repositories.Mappings
{
    public class CandidateMap : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Property(t => t.CandidateId).HasColumnName("Id").IsRequired().HasColumnType("INT").ValueGeneratedOnAdd();
            builder.Property(t => t.RegisterDate).HasColumnName("RegisterDate").IsRequired().HasColumnType("DATETIME");
            builder.Property(t => t.Name).HasColumnName("Name").IsRequired().HasColumnType("VARCHAR").HasMaxLength(150);
            builder.Property(t => t.ViceName).HasColumnName("ViceName").IsRequired().HasColumnType("VARCHAR").HasMaxLength(150);
            builder.Property(t => t.Subtitle).HasColumnName("Subtitle").IsRequired().HasColumnType("INT");

            builder.HasKey(t => t.CandidateId);
            builder.ToTable("Candidate", "dbo");

            builder.HasMany(p => p.Votes).WithOne(x => x.Candidate).HasForeignKey(p => p.CandidateId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
