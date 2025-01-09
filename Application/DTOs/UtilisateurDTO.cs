namespace Application.DTOs
{
    public class UtilisateurDTO
    {
        public int CodeUtilisateur { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public string? Password { get; set; }
    }
}