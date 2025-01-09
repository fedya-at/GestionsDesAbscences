using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class FicheAbsenceConfiguration : IEntityTypeConfiguration<FicheAbsence>
    {
        public void Configure(EntityTypeBuilder<FicheAbsence> builder)
        {
            builder.HasKey(f => f.CodeFicheAbsence);

            builder.Property(f => f.DateJour)
                   .IsRequired();

            builder.HasOne(f => f.Matiere)
                   .WithMany()
                   .HasForeignKey(f => f.CodeMatiere)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(f => f.Enseignant)
                   .WithMany()
                   .HasForeignKey(f => f.CodeEnseignant)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(f => f.Classe)
                   .WithMany()
                   .HasForeignKey(f => f.CodeClasse)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(f => f.LigneFicheAbsences)
                   .WithOne(l => l.FicheAbsence)
                   .HasForeignKey(l => l.CodeFicheAbsence);
        }
    }
}
