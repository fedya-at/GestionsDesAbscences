namespace Application.DTOs
{
    public class EtudiantDTO
    {
        public int CodeEtudiant { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public int NumInscription { get; set; }
        public int CodeClasse { get; set; }
        public string? Adresse { get; set; }
        public string? Mail { get; set; }
        public string? Tel { get; set; }
    }
}
