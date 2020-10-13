using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HubCo_living
{
    public partial class custProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //String custID = Application["custID"].ToString();
            String custID = "10000";

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|db.mdf;Integrated Security=True;");
            SqlCommand cmd = new SqlCommand("select * from Customers where customerID = @customerID ", con);
            con.Open();
            cmd.Parameters.AddWithValue("@customerID", custID);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    emailLbl.Text = reader["email"].ToString();
                    fullNameLbl.Text = reader["fullName"].ToString();
                    contactNo.Text = reader["contactNo"].ToString();
                    genderLbl.Text = reader["gender"].ToString();

                    DateTime dob = DateTime.Parse(reader["dob"].ToString());
                    dobLbl.Text = dob.ToShortDateString();

                    String pass = "";
                    for(int i=0; i< reader["password"].ToString().Length; i++)
                    {
                        pass += '*';
                    }

                    passwordLbl.Text = pass;

                }

            }

        }

        protected void chgPassBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("custChgPass.aspx");
        }

        protected void modifyBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("custModifyProfile.aspx");
        }
    }
}