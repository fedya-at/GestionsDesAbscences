using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    using Core.Entities;
    using Microsoft.EntityFrameworkCore;

    namespace Infrastructure.Data
    {
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

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

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=GestionAbscenceDB;Integrated Security=true");
                base.OnConfiguring(optionsBuilder);
            }
        }
    }

}
