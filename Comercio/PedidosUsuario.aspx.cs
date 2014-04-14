using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PedidosUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((bool)Session["Logged"])
        {
            cargarLista();
        }
        else
        {
            Response.Redirect("LogIn.aspx");
        }
    }
    protected void btnCodigoCancelado_Click(object sender, EventArgs e)
    {
        string auxPedidoCanceladoString = this.txtCodigoCancelado.Text;
        int auxNum;
        List<Pedido> pedidosAContar = Comercio.Instancia.traerPedidos();
        Usuario usuarioActivo = Comercio.Instancia.buscarUsuarioXUser(Session["User"].ToString());
        if (Int32.TryParse(auxPedidoCanceladoString, out auxNum))
        {
            if (auxNum >= 1 && auxNum <= pedidosAContar.Count())
            {
                foreach (Pedido unPedidoDelUsuario in usuarioActivo.ColPedidos)
                {

                    if (auxNum == unPedidoDelUsuario.CodPedido)
                    {
                        seguir(auxNum);
                    }                   
                }
            }
        }
    }
    protected void seguir(int pAuxNum)
    {
        string auxPedidoCanceladoString = this.txtCodigoCancelado.Text;
        List<Pedido> pedidosAContar = Comercio.Instancia.traerPedidos();

        Pedido pedidoBuscado = Comercio.Instancia.buscarPedidoXCodPedido(pAuxNum);
        if (pedidoBuscado.Estado == false)
        {
            if (pedidoBuscado.Cancelado == false)
            {
                foreach (Producto unProd in pedidoBuscado.ColProductos)
                {
                    unProd.Stock++;
                }
                pedidoBuscado.Cancelado = true;
                this.Master.LblMensaje.Text = "El codigo: " + pAuxNum + " ha sido cancelado y su stock restaurado.";
                cargarLista();
            }
            else
            {
                this.Master.LblMensaje.Text = "El codigo: " + pAuxNum + " ya fue cancelado anteriormente.";
            }
        }
        else
        {
            this.Master.LblMensaje.Text = "El codigo: " + pAuxNum + " esta marcado como pendiente o enviado, no puedes cancelarlo.";
        }
    }

    protected void cargarLista()
    {
        Usuario usuarioActivo = Comercio.Instancia.buscarUsuarioXUser(Session["User"].ToString());
        List<Pedido> lista = usuarioActivo.ColPedidos;
        this.GridView1.DataSource = lista;
        this.GridView1.DataBind();
    }

}