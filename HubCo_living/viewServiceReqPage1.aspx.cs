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
    public partial class viewServiceReqPage1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //String customerID = Application["customerID"].ToString();
                String customerID = "10002";

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|db.mdf;Integrated Security=True;");
                SqlCommand cmd = new SqlCommand("select * from servicerequests a, rooms b where a.roomid = b.roomid and a.customerid = @customerid and actions = 'Pending' ", con);
                con.Open();
                cmd.Parameters.AddWithValue("@customerid", customerID);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);


                da.Fill(ds);
                rpt1.DataSource = ds;
                rpt1.DataBind();

                con.Close();

                SqlCommand cmd2 = new SqlCommand("select * from servicerequests a, rooms b,servicerecords c where a.roomid = b.roomid and a.servicereqid = c.servicereqid and a.customerid = @customerid", con);
                con.Open();
                cmd2.Parameters.AddWithValue("@customerid", customerID);
                DataSet ds2 = new DataSet();
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);


                da2.Fill(ds2);
                rpt2.DataSource = ds2;
                rpt2.DataBind();

                con.Close();

            }
        }

        protected void delBtn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            RepeaterItem item = btn.NamingContainer as RepeaterItem;

            HiddenField hf1 = item.FindControl("hdfserviceReqID") as HiddenField;

            String serviceReqID = hf1.Value.ToString();

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|db.mdf;Integrated Security=True;");
            SqlCommand cmd = new SqlCommand("delete from [serviceRequests] where serviceReqID = @serviceReqID", con);
            con.Open();
            cmd.Parameters.AddWithValue("@serviceReqID", serviceReqID);
            cmd.ExecuteNonQuery();
            con.Close();

            Response.Redirect("viewServiceReqPage1.aspx");

        }
    }
}