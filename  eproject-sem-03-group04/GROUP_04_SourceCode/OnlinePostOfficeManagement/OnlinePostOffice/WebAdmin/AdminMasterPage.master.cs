﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebAdmin_AdminMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Label1.Text = DateTime.Now.ToLongDateString();
        this.lblogin.Text = Session["UserLogin"].ToString();
    }
}
