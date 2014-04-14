using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DesbanearUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((bool)Session["Logged"] && (Usuario.TipoUsuario)Session["Type"] == Usuario.TipoUsuario.Admin)
        {
            if (!this.IsPostBack)
            {
                cargarUsuariosBaneados();
            }
        }
        else
        {
            Response.Redirect("LogIn.aspx");
        }
    }

    protected void btnDesbanear_Click(object sender, EventArgs e)
    {
        Usuario auxUsuario = Comercio.Instancia.buscarUsuarioXUser(this.rblUsuariosBaneados.SelectedValue);
        if (auxUsuario != null && auxUsuario.Tipo != Usuario.TipoUsuario.Admin)
        {
            if (auxUsuario.Ban == true)
            {
                auxUsuario.Ban = false;
                this.Master.LblMensaje.Text = "El usuario: " + auxUsuario.User + " ha sido desbaneado.";
            }
            else
            {
                this.Master.LblMensaje.Text = "Ese usario no esta baneado.";
            }
        }
        else
        {
            this.Master.LblMensaje.Text = "No puedes banear a un usuario del tipo 'Admin' o a un usuario inexistente.";
        }
    }
    private void cargarUsuariosBaneados()
    {
        List<Usuario> usuariosBaneados = new List<Usuario>();
        foreach (Usuario unUsu in Comercio.Instancia.traerUsuarios())
        {
            if (unUsu.Ban == true)
            {
                usuariosBaneados.Add(unUsu);
            }
        }
        this.rblUsuariosBaneados.DataValueField = "User";
        this.rblUsuariosBaneados.DataTextField = "User";
        this.rblUsuariosBaneados.DataSource = usuariosBaneados;
        this.rblUsuariosBaneados.DataBind();
    }
}