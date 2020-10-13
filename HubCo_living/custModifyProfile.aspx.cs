using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HubCo_living
{
    public partial class custModifyProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                loadData(); 
            }
        }

        private void loadData()
        {
            //String customerID = Application["customerID"].ToString();
            String customerID = "10000";

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|db.mdf;Integrated Security=True;");
            SqlCommand cmd = new SqlCommand("select * from Customers where customerID = @customerID ", con);
            con.Open();
            cmd.Parameters.AddWithValue("@customerID", customerID);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                if (reader.Read())
                {

                    emailTxt.Text = reader["email"].ToString();
                    fullNameTxt.Text = reader["fullName"].ToString();
                    contactNoTxt.Text = reader["contactNo"].ToString();
                    icNumberTxt.Text = reader["icNumber"].ToString();

                    if (reader["gender"].ToString().Equals("male"))
                        gender1.Checked = true;
                    else
                        gender2.Checked = true;



                    dobTxt.Text = DateTime.Parse(reader["dob"].ToString()).ToString("yyyy-MM-dd");

                    emailTxt.Enabled = false;

                }

            }
        }

        protected void confirmBtn_Click(object sender, EventArgs e)
        {
           
            //String customerID = Application["customerID"].ToString();
            String customerID = "10000";


            String email = emailTxt.Text;
            String fullname = fullNameTxt.Text;
            String contactNo = contactNoTxt.Text;
            String icNumber = icNumberTxt.Text;
            String gender = "";
            DateTime dob = DateTime.Now;

            String errMsg = "";

            if (dobTxt.Text.ToString().Equals(""))
            {
                errMsg += "Please select a date.. <br/>";
            }
            else
            {
                dob= DateTime.Parse(dobTxt.Text.ToString()); 
            }


            if (gender1.Checked == true)
            {
                gender = "male";
            }
            else
            {
                gender = "female";
            }

            String validInfo = validateInfo(contactNo, icNumber, dob);
            

            if  (validInfo.Equals(""))
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|db.mdf;Integrated Security=True;");
                SqlCommand cmd = new SqlCommand("update [Customers] set email = @email , fullName = @fullName , contactNo = @contactNo " +
                    ", gender = @gender , icNumber=@icNumber , dob = @dob where customerID = @customerID ", con);
                con.Open();
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@fullName", fullname);
                cmd.Parameters.AddWithValue("@contactNo", contactNo);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@icNumber", icNumber);
                cmd.Parameters.AddWithValue("@dob", dob);
                cmd.Parameters.AddWithValue("@customerID", customerID);
                cmd.ExecuteNonQuery();
                con.Close();

                loadData();
                errList.Text = "Profile have been updated successfull";
                errList.Style["color"] = "green";
            }
            else
            {
             
                errMsg += validInfo;

                

                errList.Text = errMsg;
                errList.Style["color"] = "red";

            }

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
            for (int i = 0; i < contactNo.Length; i++)
            {
                char number = contactNo[i];
                if (!(Char.IsDigit(number)))
                {
                    validContactNo = false;
                }
            }

            if (validContactNo == false)
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
            if (now.CompareTo(dob) == -1)
            {
                errMsg += "D.O.B should be earlier than today date..<br/>";
            }

            return errMsg;
        }

        protected void clearBtn_Click(object sender, EventArgs e)
        {
             
            fullNameTxt.Text = "";
            contactNoTxt.Text = "";
            icNumberTxt.Text = "";
            dobTxt.Text = "";
            gender1.Checked = true;
            gender2.Checked = false;
        }
    }
}