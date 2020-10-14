using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HubCo_living
{
    public partial class roomBookingPage2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                RepeaterData();
            }

        }

        private void RepeaterData()
        {
            String location = Application["locationInput"].ToString();
            String roomType = Application["roomType"].ToString();
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|db.mdf;Integrated Security=True;");
                SqlCommand cmd = new SqlCommand("select * from ( select a.*, b.imageContent, ROW_NUMBER() over(partition by a.roomID order by a.roomID) as rownum from Rooms a, PropertyImages b where a.roomID=b.roomID and a.roomType = @roomType and a.city = @city) as c where c.rownum=1 ;", con);
                con.Open();
                cmd.Parameters.AddWithValue("@roomType", roomType);
                cmd.Parameters.AddWithValue("@city", location);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                
                da.Fill(ds);
                rpt1.DataSource = ds;
                rpt1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script language=javascript>alert('An error occured when loading room data.')</script>");
            }
        }

        protected string GetImage(object img)
        {
            return "data:image/jpg;base64, " + Convert.ToBase64String((byte[])img);
        }

        protected void viewBtn_Click(object sender, CommandEventArgs e)
        {
            String roomID = e.CommandArgument.ToString();
            Application["roomID"] = roomID;
            //Response.Write("<script language=javascript>alert('Room ID " + roomID + " have been clicked.')</script>");
            Response.Redirect("roomBookingPage3.aspx");
        }
    }
}