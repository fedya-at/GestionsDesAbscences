using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using SlackAPI;


namespace screens.screens.Authentification
{
    public partial class Authentification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected async void btnLogin_Onclick(object sender, EventArgs e)
        {
            string username = TextBoxUsername.Text;
            string password = TextBoxPassword.Text;

            // Prepare the login request body
            var loginRequest = new
            {
                username = username,
                password = password
            };

            var json = JsonConvert.SerializeObject(loginRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.PostAsync("http://localhost:5024/api/Auth/login", content);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<LoginResponse>(responseBody);

                        Session["AuthToken"] = result.Token;

                        var userRole = DecodeJwtToken(result.Token); // You can implement JWT decoding in this method

                        switch (userRole.ToLower())
                        {
                            case "admin":
                                Response.Redirect("../Admin/adminDash.aspx");
                                break;
                            case "student":
                                Response.Redirect("../Students/studentDash.aspx");
                                break;
                            case "teacher":
                                Response.Redirect("../Teacher/teacherDash.aspx");
                                break;
                            default:
                                Response.Write("Rôle inconnu ou échec de la connexion.");
                                break;
                        }
                    }
                    else
                    {
                        Response.Write("Nom d'utilisateur ou mot de passe incorrect.");
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions (e.g., network issues)
                    Response.Write($"Erreur: {ex.Message}");
                }
            }
        }

        private string DecodeJwtToken(string token)
        {
            // Decode the JWT token and extract the role
            var jwtHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var jwtToken = jwtHandler.ReadJwtToken(token);
            var roleClaim = jwtToken?.Claims.FirstOrDefault(c => c.Type == "role")?.Value;

            return roleClaim;
        }
    }

    // Model to parse the response (API response containing the token)
    public class LoginResponse
    {
        public string Token { get; set; }
    } 
}