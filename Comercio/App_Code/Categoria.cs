using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Categoria
/// </summary>
public class Categoria
{
    #region Atributos
    private string mNombreCat;
    #endregion
    #region Propiedades
    public string NombreCat
    {
        get { return mNombreCat; }
        set { mNombreCat = value; }
    }
    public string MostrarToString
    {
        get { return this.ToString(); }

    }
    #endregion
    #region Constructores
    public Categoria(string pNombreCat)
    {
        this.NombreCat = pNombreCat;
    }
    #endregion
    #region Metodos
    public enum ErroresCategoria
    {
        OK,
        Nombre_de_categoria_ya_existente
    }
    public override string ToString()
    {
        return this.NombreCat;
    }
    #endregion
}