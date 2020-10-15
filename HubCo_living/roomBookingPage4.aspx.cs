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
            expDDL1.Items.Clear();
            expDDL2.Items.Clear();

            for (int i = 1; i < 32; i++)
                expDDL1.Items.Add(i.ToString());

            for (int i = 1; i < 13; i++)
                expDDL2.Items.Add(i.ToString());
        }




        protected void confirmBtn_Click(object sender, EventArgs e)
        {



            //String customeriD = Application["customerID"].ToString();
            /*String customerID = "10001";
            String roomID = Application["roomID"].ToString();
            DateTime startDate = DateTime.Parse(Application["startDate"].ToString());
            DateTime endDate = DateTime.Parse(Application["endDate"].ToString());
            DateTime bookingDate = DateTime.Today.Date;


            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|db.mdf;Integrated Security=True;");
            SqlCommand cmd = new SqlCommand("insert into [RoomBooking] values (@customerID,@roomID,  @startDate, @endDate, @bookingDate)", con);
            con.Open();
            cmd.Parameters.AddWithValue("@customerID", customerID);
            cmd.Parameters.AddWithValue("@roomID", roomID);
            cmd.Parameters.AddWithValue("@startDate", startDate);
            cmd.Parameters.AddWithValue("@endDate", endDate);
            cmd.Parameters.AddWithValue("@bookingDate", bookingDate);
             
            cmd.ExecuteNonQuery();
            con.Close();

            Response.Write("<script language=javascript>alert('Room Booking Successfull.')</script>");
            */
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
    }
}