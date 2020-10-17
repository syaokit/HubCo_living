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
    public partial class custEventPage1 : System.Web.UI.Page
    {
        List<DateTime> eventDateList = new List<DateTime>();
        protected void Page_Load(object sender, EventArgs e)
        {

            

            //String customerID = Application["customerID"].ToString();
            String customerID = "10002";
            lblCreator2.Text = customerID;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|db.mdf;Integrated Security=True;");
            SqlCommand cmd = new SqlCommand("select * from events ", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DateTime eventDate = DateTime.Parse(reader["date"].ToString());

                    eventDateList.Add(eventDate);
                }
            }

            Session["eventDateList"] = eventDateList;
        }

        protected void calendar_SelectionChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|db.mdf;Integrated Security=True;");
            DateTime date = calendar.SelectedDate;
            SqlCommand cmd = new SqlCommand("select * from events where date = @date ", con);
            con.Open();
            cmd.Parameters.AddWithValue("@date", date);

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(ds);
            rpt1.DataSource = ds;
            rpt1.DataBind();

            con.Close();

            lblDate2.Text = date.ToShortDateString();

        }

        protected void calendar_DayRender(object sender, DayRenderEventArgs e)
        {
            List<DateTime> newList = (List<DateTime>)Session["eventDateList"];

            foreach (DateTime dt in newList)
            {
                if (e.Day.Date == dt)
                    e.Cell.BackColor = Color.LightGreen;
            }

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

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            String time = txtTime.Text;
            String customerID = lblCreator2.Text;
            String eventName = txtEventName.Text;
            String eventContent = txtContent.Text;
            DateTime date = DateTime.Parse(lblDate2.Text);


            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|db.mdf;Integrated Security=True;");  
            SqlCommand cmd = new SqlCommand("insert into events values (@creator, @eventName, @content, @date, @time) ", con);
            con.Open();
            cmd.Parameters.AddWithValue("@creator", customerID);
            cmd.Parameters.AddWithValue("@eventName", eventName);
            cmd.Parameters.AddWithValue("@content", eventContent);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@time", time);
            cmd.ExecuteNonQuery();

            Response.Write("<script language=javascript>alert('Event have been created...')</script>");

            txtTime.Text="";
            txtEventName.Text ="";
            txtContent.Text="";

            Page_Load(sender, e);
        }
    }
}