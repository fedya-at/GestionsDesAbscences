using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class DetailedAbsenceDto
    {
        public int CodeFicheAbsence { get; set; }
        public string NomEtudiant { get; set; }
        public string PrenomEtudiant { get; set; }
        public string NomMatiere { get; set; }
        public DateTime DateAbsence { get; set; }
        public string AbsenceType { get; set; } // Justified/Unjustified
    }

}
