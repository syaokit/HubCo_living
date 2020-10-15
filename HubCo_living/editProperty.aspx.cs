using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;

namespace HubCo_living
{
    public partial class EditProperty1 : System.Web.UI.Page
    {
        private int roomID = 0;
        private String imageID;
        private int countPic;


        protected void Page_Load(object sender, EventArgs e)
        {
            countPic = 0;
            if (!IsPostBack)
            {
                try
                {
                    roomID = int.Parse(Application["roomID"].ToString());
                    lblRoomId.Text = Application["roomID"].ToString();
                }
                catch (Exception ex)
                {
                    Response.Write("<script language=javascript>alert('Please select a property!')</script>");
                    Response.Redirect("AllPropertyAdmin.aspx");
                }


                // Get room details
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cheem\source\repos\syaokit_new\HubCo_living\HubCo_living\App_Data\db.mdf;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("select * from Rooms where roomID=@roomID ", con);
                con.Open();
                cmd.Parameters.AddWithValue("@roomID", roomID);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        txtAddress.Text = reader["address"].ToString();
                        txtCity.Text = reader["city"].ToString();
                        txtPostcode.Text = reader["postcode"].ToString();
                        txtNumber.Text = reader["unitNumber"].ToString();
                        ddlState.SelectedValue = reader["state"].ToString();
                        ddlType.SelectedValue = reader["roomType"].ToString();
                        priceTxt.Text = reader["price"].ToString();
                        bedDDL.SelectedValue = reader["bed"].ToString();
                        ddlBed.SelectedValue = reader["bedQty"].ToString();
                        ddlBath.SelectedValue = reader["bathroomQty"].ToString();

                        if (reader["status"].ToString() == "Available")
                            RadioButton1.Checked = true;
                        else
                            RadioButton2.Checked = true;

                        if (reader["bathroom"].ToString() == "Private")
                            bathroomRB1.Checked = true;
                        else
                            bathroomRB2.Checked = true;


                        if (reader["bathtub"].ToString() == "Yes")
                            bathtubRB1.Checked = true;
                        else
                            bathtubRB2.Checked = true;


                        if (reader["tv"].ToString() == "Yes")
                            tvRB1.Checked = true;
                        else
                            tvRB2.Checked = true;


                        if (reader["balcony"].ToString() == "Yes")
                            balconyRB1.Checked = true;
                        else
                            balconyRB2.Checked = true;



                        con.Close();
                    }

                    // Get room pictures
                    ImageRepeaterData();
                }
                else
                {
                    con.Close();
                    Response.Write("<script language=javascript>alert('Property does not exist!')</script>");
                    Response.Redirect("AllPropertyAdmin.aspx");
                }
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            String unitType = ddlType.SelectedValue;
            String address = txtAddress.Text;
            String unitNo = txtNumber.Text;
            String postcode = txtPostcode.Text;
            String city = txtCity.Text;
            String state = ddlState.SelectedValue;
            String bed = bedDDL.SelectedValue;
            int bathroomQty = int.Parse(ddlBath.SelectedValue);
            int bedQty = int.Parse(ddlBed.Text);
            double price = double.Parse(priceTxt.Text);

