using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace screens.screens.Students
{
    public partial class studentDash : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnLogout_OnClick(object sender, EventArgs e)
        {
            Session["AuthToken"] = null;

            Session.Abandon(); // To end the session completely

            Response.Redirect("../Authentification/Authentification.aspx"); // Replace with your login page URL
        }
    }
}