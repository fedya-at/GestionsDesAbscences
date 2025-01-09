using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Core.Entities
{
    public class LigneFicheAbsence
    {
        [Key, Column(Order = 1)]
        [ForeignKey("FicheAbsence")]
        public int CodeFicheAbsence { get; set; }

        [Key, Column(Order = 2)]
        [ForeignKey("Etudiant")]
        public int CodeEtudiant { get; set; }

        // Navigation properties
        public FicheAbsence FicheAbsence { get; set; }
        public Etudiant Etudiant { get; set; }
    }
}
