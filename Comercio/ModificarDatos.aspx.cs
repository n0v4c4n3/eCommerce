using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ModificarDatos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((bool)Session["Logged"])
        {
            cargarDatos();
        }
        else
        {
            Response.Redirect("LogIn.aspx");
        }
    }
    private void cargarDatos()
    {
        Usuario usuarioActivo = Comercio.Instancia.buscarUsuarioXUser(Session["User"].ToString());
        this.lblUser.Text = usuarioActivo.User;
        this.lblPassword.Text = StringCipher.Decrypt(usuarioActivo.Password, "mkJcqDqU");
        this.lblDireccionFacturacion.Text = usuarioActivo.DireccionFacturacion;
        this.rblDireccionEnvio.DataSource = usuarioActivo.DireccionEnvio;
        this.rblDireccionEnvio.DataBind();

    }
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Usuario usuarioActivo = Comercio.Instancia.buscarUsuarioXUser(Session["User"].ToString());
            if (this.txtPassword.Text != "") // Por las dudas.
            {
                string encryptedstring = StringCipher.Encrypt(this.txtPassword.Text, "mkJcqDqU");
                usuarioActivo.Password = encryptedstring;
                cargarDatos();
                this.Master.LblMensaje.Text = "Se modifico la password.";
            }
            if (this.txtDireccionFacturacion.Text != "")
            {
                usuarioActivo.DireccionFacturacion = this.txtDireccionFacturacion.Text;
                cargarDatos();
                this.Master.LblMensaje.Text = "Se modifico la direccion de facturacion.";
            }
            if (this.txtDireccionEnvio.Text != "")
            {
                List<string> resultDireccionEnvio = this.txtDireccionEnvio.Text.Split(',').ToList(); 
                usuarioActivo.DireccionEnvio = resultDireccionEnvio;
                cargarDatos();
                this.Master.LblMensaje.Text = "Se modifico la direccion de envio.";
            }
        }
    }
}