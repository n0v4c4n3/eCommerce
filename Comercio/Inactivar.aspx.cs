using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Inactivar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((bool)Session["Logged"])
        {

        }
        else
        {
            Response.Redirect("LogIn.aspx");
        }
    }
    protected void btnInactivar_Click(object sender, EventArgs e)
    {
        Usuario usuarioActivo = Comercio.Instancia.buscarUsuarioXUser(Session["User"].ToString());
        if (usuarioActivo.Tipo != Usuario.TipoUsuario.Admin)
        {
            usuarioActivo.Inactivo = true;
            this.Master.LblMensaje.Text = "Te has inactivado. Cerrando sesion...";
            Response.AddHeader("Refresh", "3; URL=LogIn.aspx");
            Session.Abandon();
            Application.Lock();
            Application["Loggeds"] = (int)Application["Loggeds"] - 1;
            Application.UnLock();
        }
        else
        {
            this.Master.LblMensaje.Text = "Dado que eres un usuario del tipo admin. No te puedes inactivar.";
        }
    }
}