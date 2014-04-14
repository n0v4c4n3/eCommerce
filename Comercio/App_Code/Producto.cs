using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Producto
/// </summary>
public class Producto
{
    #region Atributos
    private Categoria mCategoriaProducto;
    private string mNombreProd; //Identifica al producto
    private int mStock;
    private int mStockMin;
    private string mImagen;
    private Decimal mPrecio;
    private int mStockReal;    
    #endregion
    #region Propiedades
    public Categoria CategoriaProducto
    {
        get { return mCategoriaProducto; }
        set { mCategoriaProducto = value; }
    }
    public string NombreProd
    {
        get { return mNombreProd; }
        set { mNombreProd = value; }
    }
    public int Stock
    {
        get { return mStock; }
        set { mStock = value; }
    }
    public int StockMin
    {
        get { return mStockMin; }
        set { mStockMin = value; }
    }
    public decimal Precio
    {
        get { return mPrecio; }
        set { mPrecio = value; }
    }
    public string Imagen
    {
        get
        {
            if (mImagen == "") return null;
            return "Image/" + mImagen;
        }
        set { mImagen = value; }
    }
    public int StockReal
    {
        get { return mStockReal; }
        set { mStockReal = value; }
    }
    #endregion
    #region Constructores
    public Producto(Categoria pCategoriaProducto, string pNombreProd, int pStock, int pStockMin, string pImagen, decimal pPrecio, int pStockReal)
    {
        this.CategoriaProducto = pCategoriaProducto;
        this.NombreProd = pNombreProd;
        this.Stock = pStock;
        this.StockMin = pStockMin;
        this.Imagen = pImagen;
        this.Precio = pPrecio;
        this.StockReal = pStockReal;
    }
    #endregion
    #region Metodos

    public override string ToString()
    {
        return this.NombreProd;
    }
    public enum ErroresProducto
    {
        OK,
        Nombre_de_producto_ya_existente
    }
    #endregion
}