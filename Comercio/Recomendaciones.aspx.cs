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
            this.Master.LblMensaje.Text = "Acuerdate que necesitas registrarte para reservar productos en el carrito.";
            //Sino me podrian reservar productos todos los visitantes que entren!!!.
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
                this.Master.LblMensaje.Text = "Se agrego el producto: " + textNombreProd + " al carrito. Refrescando vista del carrito (en User info)...";
                cargarGridView();
                Response.AddHeader("Refresh", "3; URL=Productos.aspx");
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
        foreach (Pedido unPedido in usuarioActivo.ColPedidos)
        {
            foreach (Producto unProducto in unPedido.ColProductos)
            {
                Categoria esteProductoCategoria = unProducto.CategoriaProducto;
                auxAContar.Add(esteProductoCategoria);
            }
        }
        //Ordeno las categorias segun nombre y despues por la cantidad de veces que aparecen.
        List<Categoria> ordenada = auxAContar.GroupBy(x => x.NombreCat)
                  .OrderByDescending(g => g.Count())
                  .SelectMany(g => g).ToList();
        //Remuevo los duplicados
        List<Categoria> SinDuplicados = ordenada.Distinct().ToList();
        //Obtengo la cantidad de elementos en el array para evitar errores.
        int cantidadElementos = SinDuplicados.Count();
        //Asigno las tres primeras posiciones si existen.       
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
                    this.Master.LblMensaje.Text = "No compraste suficientes productos para mostrar la tercera categoria recomendada. Compra!";
                }
            }
            else
            {
                this.Master.LblMensaje.Text = "No compraste suficientes productos para mostrar la segunda ni la tercera categoria recomendada.";
            }
        }
        else
        {
            this.Master.LblMensaje.Text = "No compraste suficientes productos para mostrar las categorias recomendadas.";
        }


    }
}