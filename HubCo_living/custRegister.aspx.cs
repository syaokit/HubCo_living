using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HubCo_living
{
    public partial class custRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        
        protected void clearBtn_Click(object sender, EventArgs e)
        {
            emailTxt.Text = "";
            fullNameTxt.Text = "";
            contactNoTxt.Text = "";
            icNumberTxt.Text = "";
            passwordTxt.Text = "";
            rePasswordTxt.Text = "";
            dobTxt.Text = "";
           gender1.Checked = false;
            gender2.Checked = false;

        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            
            string pass1 = passwordTxt.Text;
            string pass2 = rePasswordTxt.Text;
            string email = emailTxt.Text;
            string fullname = fullNameTxt.Text;
            string contactNo = contactNoTxt.Text;
            string icNumber = icNumberTxt.Text;
            string gender = "";
            DateTime dob = DateTime.Parse( dobTxt.Text.ToString());


            if (gender1.Checked == true)
            {
                gender = "male";
            }
            else
            {
                gender = "female";
            }

            String validInfo = validateInfo(contactNo, icNumber, dob);
            String validPass = validatePassword(pass1, pass2);
            Boolean validEmail = validateEmail(email);


            errList.Text = "";
            String errMsg = "";

            if (validEmail == true && validPass.Equals("") && validInfo.Equals(""))
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|db.mdf;Integrated Security=True;");
                SqlCommand cmd = new SqlCommand("insert into [Customers] values (@fullName,@email,  @contactNo, @gender, @icNumber, @dob,@password )", con);
                con.Open();
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@fullName", fullname);
                cmd.Parameters.AddWithValue("@contactNo", contactNo);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@icNumber", icNumber);
                cmd.Parameters.AddWithValue("@dob", dob);
                cmd.Parameters.AddWithValue("@password", pass1);
                cmd.ExecuteNonQuery();
                con.Close();

                emailTxt.Text = "";
                fullNameTxt.Text = "";
                contactNoTxt.Text = "";
                icNumberTxt.Text = "";
                passwordTxt.Text = "";
                rePasswordTxt.Text = "";
                dobTxt.Text = "";
                gender1.Checked = false;
                gender2.Checked = false;
                errList.Text = "Account has been created successful";
                errList.Style["color"] = "green";
            }
            else
            {
                errMsg += validPass;
                errMsg += validInfo;

                if (validEmail != true)
                    errMsg += "Email is already exist<br/>";

                errList.Text = errMsg;
                errList.Style["color"] = "red";

            }
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

        private Boolean validateEmail(string email)
        {
            Boolean valid = true;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|db.mdf;Integrated Security=True;");
            SqlCommand cmd = new SqlCommand("select email from [Customers] where email = @email ", con);
            con.Open();
            cmd.Parameters.AddWithValue("@email", email);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                valid = false;
            }
            con.Close();

            return valid;
        }

        private String validateInfo(string contactNo, string icNumber, DateTime dob)
        {
            String errMsg = "";

            //check contact Number
            Boolean validContactNo = true;

            if (contactNo.Length != 10)
            {
                validContactNo = false; 
            }
            for(int i=0; i < contactNo.Length; i++)
            {
                char number = contactNo[i];
                if (!(Char.IsDigit(number)))
                {
                    validContactNo = false;
                }
            }

            if(validContactNo==false)
                errMsg += "Contact Number should be 10 digits number..<br/>";

            //check ic Number
            Boolean validIcNo = true;

            if (icNumber.Length != 12)
            {
                validIcNo = false;
            }
            for (int i = 0; i < icNumber.Length; i++)
            {
                char number = icNumber[i];
                if (!(Char.IsDigit(number)))
                {
                    validIcNo = false;
                }
            }

            if (validIcNo == false)
                errMsg += "IC  Number should be 12 digits number..<br/>";

            //check dob 
            DateTime now = DateTime.Now;
            if(now.CompareTo(dob) == -1)
            {
                errMsg += "D.O.B should be earlier than today date..<br/>";
            }

            return errMsg;
        }

       
    }
}