using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AltaCliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((bool)Session["Logged"] != true && (Usuario.TipoUsuario)Session["Type"] == Usuario.TipoUsuario.Visitante)
        {

        }
        else
        {
            Response.Redirect("Login.aspx");
            this.Master.LblMensaje.Text = "Registrarse solo tiene sentido si eres un visitante!"; // =( bue...
        }
    }
    protected void btnAltaCliente_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            string encryptedstring = StringCipher.Encrypt(this.txtPassword.Text, "mkJcqDqU");
            List<string> resultDireccionEnvio = this.txtDireccionEnvio.Text.Split(',').ToList();
            Usuario.ErroresUsuario resultAltaCliente = Comercio.Instancia.altaUsuario(this.txtUser.Text, encryptedstring, this.txtDireccionFacturacion.Text, resultDireccionEnvio, Usuario.TipoUsuario.Cliente);
            if (resultAltaCliente == Usuario.ErroresUsuario.OK)
            {
                this.Master.LblMensaje.Text = "Alta de cliente exitosa!";
            }
            if (resultAltaCliente == Usuario.ErroresUsuario.Nombre_de_usuario_ya_existente)
            {
                this.Master.LblMensaje.Text = "Ese nombre de cliente ya esta registrado!";
            }
        }
    }
    protected void CustomValidatorEmail_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (IsValidEmail(this.txtUser.Text) == true)
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }
    }
    public bool IsValidEmail(string email)
    {
        try
        {
            var mail = new System.Net.Mail.MailAddress(email);
            return true;
        }
        catch
        {
            return false;
        }
    }
}