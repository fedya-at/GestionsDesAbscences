using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class MatiereConfiguration : IEntityTypeConfiguration<Matiere>
    {
        public void Configure(EntityTypeBuilder<Matiere> builder)
        {
            builder.HasKey(m => m.CodeMatiere);

            builder.Property(m => m.NomMatiere)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(m => m.NbreHeureCoursParSemaine)
                   .IsRequired()
                   .HasDefaultValue(0);

            builder.Property(m => m.NbreHeureTDParSemaine)
                   .IsRequired()
                   .HasDefaultValue(0);

            builder.Property(m => m.NbreHeureTPParSemaine)
                   .IsRequired()
                   .HasDefaultValue(0);
        }
    }
}
