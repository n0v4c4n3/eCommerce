using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RecuperarPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["user"]))
            {
                string toTxtUser = Request.QueryString["user"].ToString();
                this.lblUser.Text = toTxtUser;
            }        
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string user = this.lblUser.Text;
        string dirEnvio = this.txtDirEnvio.Text;
        Usuario usuarioBuscado = Comercio.Instancia.buscarUsuarioXUser(user);

        if (usuarioBuscado != null)
        {
            foreach (string unaDirEnvio in usuarioBuscado.DireccionEnvio)
            {
                if (unaDirEnvio == dirEnvio)
                {
                    string decryptedString = StringCipher.Decrypt(usuarioBuscado.Password, "mkJcqDqU");
                    this.lblPassword.Text = decryptedString;
                }
            }
            this.Master.LblMensaje.Text = "Dir. Envio invalida.";
        }
        else
        {
            this.Master.LblMensaje.Text = "User invalido.";
        }
    }
}