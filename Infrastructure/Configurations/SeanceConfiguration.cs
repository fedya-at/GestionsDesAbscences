using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class SeanceConfiguration : IEntityTypeConfiguration<Seance>
    {
        public void Configure(EntityTypeBuilder<Seance> builder)
        {
            builder.HasKey(s => s.CodeSeance);

            builder.Property(s => s.NomSeance)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(s => s.HeureDebut)
                   .IsRequired();

            builder.Property(s => s.HeureFin)
                   .IsRequired();
        }
    }
}
