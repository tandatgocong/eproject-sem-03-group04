using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page 
{
    DataAccessLayers.BranchDAL branch = new DataAccessLayers.BranchDAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        Binddata();
    }
    public void Binddata()
    {
        this.GridView1.DataSource = branch.getListBranches();
        this.GridView1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataModelLayers.BranchInfo info = new DataModelLayers.BranchInfo("001",this.TextBox1.Text,this.TextBox2.Text,this.TextBox3.Text);
        branch.InsertBranche(info);
        UtilitiesLayers.MessageBox.Show(this,"thanhcong");
        Binddata();
    }
}
