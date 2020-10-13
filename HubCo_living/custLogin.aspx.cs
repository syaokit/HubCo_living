using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HubCo_living
{
    public partial class custLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            String email = txtEmail.Text;
            String password = txtPassword.Text;

            if (email.Length == 0 || password.Length == 0)
            {
                Response.Write("<script language=javascript>alert('Please fill in all fields.')</script>");
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|db.mdf;Integrated Security=True;");
                SqlCommand cmd = new SqlCommand("select password from Customers where email = @email ", con);
                con.Open();
                cmd.Parameters.AddWithValue("@email", email);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        if (reader["password"].ToString() == password.ToString())
                        {
                            Application["custId"] = reader["custID"].ToString();
                            Response.Write("<script language=javascript>alert('Login Success.')</script>");
                            Response.Redirect("roomTypeSelect.aspx");
                        }
                        else
                        {
                            Label1.Text = reader["password"].ToString();
                            Response.Write("<script language=javascript>alert('Password Invalid.')</script>");
                        }
                    }

                }
                else
                {
                    Response.Write("<script language=javascript>alert('User not exist.')</script>");
                }
                con.Close();
            }

        }


    }
}