using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class FicheAbsence
    {
        [Key]
        public int CodeFicheAbsence { get; set; }

        [Required]
        public DateTime DateJour { get; set; }

        [Required]
        [ForeignKey("CodeMatiere")]
        public int CodeMatiere { get; set; } // Foreign Key

        [Required]
        [ForeignKey("CodeEnseignant")]
        public int CodeEnseignant { get; set; } // Foreign Key

        [Required]
        [ForeignKey("CodeClasse")]
        public int CodeClasse { get; set; } // Foreign Key

        public Matiere Matiere { get; set; }
        public Enseignant Enseignant { get; set; }
        public Classe Classe { get; set; }
        public ICollection<FicheAbsenceSeance> FicheAbsenceSeances { get; set; }
        public ICollection<LigneFicheAbsence> LigneFicheAbsences { get; set; }
    }
}
