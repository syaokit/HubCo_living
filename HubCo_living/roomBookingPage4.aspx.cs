using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace HubCo_living
{
    public partial class roomBookingPage4 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            amountLbl.Text = "RM" + String.Format("{0:0.00}", Application["paymentAmount"].ToString());

            expDDL1.Items.Clear();
            expDDL2.Items.Clear();

            for (int i = 1; i < 32; i++)
                expDDL1.Items.Add(i.ToString());

            for (int i = 1; i < 13; i++)
                expDDL2.Items.Add(i.ToString());
        }




        protected void confirmBtn_Click(object sender, EventArgs e)
        {

            if (cusCustom1.IsValid == true && cusCustom2.IsValid == true && cusCustom3.IsValid == true)
            {
                //String customeriD = Application["customerID"].ToString();
                String customerID = "10002";
                String roomID = Application["roomID"].ToString();
                DateTime startDate = DateTime.Parse(Application["startDate"].ToString());
                DateTime endDate = DateTime.Parse(Application["endDate"].ToString());
                DateTime bookingDate = DateTime.Today.Date;


                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|db.mdf;Integrated Security=True;");
                SqlCommand cmd = new SqlCommand("insert into [RoomBookings] values (@customerID,@roomID,  @startDate, @endDate, @bookingDate)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@customerID", customerID);
                cmd.Parameters.AddWithValue("@roomID", roomID);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);
                cmd.Parameters.AddWithValue("@bookingDate", bookingDate);

                cmd.ExecuteNonQuery();
                con.Close();

                String bookingID = "";
                SqlCommand cmd2 = new SqlCommand("select top 1 *  from [RoomBookings]  order by bookingID desc ", con);
                con.Open();
                SqlDataReader reader = cmd2.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        bookingID = reader["bookingID"].ToString();
                    }
                }
                con.Close();


                Double paymentAmount = Double.Parse(Application["paymentAmount"].ToString());

                SqlCommand cmd3 = new SqlCommand("insert into [Payments] values (@bookingID,@paymentDate,  @paymentAmount, @paymentDetails)", con);
                con.Open();
                cmd3.Parameters.AddWithValue("@bookingID", bookingID);
                cmd3.Parameters.AddWithValue("@paymentDate", DateTime.Today.Date);
                cmd3.Parameters.AddWithValue("@paymentAmount", paymentAmount);
                cmd3.Parameters.AddWithValue("@paymentDetails", "rental");
                 
                cmd3.ExecuteNonQuery();
                con.Close();


                Response.Write("<script language=javascript>alert('Payment Successfull.')</script>");
                
            }
        }

        protected void cusCustom_ServerValidate(object source, ServerValidateEventArgs args)
        {

            int num;
            bool isInt1 = int.TryParse(cardNumTxt1.Text.ToString(), out num);
            bool isInt2 = int.TryParse(cardNumTxt2.Text.ToString(), out num);
            bool isInt3 = int.TryParse(cardNumTxt3.Text.ToString(), out num);
            bool isInt4 = int.TryParse(cardNumTxt4.Text.ToString(), out num);

            
            if (cardNumTxt1.Text.ToString().Length == 4 && cardNumTxt2.Text.ToString().Length == 4 && cardNumTxt3.Text.ToString().Length == 4 && cardNumTxt4.Text.ToString().Length == 4)
            {
                if(isInt1 == true && isInt2 == true && isInt3 == true && isInt4 == true)
                   args.IsValid = true;
                else
                    args.IsValid = false;
            }
            else
                args.IsValid = false;
        }

        protected void cusCustom2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int num;
            bool isInt1 = int.TryParse(ccvTxt.Text.ToString(), out num);
            
            if (ccvTxt.Text.ToString().Length == 3)
            {
                if (isInt1 == true )
                    args.IsValid = true;
                else
                    args.IsValid = false;
            } 
            else
                args.IsValid = false;
        }

        protected void cusCustom3_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(cardNumTxt1.Text) || string.IsNullOrEmpty(cardNumTxt2.Text) || string.IsNullOrEmpty(cardNumTxt3.Text)|| string.IsNullOrEmpty(cardNumTxt4.Text))
                args.IsValid = false;

        }
    }
}