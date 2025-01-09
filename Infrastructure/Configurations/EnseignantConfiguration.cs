using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class EnseignantConfiguration : IEntityTypeConfiguration<Enseignant>
    {
        public void Configure(EntityTypeBuilder<Enseignant> builder)
        {
            builder.HasKey(e => e.CodeEnseignant);

            builder.Property(e => e.Nom)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(e => e.Prenom)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(e => e.DateRecrutement)
                   .IsRequired();

            builder.HasOne<Departement>()
                   .WithMany()
                   .HasForeignKey(e => e.CodeDepartement)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Grade>()
                   .WithMany()
                   .HasForeignKey(e => e.CodeGrade)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
