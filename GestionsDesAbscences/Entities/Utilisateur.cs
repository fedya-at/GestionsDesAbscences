using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Utilisateur
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string NomUtilisateur { get; set; }

        [Required]
        public string MotDePasse { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
