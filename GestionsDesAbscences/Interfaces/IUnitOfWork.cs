using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Classe> Classes { get; }
        IRepository<Departement> Departements { get; }
        IRepository<Enseignant> Enseignants { get; }
        IRepository<Etudiant> Etudiants { get; }
        IRepository<FicheAbsence> FicheAbsences { get; }
        IRepository<FicheAbsenceSeance> FicheAbsenceSeances { get; }
        IRepository<Grade> Grades { get; }
        IRepository<Groupe> Groupes { get; }
        IRepository<LigneFicheAbsence> LigneFicheAbsences { get; }
        IRepository<Matiere> Matieres { get; }
        IRepository<Seance> Seances { get; }
        IRepository<Utilisateur> Utilisateurs { get; }
        Task<int> SaveChangesAsync();
    }

}
