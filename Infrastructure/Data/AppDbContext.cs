using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Core.Entities;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Classe> Classes { get; set; }
        public DbSet<Matiere> Matieres { get; set; }
        public DbSet<Seance> Seances { get; set; }
        public DbSet<FicheAbsence> FicheAbsences { get; set; }
        public DbSet<FicheAbsenceSeance> FicheAbsenceSeances { get; set; }
        public DbSet<LigneFicheAbsence> LigneFicheAbsences { get; set; }
        public DbSet<Enseignant> Enseignants { get; set; }
        public DbSet<Etudiant> Etudiants { get; set; }
        public DbSet<Groupe> Groupes { get; set; }
        public DbSet<Departement> Departements { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

    }
}
