using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class LigneFicheAbsenceConfiguration : IEntityTypeConfiguration<LigneFicheAbsence>
    {
        public void Configure(EntityTypeBuilder<LigneFicheAbsence> builder)
        {
            builder.HasKey(lfa => new { lfa.CodeFicheAbsence, lfa.CodeEtudiant });

            builder.HasOne(lfa => lfa.FicheAbsence)
                   .WithMany(f => f.LigneFicheAbsences)
                   .HasForeignKey(lfa => lfa.CodeFicheAbsence)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(lfa => lfa.Etudiant)
                   .WithMany()
                   .HasForeignKey(lfa => lfa.CodeEtudiant)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
