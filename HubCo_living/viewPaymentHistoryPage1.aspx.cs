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
    public partial class viewPaymentHistoryPage1 : System.Web.UI.Page
    {
        Double total = 0.0;
        protected void Page_Load(object sender, EventArgs e)
        {
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

                con.Close();

                SqlCommand cmd2 = new SqlCommand("select sum(paymentAmount) as total from roomBookings a , payments b where  a.bookingid = b.bookingid and a.customerid =@customerid group by customerid", con);
                con.Open();
                cmd2.Parameters.AddWithValue("@customerid", customerID);
                SqlDataReader reader = cmd2.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        lblTotal.Text = String.Format("{0:0.00}", reader["total"].ToString());
                    }
                }
                con.Close();
            }
        }

        protected void viewBtn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            RepeaterItem item = btn.NamingContainer as RepeaterItem;

            HiddenField hf1 = item.FindControl("hdfPaymentID") as HiddenField;

            String paymentID = hf1.Value.ToString();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|db.mdf;Integrated Security=True;");
            SqlCommand cmd = new SqlCommand("select * from roomBookings a , payments b, rooms c where a.roomid = c.roomid and a.bookingid = b.bookingid and b.paymentID =@paymentID", con);
            con.Open();
            cmd.Parameters.AddWithValue("@paymentID", paymentID);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    lblPaymentID2.Text = reader["paymentID"].ToString();
                    lblPaymentDate.Text = DateTime.Parse(reader["paymentDate"].ToString()).ToShortDateString();
                    lblBookingID.Text = reader["bookingID"].ToString();
                    lblRoomName.Text = reader["roomName"].ToString();
                    lblPayemntDetails.Text = reader["paymentDetails"].ToString();
                    lblPaymentAmount.Text = "RM" + string.Format("{0:0.00}", reader["paymentAmount"].ToString());
                }
            }

            con.Close();
        }
    }
}