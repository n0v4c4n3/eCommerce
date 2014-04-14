using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LogOut : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((bool)Session["Logged"])
        {
            this.lblDesconectado.Text = "Desconectando... " + Session["User"].ToString() + ". Gracias por su preferencia!";
            Response.AddHeader("Refresh", "3; URL=LogIn.aspx");
            Session.Abandon();
            Application.Lock();
            Application["Loggeds"] = (int)Application["Loggeds"] - 1;
            Application.UnLock();
        }
        else
        {
            Response.Redirect("LogIn.aspx");
        }
    }
}