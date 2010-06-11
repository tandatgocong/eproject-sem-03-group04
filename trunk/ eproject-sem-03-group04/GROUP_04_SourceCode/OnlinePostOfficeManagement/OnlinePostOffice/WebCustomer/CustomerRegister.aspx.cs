using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayers;
using DataModelLayers;
using UtilitiesLayers;
public partial class WebCustomer_CustomerRegister : System.Web.UI.Page
{
    SystemsBL system = new SystemsBL();
    CustomersBL cus = new CustomersBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.lbcheck.Visible = false;
        MaintainScrollPositionOnPostBack = true;
        this.Panel33.Visible = true;
        this.Panel34.Visible = false;
    }
   
    protected void btcheck_Click(object sender, EventArgs e)
    {
        if (system.CheckAvailabilityEmail(this.txtemail.Text) == true)
        {
            this.lbcheck.Text = this.txtemail.Text + " is available";
            this.lbcheck.ForeColor = System.Drawing.Color.Blue;
            this.lbcheck.Visible = true;           
        }
        else if (system.CheckAvailabilityEmail(this.txtemail.Text) == false)
        {
            this.lbcheck.Text = this.txtemail.Text + " is not available";
            this.lbcheck.ForeColor = System.Drawing.Color.Red;
            this.lbcheck.Visible = true;
           
        }

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Captcha.ValidateCaptcha(txtcode.Text);
        if (system.CheckAvailabilityEmail(this.txtemail.Text) == true)
        {
            if (!Captcha.UserValidated)
            {
                lblCodeResult.Text = "Invalid code";
                return;
            }
            else
            {
                bool sex = false;
                if(rbfemale.Checked == true)
                    sex = true;
                if(rbMale.Checked == true)
                    sex= false;
                CustomerInfo info = new CustomerInfo("1", this.txtemail.Text, this.txtpass.Text, this.txtfirstName.Text, this.txtlastname.Text, DateTime.Parse(CalendarControl2.Date.ToString()), sex, this.txtaddress.Text, this.txtPhone.Text);
                if (cus.InsertCustomers(info) == true)
                {
                    Logging.WriteString(this.txtemail.Text, "Customer Register Successful.");
                    //MessageBox.Show(this, "You are create new account successfully, please login to use our services");
                    this.Panel33.Visible = false;
                    this.Panel34.Visible = true;
                   
                }
                else
                {
                    Logging.WriteString(this.txtemail.Text, "Customer Register Fail.");
                    MessageBox.Show(this, "Register Fail.");
                    return;
                }
               
            }
        }
        else
        {
            this.lbcheck.Text = this.txtemail.Text + " is not available";
            this.lbcheck.ForeColor = System.Drawing.Color.Red;
            this.lbcheck.Visible = true;          
        }
    }
    protected void btnSubmit0_Click(object sender, EventArgs e)
    {
        this.txtemail.Text = null;
        this.txtpass.Text = null;
        this.txtfirstName.Text = null;
        this.txtlastname.Text = null;
        this.CalendarControl2.Date = null;
        this.rbMale.Checked = true;
        this.txtaddress.Text = null;
        this.txtPhone.Text = null;
        this.txtemail.Focus();
    }
}
