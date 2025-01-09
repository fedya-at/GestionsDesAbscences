using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class UtilisateurConfiguration : IEntityTypeConfiguration<Utilisateur>
    {
        public void Configure(EntityTypeBuilder<Utilisateur> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.NomUtilisateur)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.MotDePasse)
                   .IsRequired();

            builder.Property(u => u.Role)
                   .IsRequired()
                   .HasMaxLength(50);
        }
    }
}
