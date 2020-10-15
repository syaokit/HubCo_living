using System;

namespace HubCo_living
{
    public partial class roomBookingPage1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void searchBtn_Click(object sender, EventArgs e)
        {
            String str = locationTxt.Text.Substring(1);
            String fl = locationTxt.Text[0].ToString().ToUpper();

            Application["location"] = fl + str;
            Application["roomSegment"] = roomSegmentDdl.SelectedValue.ToString();

            //Response.Write("<script language=javascript>alert('Location"+ Application["locationInput"].ToString() + ".')</script>");
            Response.Redirect("roomBookingPage2.aspx");
        }
    }
}