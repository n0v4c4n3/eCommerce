<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Productos.aspx.cs" Inherits="Productos" %>

<%@ MasterType TypeName="MasterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <p>
        <asp:Label ID="Label8" runat="server" Text="Seleccione productos:"></asp:Label>
    </p>
    <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="Yellow" BorderStyle="Double" Font-Bold="False" OnRowCommand="gvProductos_RowCommand">
        <Columns>
            <asp:BoundField DataField="CategoriaProducto" HeaderText="Categoria" />
            <asp:BoundField DataField="NombreProd" HeaderText="Nombre" />
            <asp:BoundField DataField="Stock" HeaderText="Stock" />
            <asp:BoundField DataField="StockMin" HeaderText="Stock Min." />
            <asp:ImageField DataImageUrlField="Imagen" HeaderText="Imagen" NullImageUrl="~/Image/404.png">
                <ControlStyle Height="80px" Width="80px" />
            </asp:ImageField>
            <asp:BoundField DataField="Precio" HeaderText="Precio $" />
            <asp:TemplateField HeaderText="Carrito">
                <ItemTemplate>
                    <asp:Button ID="btnAgregar" runat="server"
                        CommandName="commandAgregar"
                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                        Text="Agregar" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle BackColor="Yellow" ForeColor="#284E98" />
    </asp:GridView>
    <p></p>
</asp:Content>

