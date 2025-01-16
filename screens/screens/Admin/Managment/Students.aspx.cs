using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace screens.screens.Admin.Managment
{
    public partial class Students : System.Web.UI.Page
    {
        private const string ApiUrl = "http://localhost:5024/api/Etudiant";

        protected  async void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
               await  LoadStudentsAsync();
            }

        }

        protected void btnLogout_OnClick(object sender, EventArgs e)
        {
            // Clear the authentication token from session
            Session["AuthToken"] = null;

            // Optionally, clear other session data if necessary
            Session.Abandon(); // To end the session completely

            // Redirect the user to the login page
            Response.Redirect("../Authentification/Authentification.aspx"); // Replace with your login page URL
        }

        protected async void btnSubmit_Click(object sender, EventArgs e)
        {
            int numInscription, codeClasse;
            DateTime dateNaissance;

            if (!int.TryParse(txtNumInscription.Text, out numInscription))
            {
                Response.Write("Numéro d'inscription invalide.");
                return;
            }

            if (!int.TryParse(txtCodeClasse.Text, out codeClasse))
            {
                Response.Write("Code de classe invalide.");
                return;
            }

            if (!DateTime.TryParse(txtDateNaissance.Text, out dateNaissance))
            {
                Response.Write("Date de naissance invalide.");
                return;
            }

            var etudiant = new
            {
                codeEtudiant = 0,
                nom = txtNom.Text,
                prenom = txtPrenom.Text,
                dateNaissance = dateNaissance,
                numInscription = numInscription,
                codeClasse = codeClasse,
                adresse = txtAdresse.Text,
                mail = txtMail.Text,
                tel = txtTel.Text
            };

            string json = JsonConvert.SerializeObject(etudiant);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.PostAsync("http://localhost:5024/api/Etudiant", content);

                    if (response.IsSuccessStatusCode)
                    {
                        Response.Write("Étudiant ajouté avec succès.");
                    }
                    else
                    {
                        Response.Write("Erreur lors de l'ajout de l'étudiant.");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write($"Erreur: {ex.Message}");
                }
            }
        }
        private async Task LoadStudentsAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(ApiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        List<EtudiantDTO> students = JsonConvert.DeserializeObject<List<EtudiantDTO>>(jsonResponse);
                        GenerateStudentTable(students);
                    }
                    else
                    {
                        // Handle error response
                        ErrorLabel.Text = "Failed to load students.";
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                ErrorLabel.Text = $"Error: {ex.Message}";
            }
        }

        private void GenerateStudentTable(List<EtudiantDTO> students)
        {
            foreach (var student in students)
            {
                TableRow row = new TableRow();

                row.Cells.Add(new TableCell { Text = student.Nom ?? string.Empty });
                row.Cells.Add(new TableCell { Text = student.Prenom ?? string.Empty });
                row.Cells.Add(new TableCell { Text = student.DateNaissance.ToString("yyyy-MM-dd") });
                row.Cells.Add(new TableCell { Text = student.Mail ?? string.Empty });
                row.Cells.Add(new TableCell { Text = student.Tel ?? string.Empty });

                TableCell actionCell = new TableCell();
                Button editButton = new Button { Text = "Modifier", CssClass = "btn-action btn-edit" };
                Button deleteButton = new Button { Text = "Supprimer", CssClass = "btn-action btn-delete" };

                // Add event handlers for actions if needed
                actionCell.Controls.Add(editButton);
                actionCell.Controls.Add(deleteButton);

                row.Cells.Add(actionCell);
                StudentsTable.Rows.Add(row);
            }
        }

        // Local DTO class for Student
        public class EtudiantDTO
        {
            public int CodeEtudiant { get; set; }
            public string Nom { get; set; }
            public string Prenom { get; set; }
            public DateTime DateNaissance { get; set; }
            public int NumInscription { get; set; }
            public int CodeClasse { get; set; }
            public string Adresse { get; set; }
            public string Mail { get; set; }
            public string Tel { get; set; }
        }


    }
}