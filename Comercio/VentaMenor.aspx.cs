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
        string montoMinimo = this.txtMontoMinimo.Text;
        Decimal auxDecimalMontoMinimo = new Decimal();
        if (Decimal.TryParse(fechaTope, out auxDecimalMontoMinimo)) { }
        List<Pedido> auxPedidos = Comercio.Instancia.traerPedidos();
        List<Pedido> auxPedidosFiltrados = new List<Pedido>();
        //Decimal monto = new Decimal();
        DateTime auxFechaInicial;
        DateTime auxFechaTope;
        //Obtener los pedidos en las fechas
        if (DateTime.TryParse(fechaInicial, out auxFechaInicial))
        {
            if (DateTime.TryParse(fechaTope, out auxFechaTope))
            {
                if (auxFechaInicial < auxFechaTope)
                {
                    foreach (Pedido unPedido in auxPedidos)
                    {
                        DateTime auxDate = Convert.ToDateTime(unPedido.Fecha);
                        if (auxDate >= auxFechaInicial && auxDate <= auxFechaTope)
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
        //this.lblMonto.Text = monto.ToString();
        //Obtener todos los productos de esos pedidos filtrados
        List<Producto> auxProductosFiltrados = new List<Producto>();
        foreach(Pedido unPedidoFiltrado in auxPedidosFiltrados)
        {
            foreach (Producto unProducto in unPedidoFiltrado.ColProductos)
            {
                auxProductosFiltrados.Add(unProducto);
            }        
        }
        
        foreach (Producto unProducto in auxProductosFiltrados)
        {
            auxProductosFiltrados.Add(unProducto);
        }        
        
    }
    private void cargarLista()
    {
        List<Producto> lista = Comercio.Instancia.traerProductos();
        //this.gvProductos.DataSource = auxProductosFiltrados;
        this.gvProductos.DataBind();
    
    }

}