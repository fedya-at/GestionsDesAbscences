namespace Application.DTOs
{
    public class EnseignantDTO
    {
        public int CodeEnseignant { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public DateTime DateRecrutement { get; set; }
        public string? Adresse { get; set; }
        public string? Mail { get; set; }
        public string? Tel { get; set; }
        public int CodeDepartement { get; set; }
        public int CodeGrade { get; set; }
    }

}