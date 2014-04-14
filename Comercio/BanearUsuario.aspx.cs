using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BanearUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((bool)Session["Logged"] && (Usuario.TipoUsuario)Session["Type"] == Usuario.TipoUsuario.Admin)
        {
            if (!this.IsPostBack)
            {

            }
        }
        else
        {
            Response.Redirect("LogIn.aspx");
        }
    }

    protected void btnBanear_Click(object sender, EventArgs e)
    {
        Usuario auxUsuario = Comercio.Instancia.buscarUsuarioXUser(this.txtUsuarioABanear.Text);
        if (auxUsuario != null && auxUsuario.Tipo != Usuario.TipoUsuario.Admin)
        {
            if (auxUsuario.Ban == false)
            {
                auxUsuario.Ban = true;
                this.Master.LblMensaje.Text = "El usuario: " + auxUsuario.User + " ha sido baneado.";
            }
            else 
            {
                this.Master.LblMensaje.Text = "Ese usario ya ha sido baneado anteriormente.";
            }
        }
        else
        {
            this.Master.LblMensaje.Text = "No puedes banear a un usuario del tipo 'Admin' o a un usuario inexistente.";

        }
    }
}