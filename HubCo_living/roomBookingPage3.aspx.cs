using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HubCo_living
{
    
    public partial class roomBookingPage3 : System.Web.UI.Page
    {
        List<DateTime> invalidDate = new List<DateTime>();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            RepeaterData();
         }

        protected string GetImage(object img)
        {
            return "data:image/jpg;base64, " + Convert.ToBase64String((byte[])img);
        }


        private void RepeaterData()
        {
            //String roomID = Application["roomID"].ToString();

            String roomID = "10008";
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|db.mdf;Integrated Security=True;");
                SqlCommand cmd = new SqlCommand("select  a.*, b.*  from rooms a, propertyimages b where a.roomID = b.roomID and a.roomID = @roomID", con);
                con.Open();
                cmd.Parameters.AddWithValue("@roomID", roomID);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                rpt1.DataSource = ds;
                rpt1.DataBind();

                string address = Convert.ToString(ds.Tables[0].Rows[0]["address"]);
                string unitNumber = Convert.ToString(ds.Tables[0].Rows[0]["unitNumber"]);
                string postcode = Convert.ToString(ds.Tables[0].Rows[0]["postcode"]);
                string city = Convert.ToString(ds.Tables[0].Rows[0]["city"]);
                string state = Convert.ToString(ds.Tables[0].Rows[0]["state"]);
                string status = Convert.ToString(ds.Tables[0].Rows[0]["status"]);
                string price = Convert.ToString(ds.Tables[0].Rows[0]["price"]);

                unitNumberLbl.Text = unitNumber;
                postcodeLbl.Text = postcode;
                cityLbl.Text = city;
                stateLbl.Text = state;
                addressLbl.Text = address;
                statusLbl.Text = status;
                priceLbl.Text = "RM" + String.Format("{0:0.00}", price);
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script language=javascript>alert('An error occured when loading room data.')</script>");
            }


        }

        protected void proceedBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("roomBookingPage4.aspx");
        }

        protected void calendar_DayRender(object sender, DayRenderEventArgs e)
        {
            //String roomId = Application["roomID"].ToString();
            String roomId = "10006";

            // List<DateTime> startDate = new List<DateTime>();
            // List<DateTime> endDate = new List<DateTime>();


            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|db.mdf;Integrated Security=True;");
            SqlCommand cmd = new SqlCommand("select * from roombookings where roomId = @roomId ", con);
            con.Open();
            cmd.Parameters.AddWithValue("@roomId", roomId);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    DateTime startDate = DateTime.Parse(reader["startDate"].ToString());
                    DateTime endDate = DateTime.Parse(reader["endDate"].ToString());

                    if (e.Day.Date >= startDate && e.Day.Date <= endDate)
                    {
                        e.Day.IsSelectable = false;
                        e.Cell.BackColor = Color.Red;
                        invalidDate.Add(e.Day.Date);
                    }
                }

            }
            con.Close();

            Session["invalidDate"] = invalidDate;

            DateTime minDate = DateTime.Today;
            DateTime date = calendar.SelectedDate;

            if (e.Day.Date < minDate)
            {
                e.Day.IsSelectable = false;
            }

            if (e.Day.Date.Equals(date))
            {
                e.Day.IsSelectable = false;
            }
        }

        protected void calendar_SelectionChanged(object sender, EventArgs e)
        {

            DateTime date = calendar.SelectedDate;
            startDateLbl.Text = date.ToShortDateString();
        }

        protected void durationTxt_TextChanged(object sender, EventArgs e)
        {
            int duration = int.Parse(durationTxt.Text.ToString());
            DateTime startDate = DateTime.Parse(startDateLbl.Text.ToString());
            DateTime endDate = startDate.AddDays(duration);

            List<DateTime> newList = (List<DateTime>)Session["invalidDate"];

            int num = 1;
            for(int i=0; i<duration;i++)
            {
                DateTime d = startDate.AddDays(num);
                foreach(DateTime dt in newList)
                {
                    if (d == dt)
                    {
                        resultLbl.Text = "Invalid date";
                        break;
                    }
                    else
                    {
                        resultLbl.Text = "valid date";
                    }
                        
                }
                num++;
            }

            endDateLbl.Text = endDate.ToShortDateString();
        }
    }
}