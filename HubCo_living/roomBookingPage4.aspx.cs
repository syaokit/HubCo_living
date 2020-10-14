using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HubCo_living
{
    public partial class roomBookingPage4 : System.Web.UI.Page
    {
        List<DateTime> list = new List<DateTime>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void calendar_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsSelected == true)
            {
                list.Add(e.Day.Date);
            }


            Session["SelectedDates"] = list;

            foreach (DateTime dt in list)
            {
                dateLbl.Text = dt.ToShortDateString()+"<br/>";
            }
                
        }


        protected void calendar_SelectionChanged(object sender, EventArgs e)
        {
            DateTime select = calendar.SelectedDate;
             
            if (Session["SelectedDates"] != null)
            {
                List<DateTime> newList = (List<DateTime>)Session["SelectedDates"];
                foreach (DateTime dt in newList)
                {
                    if (select.CompareTo(dt) == 0)
                    {
                        calendar.SelectedDates.Remove(select);
                    }
                    else
                    {
                        calendar.SelectedDates.Add(dt);
                    }
                    
                }
                list.Clear();
            }
        }
    }
}