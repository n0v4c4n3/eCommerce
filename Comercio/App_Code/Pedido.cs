using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Pedido
/// </summary>
public class Pedido
{
    #region Atributos
    private int mCodPedido;
    private static int mUltCod;
    private bool mEstado; // Pendiente = false | Enviado = true    
    private List<Producto> mColProductos;
    private DateTime mFecha;
    private String mDireccionEnvio;
    private Decimal mMonto;
    private bool mCancelado; // Pendiente = false | Cancelado = true    
    #endregion
    #region Propiedades
    public int CodPedido
    {
        get { return mCodPedido; }
        set { mCodPedido = value; }
    }
    public static int UltCod
    {
        get { return Pedido.mUltCod; }
        set { Pedido.mUltCod = value; }
    }
    public bool Estado
    {
        get { return mEstado; }
        set { mEstado = value; }
    }
    public List<Producto> ColProductos
    {
        get { return mColProductos; }
        set { mColProductos = value; }
    }
    public DateTime Fecha
    {
        get { return mFecha; }
        set { mFecha = value; }
    }
    public String DireccionEnvio
    {
        get { return mDireccionEnvio; }
        set { mDireccionEnvio = value; }
    }
    public Decimal Monto
    {
        get { return mMonto; }
        set { mMonto = value; }
    }
    public bool Cancelado
    {
        get { return mCancelado; }
        set { mCancelado = value; }
    }
    #endregion
    #region Constructores
    public Pedido()
    {
        Pedido.mUltCod += 1;
        this.mCodPedido = Pedido.mUltCod;
    }
    public Pedido(bool pEstado, List<Producto> pColProductos, DateTime pFecha, String pDireccionEnvio, Decimal pMonto)
        : this()
    {
        this.Estado = pEstado;
        this.ColProductos = pColProductos;
        this.Fecha = pFecha;
        this.DireccionEnvio = pDireccionEnvio;
        this.Monto = pMonto;
    }
    #endregion
    #region Metodos
    public enum ErroresPedido
    {
        OK,
        Error
    }
    #endregion
}