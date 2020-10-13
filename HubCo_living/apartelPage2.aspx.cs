using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HubCo_living
{
    public partial class apartelPage2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RepeaterData();
            }

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

                string address = Convert.ToString(ds.Tables[0].Rows[0]["address"]);
                string unitNumber = Convert.ToString(ds.Tables[0].Rows[0]["unitNumber"]);
                string postcode = Convert.ToString(ds.Tables[0].Rows[0]["postcode"]);
                string city = Convert.ToString(ds.Tables[0].Rows[0]["city"]);
                string state = Convert.ToString(ds.Tables[0].Rows[0]["state"]);
                string status = Convert.ToString(ds.Tables[0].Rows[0]["status"]);


                unitNumberLbl.Text = unitNumber;
                postcodeLbl.Text = postcode;
                cityLbl.Text = city;
                stateLbl.Text = state;
                addressLbl.Text = address;
                statusLbl.Text = status;


            }
            catch (Exception ex)
            {
                Response.Write("<script language=javascript>alert('An error occured when loading room data.')</script>");
            }


        }

      

    }
}