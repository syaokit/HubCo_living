using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
            String roomID = Application["roomID"].ToString();


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

                addressLbl.Text = Convert.ToString(ds.Tables[0].Rows[0]["address"]);
                unitNumberLbl.Text = Convert.ToString(ds.Tables[0].Rows[0]["unitNumber"]);
                postcodeLbl.Text = Convert.ToString(ds.Tables[0].Rows[0]["postcode"]);
                cityLbl.Text = Convert.ToString(ds.Tables[0].Rows[0]["city"]);
                stateLbl.Text = Convert.ToString(ds.Tables[0].Rows[0]["state"]);
                statusLbl.Text = Convert.ToString(ds.Tables[0].Rows[0]["status"]);
                priceLbl.Text = "RM" + String.Format("{0:0.00}", Convert.ToString(ds.Tables[0].Rows[0]["price"]));


                roomNameLbl.Text = Convert.ToString(ds.Tables[0].Rows[0]["roomName"]);
                roomSegmentLbl.Text = Convert.ToString(ds.Tables[0].Rows[0]["roomSegment"]);
                roomTypeLbl.Text = Convert.ToString(ds.Tables[0].Rows[0]["roomType"]);
                bathroomLbl.Text = Convert.ToString(ds.Tables[0].Rows[0]["bathroom"]) + " Quantity :" + Convert.ToString(ds.Tables[0].Rows[0]["bathroomQty"]);
                bedLbl.Text = Convert.ToString(ds.Tables[0].Rows[0]["bed"]) + " Quantity :" + Convert.ToString(ds.Tables[0].Rows[0]["bedQty"]);
                bathtubLbl.Text = Convert.ToString(ds.Tables[0].Rows[0]["bathtub"]);
                tvLbl.Text = Convert.ToString(ds.Tables[0].Rows[0]["tv"]);
                balconyLbl.Text = Convert.ToString(ds.Tables[0].Rows[0]["balcony"]);




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
            String roomId = Application["roomID"].ToString();


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
            DateTime endDate = startDate.AddDays(duration - 1);

            List<DateTime> newList = (List<DateTime>)Session["invalidDate"];

            int num = 1;
            for (int i = 0; i < duration; i++)
            {
                DateTime d = startDate.AddDays(num);
                foreach (DateTime dt in newList)
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