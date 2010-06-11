using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataModelLayers;
using BusinessLayers;
using UtilitiesLayers;

public partial class WebAdmin_ManagetBranch : System.Web.UI.Page
{
    BranchBL branch = new BranchBL();
    OfficeBL office = new OfficeBL();
    protected void Page_Load(object sender, EventArgs e)
    {
       // Response.Write(Logging.ReadFileLog().ToString());
        if (!IsPostBack)
        {
            this.panelSearch.Visible = true;
            this.PanelAdvanced.Visible = false;
            Binddata();
        }
        
        MaintainScrollPositionOnPostBack = true;
        
    }
    public void Binddata()
    {
        this.GridView1.DataSource = branch.getListBranches();
        this.GridView1.DataBind();
        try
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                Label ID = (Label)row.FindControl("Label2");
                CheckBox check = (CheckBox)row.FindControl("checkItems");
                if (office.BranchExist(ID.Text) > 0)
                {
                    check.Enabled = false;
                }

            }
        }
        catch (Exception)
        {
            
          
        }
       
        
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        Binddata();
    }
    protected void btsearch_Click(object sender, EventArgs e)
    {
        this.GridView1.DataSource = branch.searchBranches(this.txtname.Text.Trim());
        this.GridView1.DataBind();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        this.panelSearch.Visible = false;
        this.PanelAdvanced.Visible = true;
    }
    protected void btAdvancedSearch_Click(object sender, EventArgs e)
    {
        this.GridView1.DataSource = branch.AdvancedSearch(this.txtbranchName.Text.Trim(), this.txtbranchAddress.Text.Trim(), this.txtbranchPhone.Text.Trim());
        this.GridView1.DataBind();
    }
    protected void Add_Click(object sender, EventArgs e)
    {
        BranchInfo info = new BranchInfo("1", this.txtbranchNameAdd.Text, this.txtbranchAddressAdd.Text, this.txtbranchPhoneAdd.Text);
        if (branch.InsertBranche(info) == true)
        {
            Logging.WriteString(Session["UserLogin"].ToString(), "Add Information of Brarch Successful.");
            Binddata();
            this.panelSearch.Visible = true;
            this.PanelAdvanced.Visible = false;
            this.txtbranchPhoneAdd.Text = null;
            this.txtbranchNameAdd.Text = null;
            this.txtbranchAddressAdd.Text = null;
        }
        else
        {
            Logging.WriteString(Session["UserLogin"].ToString(), "Add Information of Brarch Fail.");
            MessageBox.Show(this,"Insert Fail.");
        }
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        Binddata();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        Binddata();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Label branchPin = (Label)GridView1.Rows[GridView1.EditIndex].FindControl("lbranchPin");
        TextBox branchName = (TextBox)GridView1.Rows[GridView1.EditIndex].FindControl("textbranchName");
        TextBox branchAddress = (TextBox)GridView1.Rows[GridView1.EditIndex].FindControl("txtbranchAddress");
        TextBox branchPhone = (TextBox)GridView1.Rows[GridView1.EditIndex].FindControl("txtbranchPhone");

        BranchInfo info = new BranchInfo(branchPin.Text, branchName.Text, branchAddress.Text, branchPhone.Text);
        if (branch.UpdateBranche(info))
        {
            Logging.WriteString(Session["UserLogin"].ToString(), "Modify Information of Brarch Successful.");
         }
        else
        {
            Logging.WriteString(Session["UserLogin"].ToString(), "Modify Information of Brarch Fail.");
            MessageBox.Show(this, "Modify Fail.");
        }
        GridView1.EditIndex = -1;
        Binddata();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label branchPin = (Label)GridView1.Rows[e.RowIndex].FindControl("Label2");
        BranchInfo tmp = branch.getBrancheInfo(branchPin.Text);
        if (branch.DeleteBranche(tmp.BranchPin))
        {
            Logging.WriteString(Session["UserLogin"].ToString(), "Delete Information of Brarch Successful.");
        }
        else
        {
            Logging.WriteString(Session["UserLogin"].ToString(), "Delete Information of Brarch Fail.");
            MessageBox.Show(this, "Delete Fail.");
        }
        GridView1.EditIndex = -1;
        Binddata();
    }
    protected void CheckAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkAll = (CheckBox)GridView1.HeaderRow.FindControl("CheckAll");
        if (checkAll.Checked == true)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                Label ID = (Label)row.FindControl("Label2");              
                CheckBox check = (CheckBox)row.FindControl("checkItems");
                if (office.BranchExist(ID.Text) == 0)
                {
                    check.Checked = true;
                }
               
            }
        }
        else
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox check = (CheckBox)row.FindControl("checkItems");
                check.Checked = false;

            }
        }
    }
    protected void btDelete_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            CheckBox check = (CheckBox)row.FindControl("checkItems");
            if (check.Checked == true)
            {
                Label ID = (Label)row.FindControl("Label2");
                BranchInfo tmp = branch.getBrancheInfo(ID.Text);
                if (branch.DeleteBranche(tmp.BranchPin))
                {
                    Logging.WriteString(Session["UserLogin"].ToString(), "Delete Information of Brarch Successful.");
                }
                else
                {
                    Logging.WriteString(Session["UserLogin"].ToString(), "Delete Information of Brarch Fail.");                   
                }
               
            }
        }
        Binddata();
    }
}
