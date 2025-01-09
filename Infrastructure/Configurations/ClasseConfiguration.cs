using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class ClasseConfiguration : IEntityTypeConfiguration<Classe>
    {
        public void Configure(EntityTypeBuilder<Classe> builder)
        {
            builder.HasKey(c => c.CodeClasse);

            builder.Property(c => c.NomClasse)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasOne<Groupe>()
                   .WithMany()
                   .HasForeignKey(c => c.CodeGroupe)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<Departement>()
                   .WithMany()
                   .HasForeignKey(c => c.CodeDepartement)
                   .OnDelete(DeleteBehavior.Cascade);
}
    }
}
