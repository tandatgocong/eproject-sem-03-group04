using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilitiesLayers;
public partial class WebAdmin_ViewLog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Binddata();             
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView1.PageIndex = e.NewPageIndex;
       // Binddata();   
    }
    public void Binddata()
    {
        this.GridView1.DataSource = Logging.ReadFileLog();
        this.DataBind();
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
    protected void btDate_Click(object sender, EventArgs e)
    {
        this.GridView1.DataSource = Logging.ReadFileLog(DateTime.Parse(this.txtDate.Text));
        this.DataBind();

    }
    protected void btUserName_Click(object sender, EventArgs e)
    {
        this.GridView1.DataSource = Logging.ReadFileLog(this.TextBox1.Text);
        this.DataBind();

    }
}
