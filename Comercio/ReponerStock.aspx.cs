using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReponerStock : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((bool)Session["Logged"] && ((Usuario.TipoUsuario)Session["Type"] == Usuario.TipoUsuario.Admin ||
            (Usuario.TipoUsuario)Session["Type"] == Usuario.TipoUsuario.JefeDeDeposito))
        {
            if (!Page.IsPostBack)
            {
                cargarGridView();
            }

        }
        else
        {
            Response.Redirect("LogIn.aspx");
        }
    }
    protected void gvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "AgregarStock")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvProductos.Rows[index];
            TableCell celdaNombreProd = row.Cells[1];
            string textNombreProd = celdaNombreProd.Text;
            TextBox txtItemDescription = (TextBox)gvProductos.Rows[index].Cells[6].FindControl("txtCantidad");
            string textCantidad = txtItemDescription.Text;
            int auxCantidad;
            if (Int32.TryParse(textCantidad, out auxCantidad))
            {
                Comercio.Instancia.agregarStock(textNombreProd, auxCantidad);
                this.Master.LblMensaje.Text = "Se agrego la cantidad " + textCantidad + " a producto: " + textNombreProd + ".";
                cargarGridView();
            }
        }
    }
    private void cargarGridView()
    {
        List<Producto> listaStockBajo = Comercio.Instancia.traerProductosStockBajo();
        this.gvProductos.DataSource = listaStockBajo;
        this.gvProductos.DataBind();
    }
    protected void btnVaciarTodo_Click(object sender, EventArgs e)
    {
        List<Usuario> todos = Comercio.Instancia.traerUsuarios();
        foreach (Usuario unUsu in todos)
        {
            foreach (Producto unProd in unUsu.Carrito)
            {
                unProd.Stock++;

            }
            unUsu.Carrito.Clear();
            this.Master.LblMensaje.Text = "Se vaciaron todos los carritos";
        }
    }
}
