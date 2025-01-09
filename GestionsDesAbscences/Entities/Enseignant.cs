using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Enseignant
    {
        [Key]
        public int CodeEnseignant { get; set; }

        [Required]
        [StringLength(50)]
        public string? Nom { get; set; }

        [Required]
        [StringLength(50)]
        public string? Prenom { get; set; }

        [Required]
        public DateTime DateRecrutement { get; set; }

        [StringLength(200)]
        public string? Adresse { get; set; }

        [EmailAddress]
        public string? Mail { get; set; }

        [Phone]
        public string? Tel { get; set; }

        [ForeignKey("CodeDepartement")]
        [Required]

        public int CodeDepartement { get; set; } // Foreign Key

        [ForeignKey("CodeGrade")]
        [Required]
        public int CodeGrade { get; set; } // Foreign Key
    }
}
