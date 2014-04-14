using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LogIn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogIn_Click(object sender, EventArgs e)
    {
        Usuario auxUsuario = Comercio.Instancia.buscarUsuarioXUser(this.txtUser.Text);
        string encryptedString = StringCipher.Encrypt(this.txtPassword.Text, "mkJcqDqU");
        if (auxUsuario != null)
        {
            if (encryptedString == auxUsuario.Password.ToString())
            {
                Usuario aux = Comercio.Instancia.loguear(this.txtUser.Text, encryptedString);
                if (aux != null)
                {
                    Session["Logged"] = true;
                    Session["User"] = aux.User;
                    Session["Type"] = aux.Tipo;
                    Session["Carrito"] = aux.Carrito;

                    Application.Lock();
                    Application["Loggeds"] = (int)Application["Loggeds"] + 1;
                    Application.UnLock();
                    this.Master.LblMensaje.Text = "Te has conectado!, redireccionando...";
                    Response.AddHeader("Refresh", "2;URL=Ini.aspx");
                }
            }
            else
            {
                this.Master.LblMensaje.Text = "El user o la password no son correctos."; //Por Password
            }
        }
        else
        {
            this.Master.LblMensaje.Text = "El user o la password no son correctos."; //Por Usuario
        }

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Usuario auxUsuario = Comercio.Instancia.buscarUsuarioXUser(this.txtUser.Text);
        if (auxUsuario != null)
        {
            Response.Redirect("RecuperarPassword.aspx?user=" + this.txtUser.Text);
        }
        else
        {
            this.Master.LblMensaje.Text = "El user para recuperar password no existe.";
        }
    }
}