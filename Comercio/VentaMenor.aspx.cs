using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VentaMenor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((bool)Session["Logged"] && ((Usuario.TipoUsuario)Session["Type"] == Usuario.TipoUsuario.Admin ||
            (Usuario.TipoUsuario)Session["Type"] == Usuario.TipoUsuario.Gerente))
        {

        }
        else
        {
            Response.Redirect("LogIn.aspx");
        }
    }
    protected void btnCalcular_Click(object sender, EventArgs e)
    {
        string fechaInicial = this.txtFechaInicial.Text;
        string fechaTope = this.txtFechaTope.Text;
        string TopeGanancias = this.txtTopeGanancias.Text;
        // Convierto a Decimal.
        Decimal auxDecimalMontoTope = new Decimal();
        if (Decimal.TryParse(TopeGanancias, out auxDecimalMontoTope)) 
        { 
        }
        else
        {
            this.Master.LblMensaje.Text = "Ingrese un monto tope.";
        }
        List<Pedido> auxPedidos = Comercio.Instancia.traerPedidos();
        List<Pedido> auxPedidosFiltrados = new List<Pedido>();        
        DateTime auxFechaInicial;
        DateTime auxFechaTope;
        // Obtener los pedidos en las fechas dadas.
        if (DateTime.TryParse(fechaInicial, out auxFechaInicial))
        {
            if (DateTime.TryParse(fechaTope, out auxFechaTope))
            {
                if (auxFechaInicial < auxFechaTope)
                {
                    foreach (Pedido unPedido in auxPedidos)
                    {
                        DateTime auxDate = Convert.ToDateTime(unPedido.Fecha);
                        if (auxDate >= auxFechaInicial && auxDate <= auxFechaTope && unPedido.Cancelado == false && unPedido.Estado == true) // Entre las fechas, no cancelado y enviado.
                        {
                            auxPedidosFiltrados.Add(unPedido);
                        }
                    }
                }
            }
            else
            {
                this.Master.LblMensaje.Text = "Fecha tope invalida.";
            }
        }
        else
        {
            this.Master.LblMensaje.Text = "Fecha inicial invalida.";
        }        
        // Obtener todos los productos de esos pedidos filtrados
        List<Producto> auxProductosFiltrados = new List<Producto>();
        foreach (Pedido unPedidoFiltrado in auxPedidosFiltrados)
        {
            foreach (Producto unProducto in unPedidoFiltrado.ColProductos)
            {
                auxProductosFiltrados.Add(unProducto);
            }
        }
        // Sumo ganancias por cada producto.
        foreach (Producto unProd2 in auxProductosFiltrados)
        {
            unProd2.Ganancias = unProd2.Ganancias + unProd2.Precio;
        }
        List<Producto> SinDuplicados = auxProductosFiltrados.Distinct().ToList();
        List<Producto> enOrden = SinDuplicados.OrderBy(algo => algo.Ganancias).ToList();
        // Ahora le pongo un tope de ganancias.
        List<Producto> enOrdenConTopeDeMonto = new List<Producto>();
        foreach (Producto unProd4 in enOrden)
        {
            if (unProd4.Ganancias <= auxDecimalMontoTope) 
            {
                enOrdenConTopeDeMonto.Add(unProd4);
            }        
        }
        // Bindear.
        this.gvProductos.DataSource = enOrdenConTopeDeMonto;
        this.gvProductos.DataBind();
        // Limpiar.
        foreach (Producto unProd3 in enOrden)
        {
            unProd3.Ganancias = new Decimal();
        }
    }
}