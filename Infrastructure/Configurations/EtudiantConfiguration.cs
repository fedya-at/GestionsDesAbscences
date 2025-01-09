using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class EtudiantConfiguration : IEntityTypeConfiguration<Etudiant>
    {
        public void Configure(EntityTypeBuilder<Etudiant> builder)
        {
            builder.HasKey(e => e.CodeEtudiant);

            builder.Property(e => e.Nom)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(e => e.Prenom)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(e => e.DateNaissance)
                   .IsRequired();

            builder.HasOne<Classe>()
                   .WithMany(c => c.Etudiants)
                   .HasForeignKey(e => e.CodeClasse)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
