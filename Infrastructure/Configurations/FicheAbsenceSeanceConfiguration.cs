using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class FicheAbsenceSeanceConfiguration : IEntityTypeConfiguration<FicheAbsenceSeance>
    {
        public void Configure(EntityTypeBuilder<FicheAbsenceSeance> builder)
        {
            builder.HasKey(fas => new { fas.CodeFicheAbsence, fas.CodeSeance });

            builder.HasOne(fas => fas.FicheAbsence)
                   .WithMany(f => f.FicheAbsenceSeances)
                   .HasForeignKey(fas => fas.CodeFicheAbsence)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(fas => fas.Seance)
                   .WithMany(s => s.FicheAbsenceSeances)
                   .HasForeignKey(fas => fas.CodeSeance)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
