using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListaDePedidos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((bool)Session["Logged"] && ((Usuario.TipoUsuario)Session["Type"] == Usuario.TipoUsuario.Admin ||
            (Usuario.TipoUsuario)Session["Type"] == Usuario.TipoUsuario.JefeDeDeposito))
        {
            cargarLista();
        }
        else
        {
            Response.Redirect("LogIn.aspx");
        }
    }

    protected void btnCodigoEnviado_Click(object sender, EventArgs e)
    {
        string auxPedidoEnviadoString = this.txtCodigoEnviado.Text;
        int auxNum;
        List<Pedido> pedidosAContar = Comercio.Instancia.traerPedidos();
        if (Int32.TryParse(auxPedidoEnviadoString, out auxNum))
        {
            if (auxNum >= 1 && auxNum <= pedidosAContar.Count())
            {
                Pedido pedidoBuscado = Comercio.Instancia.buscarPedidoXCodPedido(auxNum);
                pedidoBuscado.Estado = true;
                this.Master.LblMensaje.Text = "El codigo: " + auxNum + " ha sido marcado como enviado.";
                cargarLista();
            }
            else
            {
                this.Master.LblMensaje.Text = "El codigo para el pedido debe ser mayor que '1' y menor que la cantidad existente.";
            }
        }
        else
        {
            this.Master.LblMensaje.Text = "El codigo para el pedido no existe. Verificalo";
        }

    }
    protected void cargarLista()
    {
        List<Pedido> lista = Comercio.Instancia.traerPedidos();
        this.GridView1.DataSource = lista;
        this.GridView1.DataBind();
    }
}