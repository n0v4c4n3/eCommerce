using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Productos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarGridView();
        }
        if ((Usuario.TipoUsuario)Session["Type"] == Usuario.TipoUsuario.Visitante)
        {
            this.Master.LblMensaje.Text = "Acuerdate que necesitas registrarte para reservar productos en el carrito.";
            //Sino me podrian reservar productos todos los visitantes que entren!!!.
        }
    }
    protected void gvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "commandAgregar")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvProductos.Rows[index];
            TableCell celdaNombreProd = row.Cells[1];
            string textUser = Session["User"].ToString();
            string textNombreProd = celdaNombreProd.Text;
            bool aux = Comercio.Instancia.agregarAlCarrito(textUser, textNombreProd);
            if (aux == true)
            {
                this.Master.LblMensaje.Text = "Se agrego el producto: " + textNombreProd + " al carrito. Refrescando vista del carrito (en User info)...";
                cargarGridView();
                Response.AddHeader("Refresh", "3; URL=Productos.aspx");
            }
            else
            {
                this.Master.LblMensaje.Text = "No se pudo agregar el producto: " + textNombreProd + " al carrito.";
            }
        }
    }
    private void cargarGridView()
    {
        List<Producto> lista = Comercio.Instancia.traerProductos();
        this.gvProductos.DataSource = lista;
        this.gvProductos.DataBind();
    }
}