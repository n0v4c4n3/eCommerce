<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VentaMenor.aspx.cs" Inherits="VentaMenor" %>

<%@ MasterType TypeName="MasterPage" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <p>
        <asp:Label ID="Label11" runat="server" Text="Lista de productos con venta menor que un valor entre dos fechas:"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label12" runat="server" Text="Fecha inical: " Font-Bold="True" ForeColor="#284E98"></asp:Label>
        <asp:TextBox ID="txtFechaInicial" runat="server"></asp:TextBox>
        <asp:CalendarExtender ID="txtFechaInicial_CalendarExtender" runat="server" TargetControlID="txtFechaInicial">
        </asp:CalendarExtender>
    </p>
    <p>
        <asp:Label ID="Label13" runat="server" Text="Fecha tope: " Font-Bold="True" ForeColor="#284E98"></asp:Label>
        <asp:TextBox ID="txtFechaTope" runat="server"></asp:TextBox>
        <asp:CalendarExtender ID="txtFechaTope_CalendarExtender" runat="server" TargetControlID="txtFechaTope">
        </asp:CalendarExtender>
    </p>
    <p>
        <asp:Label ID="Label14" runat="server" Text="Monto minimo: " Font-Bold="True" ForeColor="#284E98"></asp:Label>
        <asp:TextBox ID="txtMontoMinimo" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label15" runat="server" ForeColor="Red" Text="*El  monto minimo por producto (ganancias)."></asp:Label>
    </p>
    <p>
        <asp:Button ID="btnCalcular" runat="server" Text="Calcular" OnClick="btnCalcular_Click" />
    </p>
    <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="Yellow" BorderStyle="Double" Font-Bold="False">
        <Columns>
            <asp:BoundField DataField="CategoriaProducto" HeaderText="Categoria" />
            <asp:BoundField DataField="NombreProd" HeaderText="Nombre" />
            <asp:BoundField DataField="Stock" HeaderText="Stock" />
            <asp:BoundField DataField="StockMin" HeaderText="Stock Min." />
            <asp:ImageField DataImageUrlField="Imagen" HeaderText="Imagen" NullImageUrl="~/Image/404.png">
                <ControlStyle Height="80px" Width="80px" />
            </asp:ImageField>
            <asp:BoundField DataField="Precio" HeaderText="Precio $" />
        </Columns>
        <HeaderStyle BackColor="Yellow" ForeColor="#284E98" />
    </asp:GridView>
</asp:Content>

