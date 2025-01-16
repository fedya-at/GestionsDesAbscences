using System;
using System.Web.UI;

namespace screens.screens.Admin
{
    public partial class ManageAbsence : System.Web.UI.Page
    {
       
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Console.WriteLine("rescher tekhdem");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
          
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
    }
}
