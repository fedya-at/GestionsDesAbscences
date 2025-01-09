using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Classe
    {
        [Key]
        public int CodeClasse { get; set; }

        [Required]
        [StringLength(100)]
        public string? NomClasse { get; set; }

        [ForeignKey("CodeGroupe")]
        [Required]
        public int CodeGroupe { get; set; } // Foreign Key

        [ForeignKey("CodeDepartement")]
        [Required]
        public int CodeDepartement { get; set; }
        public ICollection<Etudiant>? Etudiants { get; set; }
        // Foreign Key
    }
}
