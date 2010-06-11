using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayers;
using UtilitiesLayers;
public partial class WebCustomer_CustomerMasterPage : System.Web.UI.MasterPage
{

    SystemsBL system = new SystemsBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthenticateEventArgs obj = new AuthenticateEventArgs(true);
        obj.Authenticated = true;
        this.Label1.Text = DateTime.Now.ToLongDateString();
        if (!IsPostBack)
        {
            try
            {
                if (Request.Cookies["user"]["username"].ToString() != null)
                {
                    Login tmp = (Login)LoginView1.FindControl("Login1");
                    TextBox username = (TextBox)tmp.FindControl("Username");
                    TextBox password = (TextBox)tmp.FindControl("Password");
                    username.Text = Request.Cookies["user"]["username"].ToString();
                    password.Attributes["Value"] = Request.Cookies["user"]["password"].ToString();
                }
            }
            catch (Exception)
            {


            }
        }
    }
    public void savepass()
    {
        Login tmp = (Login)LoginView1.FindControl("Login1");
        TextBox username = (TextBox)tmp.FindControl("Username");
        TextBox password = (TextBox)tmp.FindControl("Password");
        CheckBox RememberMe = (CheckBox)tmp.FindControl("RememberMe");
        if (RememberMe.Checked)
            {
                Response.Cookies["user"]["username"] = username.Text;
                Response.Cookies["user"]["password"] = password.Text;
                Response.Cookies["user"].Expires = DateTime.Now.AddMinutes(20);

            }
       
            
    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        
       
    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        
        Login tmp = (Login)LoginView1.FindControl("Login1");
        TextBox username = (TextBox)tmp.FindControl("Username");
        TextBox password = (TextBox)tmp.FindControl("Password");

        if (system.WebLogin(username.Text, password.Text).Trim().Equals("CUS"))
        {
            Session["UserLogin"] = username.Text;
            savepass();
            e.Authenticated = true;
            
            

        }
        else if (system.WebLogin(username.Text, password.Text).Trim().Equals("ADM"))
        {
            Session["UserLogin"] = username.Text;
            savepass();
            e.Authenticated = true;
            Response.Redirect("~/WebAdmin/Default.aspx");

        }
        else if (system.WebLogin(username.Text, password.Text).Trim().Equals("EPL"))
        {
            Session["UserLogin"] = username.Text;
            savepass();
            e.Authenticated = true;
            Response.Redirect("~/WebEmployee/Default.aspx");
        }
        else if (system.WebLogin(username.Text, password.Text).Trim().Equals("HEO"))
        {
            Response.Redirect("~/WebCustomer/CustomerLogin.aspx");
        }
    }
    protected void Login2_Authenticate(object sender, AuthenticateEventArgs e)
    {
        e.Authenticated = true;
    }
}
