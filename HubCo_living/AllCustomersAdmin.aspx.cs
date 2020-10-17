using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace HubCo_living
{
    public partial class AllCustomersAdmin : System.Web.UI.Page
    {
        private String searchName = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                displayEmployee();
            }
        }

        private void displayEmployee()
        {
            searchName = txtSearch.Text;
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cheem\source\repos\syaokit_new\HubCo_living\HubCo_living\App_Data\db.mdf;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("select a.customerID, a.fullName, a.email, a.contactNo, COUNT(b.serviceReqID) AS unhandled_request FROM Customers AS a LEFT OUTER JOIN (SELECT serviceReqID, customerID FROM ServiceRequests WHERE (actions != 'Complete')) AS b ON a.customerID = b.customerID GROUP BY a.customerID, a.fullName, a.email, a.contactNo having a.fullName like" + "'%" + searchName + "%'", con);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataList1.DataSource = dt;
                DataList1.DataBind();
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script language=javascript>alert('An error occured when loading customer data.')</script>");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            displayEmployee();
        }

        protected void btnView_Click(object sender, CommandEventArgs e)
        {
            Application["custID"] = e.CommandArgument.ToString();
            Response.Redirect("custDetailsAdmin.aspx");
        }
    }
}