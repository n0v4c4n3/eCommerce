using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    public Label LblMensaje
    {
        get
        {
            return this.lblMensaje;
        }
    }

    public string Mensaje
    {
        set
        {
            this.lblCarrito.Text = value;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        Usuario usuarioActivo = Comercio.Instancia.buscarUsuarioXUser(Session["User"].ToString());
        if ((bool)Session["Logged"])
        {
            List<string> listaProductosString = new List<string>();
            foreach (Producto unProd in usuarioActivo.Carrito)
            {
                listaProductosString.Add(unProd.NombreProd.ToString());
                string combindedString = string.Join(", ", listaProductosString);
                this.lblCarrito.Text = combindedString;
            }
            if (usuarioActivo.ColPedidos != null)
            {

                this.lblPedidos.Text = usuarioActivo.ColPedidos.Count().ToString();
            }
        }




        this.lblUser.Text = Session["User"].ToString();
        this.lblTipoUsuario.Text = Session["Type"].ToString();
        this.lblSessions.Text = Application["Sessions"].ToString();
        this.lblUsers.Text = Application["Loggeds"].ToString();
    }
    protected void btnVaciar_Click(object sender, EventArgs e)
    {
        string usuarioText = Session["User"].ToString();
        Usuario usuarioActivo = Comercio.Instancia.buscarUsuarioXUser(usuarioText);
        if (usuarioActivo != null)
        {
            foreach (Producto unProd in usuarioActivo.Carrito)
            {
                unProd.Stock++;
                unProd.StockReal++;
            
            }
            usuarioActivo.Carrito.Clear();
            Response.Redirect(Request.RawUrl);
        }
    }
    protected void btnRefrescar_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }
}
