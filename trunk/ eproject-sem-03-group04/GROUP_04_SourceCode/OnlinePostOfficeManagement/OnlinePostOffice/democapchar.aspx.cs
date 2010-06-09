using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class democapchar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        CaptchaControl1.ValidateCaptcha(TextBox1.Text);
        if (!CaptchaControl1.UserValidated)
        {
            lblCodeResult.Text = "Invalid code";
            return;
        }
        else
        {
            lblCodeResult.Text = "GFDSGFDSFGFD";
        }

    }
}