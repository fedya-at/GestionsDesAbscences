using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IRepository<Classe> Classes => new Repository<Classe>(_context);
        public IRepository<Matiere> Matieres => new Repository<Matiere>(_context);
        public IRepository<Seance> Seances => new Repository<Seance>(_context);
        public IRepository<FicheAbsence> FicheAbsences => new Repository<FicheAbsence>(_context);
        public IRepository<FicheAbsenceSeance> FicheAbsenceSeances => new Repository<FicheAbsenceSeance>(_context);
        public IRepository<LigneFicheAbsence> LigneFicheAbsences => new Repository<LigneFicheAbsence>(_context);
        public IRepository<Enseignant> Enseignants => new Repository<Enseignant>(_context);
        public IRepository<Etudiant> Etudiants => new Repository<Etudiant>(_context);
        public IRepository<Groupe> Groupes => new Repository<Groupe>(_context);
        public IRepository<Departement> Departements => new Repository<Departement>(_context);
        public IRepository<Utilisateur> Utilisateurs => new Repository<Utilisateur>(_context);
        public IRepository<Grade> Grades => new Repository<Grade>(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
