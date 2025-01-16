using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace screens.screens.Admin.Managment
{
    public partial class Modules : System.Web.UI.Page
    {
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