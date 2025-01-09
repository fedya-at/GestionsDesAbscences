using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Core.Entities
{
    public class Etudiant
    {
        [Key]
        public int CodeEtudiant { get; set; }

        [Required]
        [StringLength(50)]
        public string? Nom { get; set; }

        [Required]
        [StringLength(50)]
        public string? Prenom { get; set; }
        [Required]
        public DateTime DateNaissance { get; set; }
        [Required]
        public int CodeClasse { get; set; } // Foreign Key

        [Required]
        public int NumInscription { get; set; } 

        [Required]
        public string? Adresse { get; set; }
        [EmailAddress]
        public string? Mail { get; set; }
        [Phone]
        public string? Tel { get; set; }
       

    }
}
