using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Comercio
/// </summary>
public class Comercio
{
    #region Atributos
    private List<Usuario> mColUsuarios;
    private List<Producto> mColProductos;
    private List<Categoria> mColCategorias;
    private List<Pedido> mColPedidos;
    private static Comercio mInstancia;
    #endregion
    #region Contructores
    public Comercio()
    {
        this.mColUsuarios = new List<Usuario>();
        this.mColProductos = new List<Producto>();
        this.mColCategorias = new List<Categoria>();
        this.mColPedidos = new List<Pedido>();
    }
    #endregion
    #region Metodos
    public static Comercio Instancia
    {
        get
        {
            if (Comercio.mInstancia == null)
            {
                Comercio.mInstancia = new Comercio();
            }

            return Comercio.mInstancia;
        }
    }
    public Usuario.ErroresUsuario altaUsuario(string pUser, string pPassword, string pDireccionFacturacion, List<String> pDireccionEnvio, Usuario.TipoUsuario pTipo)
    {
        Usuario aux = this.buscarUsuarioXUser(pUser);
        Usuario.ErroresUsuario retorno = Usuario.ErroresUsuario.OK;

        if (aux == null)
        {
            Usuario nuevo = new Usuario();
            nuevo.User = pUser;
            nuevo.Password = pPassword;
            nuevo.DireccionFacturacion = pDireccionFacturacion;
            nuevo.DireccionEnvio = pDireccionEnvio;
            nuevo.Tipo = pTipo;
            this.mColUsuarios.Add(nuevo);
        }
        else
        {
            retorno = Usuario.ErroresUsuario.Nombre_de_usuario_ya_existente;
        }

        return retorno;
    }
    public Producto.ErroresProducto altaProducto(Categoria pCategoriaProducto, string pNombreProd, int pStock, int pStockMin, string pImagen, decimal pPrecio)
    {
        Producto aux = this.buscarProductoXNombreProd(pNombreProd);
        Producto.ErroresProducto retorno = Producto.ErroresProducto.OK;

        if (aux == null)
        {
            Producto nuevo = new Producto(pCategoriaProducto, pNombreProd, pStock, pStockMin, pImagen, pPrecio);
            this.mColProductos.Add(nuevo);
        }
        else
        {
            retorno = Producto.ErroresProducto.Nombre_de_producto_ya_existente;
        }
        return retorno;
    }
    public Categoria.ErroresCategoria altaCategoria(string pNombreCat)
    {
        Categoria aux = this.buscarCategoriaXNombreCat(pNombreCat);
        Categoria.ErroresCategoria retorno = Categoria.ErroresCategoria.OK;

        if (aux == null)
        {
            Categoria nueva = new Categoria(pNombreCat);
            this.mColCategorias.Add(nueva);
        }
        else
        {
            retorno = Categoria.ErroresCategoria.Nombre_de_categoria_ya_existente;
        }
        return retorno;
    }
    public int altaPedido(bool pEstado, List<Producto> pColProductos, DateTime pFecha, String pDireccionEnvio, Decimal pMonto)
    {
        Pedido nuevo = new Pedido(false, pColProductos, pFecha, pDireccionEnvio, pMonto);
        nuevo.Estado = pEstado;
        nuevo.ColProductos = pColProductos;
        nuevo.Fecha = pFecha;
        nuevo.DireccionEnvio = pDireccionEnvio;
        nuevo.Monto = pMonto;
        this.mColPedidos.Add(nuevo);
        return nuevo.CodPedido;

    }
    public List<Usuario> traerUsuarios()
    {
        return this.mColUsuarios;
    }
    public List<Categoria> traerCategorias()
    {
        return this.mColCategorias;
    }
    public List<Producto> traerProductos()
    {
        return this.mColProductos;
    }
    public List<Pedido> traerPedidos()
    {
        return this.mColPedidos;
    }
    public Usuario traerUsuario(string pUser)
    {
        return this.buscarUsuarioXUser(pUser);
    }
    public List<String> traerListaDireccionesXUser(string pUser)
    {
        Usuario auxUser = buscarUsuarioXUser(pUser);
        return auxUser.DireccionEnvio;
    }
    public Usuario buscarUsuarioXUser(string pUser)
    {
        foreach (Usuario unUser in this.mColUsuarios)
            if (unUser.User == pUser)
            {
                return unUser;
            }
        return null;
    }
    public Pedido buscarPedidoXCodPedido(int pCodPedido)
    {
        foreach (Pedido unPedido in this.mColPedidos)
            if (unPedido.CodPedido == pCodPedido)
            {
                return unPedido;
            }
        return null;
    }
    public Producto buscarProductoXNombreProd(string pNombreProd)
    {
        foreach (Producto unProd in this.mColProductos)
            if (unProd.NombreProd == pNombreProd)
            {
                return unProd;
            }
        return null;
    }
    public Categoria buscarCategoriaXNombreCat(string pNombreCat)
    {
        foreach (Categoria unaCat in this.mColCategorias)
            if (unaCat.NombreCat == pNombreCat)
            {
                return unaCat;
            }
        return null;
    }
    public Usuario loguear(string pUser, string pPassword)
    {
        Usuario aux = this.buscarUsuarioXUser(pUser);

        if (aux != null)
        {
            if (aux.Password != pPassword)
            {
                aux = null;
            }
        }
        return aux;
    }
    public bool agregarAlCarrito(String pUser, String pNombreProd)
    {
        Usuario unUsuario = this.buscarUsuarioXUser(pUser);
        Producto unProducto = this.buscarProductoXNombreProd(pNombreProd);
        if (unUsuario != null && unProducto != null)
        {
            if (unProducto.Stock >= 1)
            {
                unUsuario.Carrito.Add(unProducto);
                unProducto.Stock--;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    public bool sacarDelCarrito(String pUser, String pNombreProd)
    {
        Usuario unUsuario = this.buscarUsuarioXUser(pUser);
        Producto unProducto = this.buscarProductoXNombreProd(pNombreProd);
        if (unUsuario != null && unProducto != null)
        {
            foreach (Producto unProd in unUsuario.Carrito)
            {
                if (pNombreProd == unProd.NombreProd)
                {
                    unUsuario.Carrito.Remove(unProd);
                    unProd.Stock++;
                    return true;
                }
            }
            return false;
        }
        else
        {
            return false;
        }
    }
    public List<Producto> traerProductosStockBajo()
    {
        List<Producto> auxProdStockBajo = new List<Producto>();
        foreach (Producto unProd in this.mColProductos)
        {
            if (unProd.Stock < unProd.StockMin)
            {
                auxProdStockBajo.Add(unProd);
            }

        }
        return auxProdStockBajo;
    }
    public void agregarStock(string pNombreProd, int pCantidad)
    {
        List<Producto> auxList = this.traerProductosStockBajo();
        foreach (Producto unProd in auxList)
        {
            if (pNombreProd == unProd.NombreProd.ToString())
            {
                unProd.Stock = unProd.Stock + pCantidad;
            }
        }
    }
    #endregion

}