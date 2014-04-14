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
            List<Usuario> lista = Comercio.Instancia.traerUsuarios();
            this.GridView1.DataSource = lista;
            this.GridView1.DataBind();
        }
        else
        {
            Response.Redirect("LogIn.aspx");
        }
    }
}