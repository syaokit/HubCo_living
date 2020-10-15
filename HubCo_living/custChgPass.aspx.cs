using System;
using System.Data.SqlClient;

namespace HubCo_living
{
    public partial class custChgPass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void confirmBtn_Click(object sender, EventArgs e)
        {
            // String customerID = Application["customerID"].ToString();
            String customerID = "10000";

            String oldPass = oldPasswordTxt.Text;
            String newPass1 = newPasswordTxt.Text;
            String newPass2 = renewPasswordTxt.Text;
            String errMsg = "";

            bool valid = validateOldPass(customerID, oldPass);

            if (valid == true)
            {
                String validP = validatePassword(newPass1, newPass2);
                if (validP == "")
                {

                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|db.mdf;Integrated Security=True;");
                    SqlCommand cmd = new SqlCommand("update [Customers] set password = @password where customerID = @customerID", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@customerID", customerID);
                    cmd.Parameters.AddWithValue("@password", newPass2);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    oldPasswordTxt.Text = "";
                    newPasswordTxt.Text = "";
                    renewPasswordTxt.Text = "";
                    errList.Text = "Password updated successfully";
                    errList.Style["color"] = "green";
                }
                else
                {
                    errMsg += validP;
                    errList.Text = errMsg;
                    errList.Style["color"] = "red";
                }
            }
            else
            {
                errMsg += "Your old password is wrong";
                errList.Text = errMsg;
                errList.Style["color"] = "red";
            }
        }

        protected void clearBtn_Click(object sender, EventArgs e)
        {
            oldPasswordTxt.Text = "";
            newPasswordTxt.Text = "";
            renewPasswordTxt.Text = "";
        }


        private bool validateOldPass(string customerID, string oldPass)
        {
            bool valid = false;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|db.mdf;Integrated Security=True;");
            SqlCommand cmd = new SqlCommand("select * from [Customers] where customerID = @customerID and password = @password ", con);
            con.Open();
            cmd.Parameters.AddWithValue("@customerID", customerID);
            cmd.Parameters.AddWithValue("@password", oldPass);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                valid = true;
            }
            con.Close();

            return valid;
        }

        private String validatePassword(string password, string password2)
        {
            String msg = "";
            Boolean valid1 = false;
            Boolean valid2 = false;

            //check diff
            if (password.Equals(password2))
            {

                //check length
                if (password.Length >= 8)
                {
                    //check contain digit
                    for (int i = 0; i < password.Length; i++)
                    {
                        char c = password[i];
                        if (Char.IsDigit(c))
                        {
                            valid1 = true;
                            break;
                        }

                    }

                    //check contain letter
                    for (int i = 0; i < password.Length; i++)
                    {
                        char c = password[i];
                        if (Char.IsLetter(c))
                        {
                            valid2 = true;
                            break;
                        }

                    }

                    if (valid1 == false || valid2 == false)
                        msg += "Password must contains alphanumeric <br/>";
                }
                else
                {
                    msg += "Password length must more than 8 <br/>";
                }

            }
            else
            {
                msg += "Password and Confirm Password are different <br/>";
            }




            return msg;
        }
    }
}