using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Usuario
/// </summary>
public class Usuario
{
    #region Atributos
    private string mUser;
    private string mPassword;
    private string mDireccionFacturacion;
    private List<String> mDireccionEnvio;
    private List<Pedido> mColPedidos = new List<Pedido>();
    private List<Producto> mCarrito = new List<Producto>();
    private Usuario.TipoUsuario mTipo;
    private int mCod;
    private static int mUltCod;
    private bool mInactivo = true;
    private bool mBan;     
    #endregion
    #region Propiedades
    public string User
    {
        get { return mUser; }
        set { mUser = value; }
    }
    public string Password
    {
        get { return mPassword; }
        set { mPassword = value; }
    }
    public string DireccionFacturacion
    {
        get { return mDireccionFacturacion; }
        set { mDireccionFacturacion = value; }
    }
    public List<String> DireccionEnvio
    {
        get { return mDireccionEnvio; }
        set { mDireccionEnvio = value; }
    }
    public List<Pedido> ColPedidos
    {
        get { return mColPedidos; }
        set { mColPedidos = value; }
    }
    public List<Producto> Carrito
    {
        get { return mCarrito; }
        set { mCarrito = value; }
    }
    public Usuario.TipoUsuario Tipo
    {
        get { return mTipo; }
        set { mTipo = value; }
    }
    public bool Inactivo
    {
        get { return mInactivo; }
        set { mInactivo = value; }
    }
    public bool Ban
    {
        get { return mBan; }
        set { mBan = value; }
    }
    #endregion
    #region Constructores
    public Usuario()
    {
        Usuario.mUltCod += 1;
        this.mCod = Usuario.mUltCod;
    }

    public Usuario(string pUser, string pPassword, string pDirecionFacturacion, List<String> pDireccionEnvio, Usuario.TipoUsuario pTipo)
        : this()
    {
        this.User = pUser;
        this.Password = pPassword;
        this.DireccionFacturacion = pDirecionFacturacion;
        this.DireccionEnvio = pDireccionEnvio;              
        this.Tipo = pTipo;
    }
    #endregion
    #region Metodos
    public enum TipoUsuario
    {
        Admin, 
        Gerente, 
        JefeDeDeposito, 
        Cliente, 
        Visitante 
    }
    public enum ErroresUsuario
    {
        OK,
        Nombre_de_usuario_ya_existente
    }
    public List<Producto> retornarListProductosCarrito()
    {
        return this.Carrito;
    }
    public string retornarStringProductosCarrito()
    {
        string combindedString = string.Join(",", this.Carrito.ToString());
        return combindedString;
    }
    #endregion
}