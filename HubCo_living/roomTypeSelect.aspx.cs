using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HubCo_living
{
    public partial class roomTypeSelect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ApartelBtn_Click(object sender, EventArgs e)
        {
            Application["roomType"] = "Apartel";
            Response.Redirect("apartelPage1.aspx");
        }

        protected void ColivingBtn_Click(object sender, EventArgs e)
        {
            Application["roomType"] = "Coliving";
            Response.Redirect("colivingPage1.aspx");
        }
    }
}