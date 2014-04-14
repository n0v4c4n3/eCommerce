using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Montos : System.Web.UI.Page
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
        //DateTime dateInicial = Convert.ToDateTime(fechaInicial);
        string fechaTope = this.txtFechaTope.Text;
        //DateTime dateTope = Convert.ToDateTime(fechaTope);
        List<Pedido> auxPedidos = Comercio.Instancia.traerPedidos();
        Decimal monto = new Decimal();
        DateTime auxFechaInicial;
        DateTime auxFechaTope;
        if (DateTime.TryParse(fechaInicial, out auxFechaInicial))
        {
            if (DateTime.TryParse(fechaTope, out auxFechaTope))
            {
                if (auxFechaInicial < auxFechaTope)
                {
                    foreach (Pedido unPedido in auxPedidos)
                    {
                        if (unPedido.Estado == true && unPedido.Cancelado == false) //No calculo si el pedido no fue enviado o si esta cancelado.
                        {
                            DateTime auxDate = Convert.ToDateTime(unPedido.Fecha);
                            if (auxDate >= auxFechaInicial && auxDate <= auxFechaTope)
                            {
                                monto = monto + unPedido.Monto;
                            }
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
        this.lblMonto.Text = monto.ToString();
    }
}