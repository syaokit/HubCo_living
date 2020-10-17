using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HubCo_living
{
    public partial class custDetailsAdmin : System.Web.UI.Page
    {
        int custID = 0;
        String roomID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    custID = int.Parse(Application["custID"].ToString());
                    lblID.Text = Application["custID"].ToString();

                    getCustomerDetails();
                }
                catch (Exception ex)
                {
                    Response.Write("<script language=javascript>alert('Please select a customer!')</script>");
                    Response.Redirect("AllCustomersAdmin.aspx");
                }
                roomID = "";
                bindGridViewRequests();
                bindGridViewRecords();
            }
            if (IsPostBack) {
                bindGridViewRequests();
                bindGridViewRecords();
            }
            
        }

        private void getCustomerDetails()
        {
            int requests;
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cheem\source\repos\syaokit_new\HubCo_living\HubCo_living\App_Data\db.mdf;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("select a.customerID, a.fullName, a.email, a.contactNo, a.gender, a.icNumber,a.dob, COUNT(b.serviceReqID) AS unhandled_request FROM Customers AS a LEFT OUTER JOIN (SELECT serviceReqID, customerID FROM ServiceRequests WHERE (actions != 'Complete')) AS b ON a.customerID = b.customerID where a.customerID=@customerID Group BY a.customerID, a.fullName, a.email, a.contactNo, a.gender, a.icNumber, a.password, a.dob;", con);
                con.Open();
                cmd.Parameters.AddWithValue("@customerID", lblID.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        lblID.Text = reader["customerID"].ToString();
                        lblName.Text = reader["fullName"].ToString();
                        lblEmail.Text = reader["email"].ToString();
                        lblContact.Text = reader["contactNo"].ToString();
                        lblGender.Text = reader["gender"].ToString();
                        lblIC.Text = reader["icNumber"].ToString();
                        lblDOB.Text = DateTime.Parse(reader["dob"].ToString()).ToShortDateString();
                        requests = int.Parse(reader["unhandled_request"].ToString());

                        if (requests == 0)
                            lblPendingText.Text = "There are NO pending requests!!";
                        else
                            lblPending.Text = requests.ToString();
                    }
                }
                else
                {
                    Response.Write("<script language=javascript>alert('This customer cannot be found!')</script>");
                    Response.Redirect("AllCustomersAdmin.aspx");

                }
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script language=javascript>alert('There is a problem loading the customer data!')</script>");
                Response.Redirect("AllCustomersAdmin.aspx");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            mpeRequests.Show();
            GridViewRow row = GridView1.SelectedRow;
            String reqID = row.Cells[1].Text;
            lblReqID.Text = reqID;

            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cheem\source\repos\syaokit_new\HubCo_living\HubCo_living\App_Data\db.mdf;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("select a.*, b.unitNumber, concat(b.address, ', ', b.city , ', ', b.postcode ,', ', b.state) as Address from ServiceRequests a, Rooms b where a.roomID=b.roomID and a.serviceReqID=@serviceReqID", con);
                con.Open();
                cmd.Parameters.AddWithValue("@serviceReqID", reqID);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        lblUnit.Text = reader["unitNumber"].ToString();
                        lblRoomID.Text = reader["roomID"].ToString();
                        lblAddress.Text = reader["Address"].ToString();
                        lblReqType.Text = reader["requestType"].ToString();
                        lblDate.Text = reader["requestDate"].ToString();
                        lblDesc.Text = reader["descriptions"].ToString();
                        cbAction.SelectedValue= reader["actions"].ToString();
                    }
                }
                else
                {
                    Response.Write("<script language=javascript>alert('This service request cannot be found!')</script>");
                    Response.Redirect("AllCustomersAdmin.aspx");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script language=javascript>alert('Something went wrong while loading service request data!')</script>");
            }
        }

        private void bindGridViewRequests()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cheem\source\repos\syaokit_new\HubCo_living\HubCo_living\App_Data\db.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select serviceReqID, roomID, requestType,  format( requestDate,'dd-MM-yy') as requestDate, actions from ServiceRequests where actions<>'Complete' and customerID=@custID", con);
            con.Open();
            cmd.Parameters.AddWithValue("@custID",lblID.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            con.Close();
        }

        private void bindGridViewRecords()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cheem\source\repos\syaokit_new\HubCo_living\HubCo_living\App_Data\db.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select a.serviceRecordID, a.serviceReqID, b.requestType as 'Request Type',  b.descriptions as 'Request Descripion', format(b.requestDate, 'dd-MM-yyyy') as 'Request Date', a.description as 'Actions Done', format(a.date, 'dd-MM-yyyy') as 'Date Completed', a.time as 'Time Completed'," +
                                                   "c.roomID as 'Room ID', concat(c.unitNumber,', ',address, ', ', c.city , ', ', c.postcode ,', ', c.state) as 'Room Address', a.cost as 'Cost (RM)'" +
                                            "from serviceRecords a, serviceRequests b, Rooms c " +
                                            "where a.serviceReqID = b.serviceReqID and a.roomID=c.roomID and b.roomID=c.roomID and b.customerID=@customerID and b.roomID like '%"+ roomID+"%' " +
                                            "order by a.date desc, a.time desc;", con);
            con.Open();
            cmd.Parameters.AddWithValue("@customerID", lblID.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            GridView2.DataSource = ds;
            GridView2.DataBind();
            con.Close();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            String action = cbAction.SelectedValue.ToString();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cheem\source\repos\syaokit_new\HubCo_living\HubCo_living\App_Data\db.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("update ServiceRequests set actions=@actions where serviceReqID=@serviceReqID", con);

            if (action != "Complete")
            {
                try
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@actions", action);
                    cmd.Parameters.AddWithValue("@serviceReqID", lblReqID.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script language=javascript>alert('Update success!')</script>");
                    bindGridViewRequests();
                }
                catch (Exception ex)
                {
                    Response.Write("<script language=javascript>alert('Something went wrong while updating cleaning request!')</script>");
                }
            }
            else
            {
                mpeComplete.Show();
                lblReqID2.Text = lblReqID.Text;
            }
            

        }

        protected void btnUpdate2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cheem\source\repos\syaokit_new\HubCo_living\HubCo_living\App_Data\db.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("INSERT INTO ServiceRecords values(@roomID, @serviceReqID, @description, @date, @time, @cost)", con);
            con.Open();
            cmd.Parameters.AddWithValue("@roomID", lblRoomID.Text);
            cmd.Parameters.AddWithValue("@serviceReqID", lblReqID2.Text);
            cmd.Parameters.AddWithValue("@description", txtServiceDetails.Text);
            cmd.Parameters.AddWithValue("@date", DateTime.Now.Date);
            cmd.Parameters.AddWithValue("@time", DateTime.Now.ToLongTimeString());
            cmd.Parameters.AddWithValue("@cost", txtCost.Text);

            cmd.ExecuteNonQuery();
            lblPending.Text = (int.Parse(lblPending.Text) - 1).ToString();
            con.Close();
            Response.Write("<script language=javascript>alert('Update success!')</script>");
            bindGridViewRequests();
            bindGridViewRecords();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            roomID = txtSearch.Text;
            bindGridViewRecords();
        }
    }
}