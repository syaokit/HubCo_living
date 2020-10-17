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
    public partial class viewBookingPage1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            reqBtn.Enabled = false;
            if (!IsPostBack)
            {
                //String customerID = Application["customerID"].ToString();
                String customerID = "10002";

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|db.mdf;Integrated Security=True;");
                SqlCommand cmd = new SqlCommand("select * from roomBookings a , payments b, rooms c where a.roomid = c.roomid and a.bookingid = b.bookingid and a.customerid =@customerid", con);
                con.Open();
                cmd.Parameters.AddWithValue("@customerid", customerID);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);


                da.Fill(ds);
                rpt1.DataSource = ds;
                rpt1.DataBind();
            }
        }

         

        protected void viewBtn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            RepeaterItem item = btn.NamingContainer as RepeaterItem;

            HiddenField hf1 = item.FindControl("hdfBookingID") as HiddenField;
             

            String bookingID = hf1.Value.ToString();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|db.mdf;Integrated Security=True;");
            SqlCommand cmd = new SqlCommand("select * from roomBookings a , payments b, rooms c where a.roomid = c.roomid and a.bookingid = b.bookingid and a.bookingID =@bookingID", con);
            con.Open();
            cmd.Parameters.AddWithValue("@bookingID", bookingID);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                   
                    Application["bookingID"] = reader["bookingID"].ToString();
                    lblBookingID2.Text = reader["bookingID"].ToString();
                    lblBookingDate2.Text = DateTime.Parse(reader["bookingDate"].ToString()).ToShortDateString();
                    lblRoomName2.Text = reader["roomName"].ToString();
                    lblStartDate.Text = DateTime.Parse(reader["startDate"].ToString()).ToShortDateString();
                    lblEndDate.Text = DateTime.Parse(reader["endDate"].ToString()).ToShortDateString();
                    lblPaymentAmount.Text = "RM" + string.Format("{0:0.00}", reader["paymentAmount"].ToString());
                }
            }

            con.Close();
            reqBtn.Enabled = true;
        }

        protected void delBtn_Click(object sender, EventArgs e)
        {

             Button btn = sender as Button;
           RepeaterItem item = btn.NamingContainer as RepeaterItem;

           HiddenField hf1 = item.FindControl("hdfBookingID2") as HiddenField;
           HiddenField hf2 = item.FindControl("hdfPaymentID") as HiddenField;

           String bookingID = hf1.Value.ToString();
           String paymentID = hf2.Value.ToString();

           SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|db.mdf;Integrated Security=True;");
           SqlCommand cmd = new SqlCommand("delete from [payments] where paymentid = @paymentid", con);
           con.Open();
           cmd.Parameters.AddWithValue("@paymentid", paymentID);
           cmd.ExecuteNonQuery();
           con.Close();

           SqlCommand cmd2 = new SqlCommand("delete from [roombookings] where bookingID = @bookingID", con);
           con.Open();
           cmd2.Parameters.AddWithValue("@bookingID", bookingID);
           cmd2.ExecuteNonQuery();
           con.Close();

            Response.Redirect("viewBookingPage1.aspx");
        }

        protected void reqBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("serviceReqPage1.aspx");
        }
    }
}