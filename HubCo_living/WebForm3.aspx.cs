using System;

namespace HubCo_living
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            Label1.Text = TextBox1.Text;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Show();
        }
    }
}