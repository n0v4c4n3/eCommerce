using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AltaProducto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((bool)Session["Logged"] && (Usuario.TipoUsuario)Session["Type"] == Usuario.TipoUsuario.Admin)
        {
            if (!this.IsPostBack)
            {
                this.cargarCategorias();
            }
        }
        else
        {
            Response.Redirect("LogIn.aspx");
        }
    }

    protected void btnAltaProducto_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            string textImagen = "";
            if (this.fuImagen.HasFile)
            {
                textImagen += this.txtNombreProd.Text;
                textImagen += this.fuImagen.FileName.Substring(this.fuImagen.FileName.LastIndexOf("."));
                this.fuImagen.SaveAs(HttpRuntime.AppDomainAppPath + "/Image/" + textImagen);
            }

            int auxStock;
            int auxStockMin;
            Categoria selected = Comercio.Instancia.buscarCategoriaXNombreCat(this.rblCategoria.SelectedValue);
            Decimal auxPrecio;
            if (this.rblCategoria.SelectedValue != "")
            {
                if (Int32.TryParse(this.txtStock.Text, out auxStock))
                {
                    if (Int32.TryParse(this.txtStockMin.Text, out auxStockMin))
                    {
                        if (Decimal.TryParse(this.txtPrecio.Text, out auxPrecio))
                        {
                            Producto.ErroresProducto resultado = Comercio.Instancia.altaProducto(selected, this.txtNombreProd.Text, auxStock, auxStockMin, textImagen, auxPrecio);
                            if (resultado == Producto.ErroresProducto.OK)
                            {
                                this.Master.LblMensaje.Text = "Se dio de alta al producto.";
                            }
                            if (resultado == Producto.ErroresProducto.Nombre_de_producto_ya_existente)
                            {
                                this.Master.LblMensaje.Text = "Ese nombre de producto ya existe.";
                            }
                        }
                    }
                }
            }
            else
            {
                this.Master.LblMensaje.Text = "Tienes que seleccionar una categoria para el producto.";
            }

        }
    }
    private void cargarCategorias()
    {
        this.rblCategoria.DataValueField = "NombreCat";
        this.rblCategoria.DataTextField = "MostrarToString";
        this.rblCategoria.DataSource = Comercio.Instancia.traerCategorias();
        this.rblCategoria.DataBind();
    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        int num;
        bool num1 = int.TryParse(this.txtStock.Text, out num);
        if (num1)
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }
    }
    protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
    {
        int num;
        bool num2 = int.TryParse(this.txtStockMin.Text, out num);
        if (num2)
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }
    }
    protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
    {
        Decimal num;
        bool num3 = Decimal.TryParse(this.txtPrecio.Text, out num);
        if (num3)
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }
    }
}