using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RealizarPedido : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((bool)Session["Logged"] && ((Usuario.TipoUsuario)Session["Type"] != Usuario.TipoUsuario.Visitante))
        {
            string usuarioText = Session["User"].ToString();
            Usuario usuarioActivo = Comercio.Instancia.buscarUsuarioXUser(usuarioText);
            bool isEmpty = !usuarioActivo.Carrito.Any();
            if (isEmpty)
            {
                this.Master.LblMensaje.Text = "Tienes que haber agregado algo al carrito!. Redireccionando a productos...";
                Response.AddHeader("Refresh", "3; URL=Productos.aspx");
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    cargarGridView();
                    cargarDirecciones();
                }
            }
        }
        else
        {
            Response.Redirect("LogIn.aspx");
        }
    }
    protected void gvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "commandSacar")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvProductos.Rows[index];
            TableCell celdaNombreProd = row.Cells[1];
            string textUser = Session["User"].ToString();
            string textNombreProd = celdaNombreProd.Text;
            bool aux = Comercio.Instancia.sacarDelCarrito(textUser, textNombreProd);
            if (aux == true)
            {
                this.Master.LblMensaje.Text = "Se saco el producto: " + textNombreProd + " del carrito. Refrescando vista del carrito (en User info)...";
                cargarGridView();
                Response.AddHeader("Refresh", "3; URL=RealizarPedido.aspx");
            }
            else
            {
                this.Master.LblMensaje.Text = "No se pudo sacar el producto: " + textNombreProd + " del carrito.";
            }
        }
    }
    private void cargarGridView()
    {
        string usuarioText = Session["User"].ToString();
        Usuario usuarioActivo = Comercio.Instancia.buscarUsuarioXUser(usuarioText);
        Decimal montoTotal = 0;
        foreach (Producto unProd in usuarioActivo.Carrito)
        {
            montoTotal = montoTotal + unProd.Precio;
        }
        this.lblMontoTotal.Text = montoTotal.ToString();
        List<Producto> lista = usuarioActivo.Carrito;
        this.gvProductos.DataSource = lista;
        this.gvProductos.DataBind();
    }
    protected void btnConfirmar_Click(object sender, EventArgs e)
    {
        Usuario usuarioActivo = Comercio.Instancia.buscarUsuarioXUser(Session["User"].ToString());
        string monto = this.lblMontoTotal.Text;
        string auxTxtMonto = this.lblMontoTotal.Text;
        Decimal auxMonto;
        string direccionSelected = this.rblDirecciones.SelectedValue;
        if (usuarioActivo.Carrito.Count() >= 1)
        {
            if (direccionSelected != "")
            {
                if (Decimal.TryParse(monto, out auxMonto))
                {
                    List<Producto> auxiliar = new List<Producto>();
                    foreach (Producto unProd in usuarioActivo.Carrito)
                    {
                        auxiliar.Add(unProd);
                    }
                    int codigoDeEstePedido = Comercio.Instancia.altaPedido(false, auxiliar, DateTime.Now, direccionSelected, auxMonto);
                    Pedido estePedido = Comercio.Instancia.buscarPedidoXCodPedido(codigoDeEstePedido);
                    usuarioActivo.ColPedidos.Add(estePedido);
                    this.Master.LblMensaje.Text = "Se agrego el pedido a tu coleccion de pedidos con la fecha actual: " + DateTime.Now + ". Direccion de envio: " + direccionSelected + ". Te enviaremos el producto lo antes posible!";
                    usuarioActivo.Carrito.Clear();
                }
            }
            else
            {
                this.Master.LblMensaje.Text = "Selecciona una direccion a enviar el pedido.";
            }
        }
    }
    private void cargarDirecciones()
    {
        string usuarioText = Session["User"].ToString();
        Usuario activo = Comercio.Instancia.buscarUsuarioXUser(usuarioText);
        List<string> listaToBind = activo.DireccionEnvio;
        this.rblDirecciones.DataSource = listaToBind;
        this.rblDirecciones.DataBind();
    }
}