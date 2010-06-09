using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebAdmin_ManagetBranch : System.Web.UI.Page
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
}
