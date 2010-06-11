using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CalendarControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Calendar.Visible = true;
    }

    protected void Calendar_SelectionChanged(object sender, EventArgs e)
    {
        txtDate.Text = this.Calendar.SelectedDate.ToShortDateString();
        Calendar.Visible = false;
    }
    public string Date
    {
        get { return txtDate.Text; }
        set { txtDate.Text = value; }
    }
}
