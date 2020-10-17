using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HubCo_living
{
    public partial class serviceReqPage1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String bookingID = Application["bookingID"].ToString();

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|db.mdf;Integrated Security=True;");
            SqlCommand cmd = new SqlCommand("select * from roomBookings a , rooms b where a.roomid = b.roomid  and a.bookingID =@bookingID", con);
            con.Open();
            cmd.Parameters.AddWithValue("@bookingID", bookingID);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    lblCustomerID.Text = reader["customerID"].ToString();
                    lblBookingID.Text = reader["bookingID"].ToString();
                    lblRoomName.Text = reader["roomName"].ToString();
                    Session["roomID"] = reader["roomID"].ToString();
                }
            }
            con.Close();
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {

            String customerID = lblCustomerID.Text;
            String roomID = Session["roomID"].ToString();
            String requestType = ddlRequestType.SelectedValue;
            DateTime requestDate = DateTime.Today.Date;
            String descriptions = txtDesc.Text;


            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|db.mdf;Integrated Security=True;");
            SqlCommand cmd = new SqlCommand("insert into [serviceRequests] values (@customerID,@roomID,  @requestType, @requestDate, @descriptions,@actions)", con);
            con.Open();
            cmd.Parameters.AddWithValue("@customerID", customerID);
            cmd.Parameters.AddWithValue("@roomID", roomID);
            cmd.Parameters.AddWithValue("@requestType", requestType);
            cmd.Parameters.AddWithValue("@requestDate", requestDate);
            cmd.Parameters.AddWithValue("@descriptions", descriptions);
            cmd.Parameters.AddWithValue("@actions", "Pending");
            cmd.ExecuteNonQuery();
            con.Close();

            Response.Write("<script language=javascript>alert('Your request have been recorded')</script>");

            txtDesc.Text = "";
            ddlRequestType.SelectedIndex = 0;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewBookingPage1.aspx");
        }
    }
}