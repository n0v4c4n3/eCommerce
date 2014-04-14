using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ini : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((bool)Session["Logged"])
        {
            this.lblHello.Text = "Hola " + Session["User"].ToString() + ". Suerte en pila!";
        }
        else
        {
            Response.Redirect("LogIn.aspx");
        }
    }
}