                try
                {
                    //Make sure all fields filled up
                    if (unitType.Length == 0 || address.Length == 0 || unitNo.Length == 0 || postcode.Length == 0 || city.Length == 0 || state.Equals("0"))
                    {
                        Response.Write("<script language=javascript>alert('Please fill in all fields.')</script>");
                    }
                    else
                    {
                        // Verify post code length and type
                        if (postcode.Length < 5)
                        {
                            Response.Write("<script language=javascript>alert('Invalid postal code.')</script>");
                        }
                        else
                        {
                            //Check if postal code is only numbers
                            if (IsDigit(postcode))
                            {
                                try
                                {
                                    int postnumber = int.Parse(postcode);

                                    //Check whether postal code within range
                                    if (postnumber < 1000 || postnumber > 87033)
                                    {
                                        Response.Write("<script language=javascript>alert('This post code does not exist.')</script>");
                                    }
                                    else
                                    {
                                        //Check whether city is in alphabets only
                                        if (IsLetter(city))
                                        {
                                            try
                                            {
                                                // Update property data
                                                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cheem\source\repos\syaokit_new\HubCo_living\HubCo_living\App_Data\db.mdf;Integrated Security=True");
                                                SqlCommand cmd = new SqlCommand("update Rooms set roomType=@roomType, address=@address, unitNumber=@unitNumber, status=@status, postcode=@postcode, city=@city, state=@state, price=@price," +
                                                                                 "bathroom=@bathroom, bathroomQty=@bathroomQty, bed=@bed, bedQty=@bedQty, bathtub=@bathtub , tv=@tv, balcony=@balcony where roomID=@roomID", con);
                                                con.Open();
                                                cmd.Parameters.AddWithValue("@roomType", unitType);
                                                cmd.Parameters.AddWithValue("@address", address);
                                                cmd.Parameters.AddWithValue("@unitNumber", unitNo);
                                                cmd.Parameters.AddWithValue("@postcode", postcode);
                                                cmd.Parameters.AddWithValue("@city", city);
                                                cmd.Parameters.AddWithValue("@state", state);
                                                cmd.Parameters.AddWithValue("@price", price);
                                                cmd.Parameters.AddWithValue("@bed", bed);
                                                cmd.Parameters.AddWithValue("@bathroomQty", bathroomQty);
                                                cmd.Parameters.AddWithValue("@bedQty", bedQty);

                                                if (RadioButton1.Checked)
                                                    cmd.Parameters.AddWithValue("@status", RadioButton1.Text);
                                                else
                                                    cmd.Parameters.AddWithValue("@status", RadioButton2.Text);

                                                if (bathroomRB1.Checked)
                                                    cmd.Parameters.AddWithValue("@bathroom", bathroomRB1.Text);
                                                else
                                                    cmd.Parameters.AddWithValue("@bathroom", bathroomRB2.Text);

                                                if (bathtubRB1.Checked)
                                                    cmd.Parameters.AddWithValue("@bathtub", bathtubRB1.Text);
                                                else
                                                    cmd.Parameters.AddWithValue("@bathtub", bathtubRB2.Text);

                                                if (tvRB1.Checked)
                                                    cmd.Parameters.AddWithValue("@tv", tvRB1.Text);
                                                else
                                                    cmd.Parameters.AddWithValue("@tv", tvRB2.Text);

                                                if (balconyRB1.Checked)
                                                    cmd.Parameters.AddWithValue("@balcony", balconyRB1.Text);
                                                else
                                                    cmd.Parameters.AddWithValue("@balcony", balconyRB2.Text);

                                                cmd.Parameters.AddWithValue("@roomID", lblRoomId.Text);

                                                cmd.ExecuteNonQuery();
                                                con.Close();

                                                Response.Write("<script language=javascript>alert('Room Updated!')</script>");
                                                //Response.Redirect("AllPropertyAdmin.aspx");


                                            }
                                            catch (Exception ex)
                                            {
                                                Response.Write("<script language=javascript>alert('An error occured.')</script>");
                                            }

                                        }
                                        else
                                        {
                                            Response.Write("<script language=javascript>alert('Input for city have to be in alphabets only.')</script>");
                                        }

                                    }
                                }
                                catch (Exception ex)
                                {
                                    Response.Write("<script language=javascript>alert('Oops something went wrong.')</script>");
                                }

                            }
                            else
                            {
                                Response.Write("<script language=javascript>alert('Post code can only contain numbers.')</script>");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script language=javascript>alert('An error occured!')</script>");

                }

           

           
           
        }

        protected string GetImage(object img)
        {
            //imageSlider();
            countPic++;
            lblPicNum.Text = countPic.ToString();
            return "data:image/jpg;base64, " + Convert.ToBase64String((byte[])img);
        }

        // To Bind Photo to Repeater
        private void ImageRepeaterData()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cheem\source\repos\syaokit_new\HubCo_living\HubCo_living\App_Data\db.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd1 = new SqlCommand("select imageID, imageContent from PropertyImages where roomID=@roomID", con);
            cmd1.Parameters.AddWithValue("@roomID", lblRoomId.Text);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            da.Fill(ds);
            imgRepeater.DataSource = ds;
            imgRepeater.DataBind();
            con.Close();
        }


        // For delete image
        protected void Image_Select(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "ImageSelect")
            {

                if (int.Parse(lblPicNum.Text) <= 4)
                {
                    Response.Write("<script language=javascript>alert('There must be at least 4 photos!')</script>");
                }
                else
                {
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cheem\source\repos\syaokit_new\HubCo_living\HubCo_living\App_Data\db.mdf;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("delete from propertyImages where imageID=@imageID", con);
                    cmd1.Parameters.AddWithValue("@imageID", e.CommandArgument.ToString());
                    cmd1.ExecuteNonQuery();
                    con.Close();
                    lblPicNum.Text = (int.Parse(lblPicNum.Text) - 1).ToString();
                    ImageRepeaterData();
                }

            }
        }


        protected bool verifyFileType()
        {
            bool filetype = true;

            foreach (HttpPostedFile postedFile in filUpPictures.PostedFiles)
            {
                String type = postedFile.ContentType;

                if (type != "image/jpeg" && type != "image/jpg" && type != "image/png")
                {
                    filetype = false;
                    break;
                }
            }

            return filetype;
        }




        protected void btnAddPhoto_Click(object sender, EventArgs e)
        {

            if (filUpPictures.HasFile == true)
            {
                if (verifyFileType())
                {
                    foreach (HttpPostedFile postedFile in filUpPictures.PostedFiles)
                    {
                        String fileName = Path.GetFileName(postedFile.FileName);
                        String type = postedFile.ContentType;

                        using (Stream stream = postedFile.InputStream)
                        {
                            using (BinaryReader br = new BinaryReader(stream))
                            {
                                byte[] bytes = br.ReadBytes((Int32)stream.Length);

                                using (SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cheem\source\repos\syaokit_new\HubCo_living\HubCo_living\App_Data\db.mdf;Integrated Security=True"))
                                {
                                    String query = "insert into PropertyImages values(@images, @roomID)";
                                    using (SqlCommand cmdInImg = new SqlCommand(query))
                                    {
                                        cmdInImg.Connection = con1;
                                        cmdInImg.Parameters.AddWithValue("@images", bytes);
                                        cmdInImg.Parameters.AddWithValue("@roomID", lblRoomId.Text);
                                        con1.Open();
                                        cmdInImg.ExecuteNonQuery();
                                        con1.Close();

                                    }
                                }
                            }
                        }
                    }
                    ImageRepeaterData();
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Have to be .jpeg, .jpg, .png files.')</script>");
                }
            }
            else
            {
                Response.Write("<script language=javascript>alert('Please upload at least one picture.')</script>");

            }


        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllPropertyAdmin.aspx");
        }

        private bool IsDigit(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }

        private bool IsLetter(string str)
        {
            Regex r = new Regex("^[a-z A-Z]+$");

            if (r.IsMatch(str))
                return true;

            else
                return false;
        }
    }
}