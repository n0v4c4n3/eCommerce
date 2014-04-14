using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListaDeUsuarios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((bool)Session["Logged"] && ((Usuario.TipoUsuario)Session["Type"] == Usuario.TipoUsuario.Admin ||
            (Usuario.TipoUsuario)Session["Type"] == Usuario.TipoUsuario.Gerente))
        {
            cargarLista();            
        }
        else
        {
            Response.Redirect("LogIn.aspx");
        }
    }
    protected void btnActivar_Click(object sender, EventArgs e)
    {
        string textUsuarioActivar = this.txtActivar.Text;
        if (textUsuarioActivar != "")
        {
            Usuario usuarioActivar = Comercio.Instancia.buscarUsuarioXUser(textUsuarioActivar);
            if (usuarioActivar != null)
            {
                if (usuarioActivar.Tipo != Usuario.TipoUsuario.Admin)
                {
                    if (usuarioActivar.Inactivo == true)
                    {
                        usuarioActivar.Inactivo = false;
                        this.Master.LblMensaje.Text = "Usuario: " + usuarioActivar.User + " fue activado.";
                        cargarLista();
                    }
                    else
                    {
                        this.Master.LblMensaje.Text = "Usuario: " + usuarioActivar.User + " ya fue activado anteriormente.";
                    }
                }
                else
                {
                    this.Master.LblMensaje.Text = "No puedes interferir con un user del tipo admin.";
                }
            }
            else
            {
                this.Master.LblMensaje.Text = "No existe ese nombre de usuario.";
            }
        }
        else
        {
            this.Master.LblMensaje.Text = "El campo no puede estar vacio.";
        }
    }
    protected void btnInactivar_Click(object sender, EventArgs e)
    {
        string textUsuarioInactivar = this.txtInactivar.Text;
        if (textUsuarioInactivar != "")
        {
            Usuario usuarioInactivar = Comercio.Instancia.buscarUsuarioXUser(textUsuarioInactivar);
            if (usuarioInactivar != null)
            {
                if (usuarioInactivar.Tipo != Usuario.TipoUsuario.Admin)
                {
                    if (usuarioInactivar.Inactivo == false)
                    {
                        usuarioInactivar.Inactivo = true;
                        this.Master.LblMensaje.Text = "Usuario: " + usuarioInactivar.User + " fue inactivado.";
                        cargarLista();
                    }
                    else
                    {
                        this.Master.LblMensaje.Text = "Usuario: " + usuarioInactivar.User + " ya fue inactivado anteriormente.";
                    }
                }
                else
                {
                    this.Master.LblMensaje.Text = "No puedes interferir con un user del tipo admin.";
                }
            }
            else
            {
                this.Master.LblMensaje.Text = "No existe ese nombre de usuario.";
            }
        }
        else
        {
            this.Master.LblMensaje.Text = "El campo no puede estar vacio.";
        }
    }
    private void cargarLista()
    {
        List<Usuario> lista = Comercio.Instancia.traerUsuarios();
        this.GridView1.DataSource = lista;
        this.GridView1.DataBind();
    }
    protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
    {
        string txtEstado = ddlEstado.SelectedItem.Text;
        List<Usuario> toBind = Comercio.Instancia.traerUsuariosXEstado(txtEstado);
        this.GridView1.DataSource = toBind;
        this.GridView1.DataBind();
    }
}