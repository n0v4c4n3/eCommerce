using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AltaCategoria : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((bool)Session["Logged"] && (Usuario.TipoUsuario)Session["Type"] == Usuario.TipoUsuario.Admin)
        {
        }
        else
        {
            Response.Redirect("LogIn.aspx");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            Categoria.ErroresCategoria resultAltaCategoria = Comercio.Instancia.altaCategoria(this.txtNombreCat.Text);
            if (resultAltaCategoria == Categoria.ErroresCategoria.OK)
            {
                this.Master.LblMensaje.Text = "Alta de categoria exitosa!";
            }
            if (resultAltaCategoria == Categoria.ErroresCategoria.Nombre_de_categoria_ya_existente)
            {
                this.Master.LblMensaje.Text = "Ese nombre de categoria ya esta registrado!";
            }
        }
    }
}