using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayers;
using BusinessLayers;
using DataModelLayers;
public partial class _Default : System.Web.UI.Page 
{
    BrancheBL branche = new BrancheBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        Binddata();
    }
    public void Binddata()
    {
        this.GridView1.DataSource = branche.getListBranches();
        this.GridView1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        BrancheInfo info  = new BrancheInfo("",this.TextBox1.Text, this.TextBox2.Text,this.TextBox3.Text);
        branche.InsertBranche(info);
        Binddata();
    }
}
