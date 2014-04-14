using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Recomendaciones : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarGridView();
        }
        if ((Usuario.TipoUsuario)Session["Type"] == Usuario.TipoUsuario.Visitante)
        {
            Response.Redirect("LogIn.aspx");
        }
    }
    protected void gvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "commandAgregar")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvProductos.Rows[index];
            TableCell celdaNombreProd = row.Cells[1];
            string textUser = Session["User"].ToString();
            string textNombreProd = celdaNombreProd.Text;
            bool aux = Comercio.Instancia.agregarAlCarrito(textUser, textNombreProd);
            if (aux == true)
            {
                this.Master.LblMensaje.Text = "Se agrego el producto: " + textNombreProd + " al carrito.";
                cargarGridView();
            }
            else
            {
                this.Master.LblMensaje.Text = "No se pudo agregar el producto: " + textNombreProd + " al carrito.";
            }
        }
    }
    protected void gvProductos2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "commandAgregar2")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvProductos2.Rows[index];
            TableCell celdaNombreProd = row.Cells[1];
            string textUser = Session["User"].ToString();
            string textNombreProd = celdaNombreProd.Text;
            bool aux = Comercio.Instancia.agregarAlCarrito(textUser, textNombreProd);
            if (aux == true)
            {
                this.Master.LblMensaje.Text = "Se agrego el producto: " + textNombreProd + " al carrito.";
                cargarGridView();
            }
            else
            {
                this.Master.LblMensaje.Text = "No se pudo agregar el producto: " + textNombreProd + " al carrito.";
            }
        }
    }
    protected void gvProductos3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "commandAgregar3")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvProductos3.Rows[index];
            TableCell celdaNombreProd = row.Cells[1];
            string textUser = Session["User"].ToString();
            string textNombreProd = celdaNombreProd.Text;
            bool aux = Comercio.Instancia.agregarAlCarrito(textUser, textNombreProd);
            if (aux == true)
            {
                this.Master.LblMensaje.Text = "Se agrego el producto: " + textNombreProd + " al carrito.";
                cargarGridView();
            }
            else
            {
                this.Master.LblMensaje.Text = "No se pudo agregar el producto: " + textNombreProd + " al carrito.";
            }
        }
    }
    private void cargarGridView()
    {
        //Obtengo usuario.
        string usuarioText = Session["User"].ToString();
        Usuario usuarioActivo = Comercio.Instancia.buscarUsuarioXUser(usuarioText);
        //Obtengo categorias.
        List<Categoria> auxCategorias = Comercio.Instancia.traerCategorias();
        //Por cada pedido del usuario veo sus productos y agrego sus categorias.
        List<Categoria> auxAContar = new List<Categoria>();
        if (usuarioActivo != null)
        {
            foreach (Pedido unPedido in usuarioActivo.ColPedidos)
            {
                foreach (Producto unProducto in unPedido.ColProductos)
                {
                    Categoria esteProductoCategoria = unProducto.CategoriaProducto;
                    auxAContar.Add(esteProductoCategoria);
                }
            }
        }
        //Agrupo las categorias segun nombre, despues ordeno descendente la cantidad de veces que aparecen y selecciono todas.
        List<Categoria> ordenada = auxAContar.GroupBy(x => x.NombreCat)
                  .OrderByDescending(g => g.Count())
                  .SelectMany(g => g).ToList();
        //Remuevo los duplicados.
        List<Categoria> SinDuplicados = ordenada.Distinct().ToList();
        //Obtengo la cantidad de elementos en el array para evitar errores.
        int cantidadElementos = SinDuplicados.Count();
        //Asigno las tres primeras posiciones si existen. Anidando 'if' para tirar los errores correctos a la master.       
        if (cantidadElementos >= 1)
        {
            //Creo las listas de productos para mostrar al usuario.
            Categoria uno = SinDuplicados[0];
            List<Producto> paraCategoriaUno = new List<Producto>();
            foreach (Producto unProd in Comercio.Instancia.traerProductos())
            {
                if (unProd.CategoriaProducto == uno)
                {
                    paraCategoriaUno.Add(unProd);
                }
            }
            //Bindeo las listas de productos obtenidas.
            this.gvProductos.DataSource = paraCategoriaUno;
            this.gvProductos.DataBind();
            if (cantidadElementos >= 2)
            {
                //Creo las listas de productos para mostrar al usuario.
                Categoria dos = SinDuplicados[1];
                List<Producto> paraCategoriaDos = new List<Producto>();
                foreach (Producto unProd2 in Comercio.Instancia.traerProductos())
                {
                    if (unProd2.CategoriaProducto == dos)
                    {
                        paraCategoriaDos.Add(unProd2);
                    }

                }
                //Bindeo las listas de productos obtenidas.
                this.gvProductos2.DataSource = paraCategoriaDos;
                this.gvProductos2.DataBind();
                if (cantidadElementos >= 3)
                {
                    //Creo las listas de productos para mostrar al usuario.
                    Categoria tres = SinDuplicados[2];
                    List<Producto> paraCategoriaTres = new List<Producto>();
                    foreach (Producto unProd3 in Comercio.Instancia.traerProductos())
                    {
                        if (unProd3.CategoriaProducto == tres)
                        {
                            paraCategoriaTres.Add(unProd3);
                        }

                    }
                    //Bindeo las listas de productos obtenidas.
                    this.gvProductos3.DataSource = paraCategoriaTres;
                    this.gvProductos3.DataBind();
                }
                else
                {
                    this.Master.LblMensaje.Text = "No comprastes suficientes productos para mostrar la tercera categoria recomendada. Compra!";
                }
            }
            else
            {
                this.Master.LblMensaje.Text = "No comprastes suficientes productos para mostrar la segunda ni la tercera categoria recomendada.";
            }
        }
        else
        {
            this.Master.LblMensaje.Text = "No comprastes suficientes productos para mostrar las categorias recomendadas.";
        }
    }
}