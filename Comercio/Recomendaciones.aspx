<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Recomendaciones.aspx.cs" Inherits="Recomendaciones" %>

<%@ MasterType TypeName="MasterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <p>
        <asp:Label ID="Label10" runat="server" Text="Estas son tus 3 categorias recomendadas:"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label11" runat="server" Text="Primer categoria mas comprada: " Font-Bold="True" ForeColor="#284E98"></asp:Label>
    </p>
    <p>
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
    </p>
    <p>
        <asp:Label ID="Label12" runat="server" Text="Segunda categoria mas comprada: " Font-Bold="True" ForeColor="#284E98"></asp:Label>
    </p>
    <p>
        <asp:GridView ID="gvProductos2" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="Yellow" BorderStyle="Double" Font-Bold="False" OnRowCommand="gvProductos2_RowCommand">
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
                        <asp:Button ID="btnAgregar2" runat="server"
                            CommandName="commandAgregar2"
                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                            Text="Agregar" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle BackColor="Yellow" ForeColor="#284E98" />
        </asp:GridView>
    </p>
    <p>
        <asp:Label ID="Label13" runat="server" Text="Tercera categoria mas comprada: " Font-Bold="True" ForeColor="#284E98"></asp:Label>
    </p>
    <p>
        <asp:GridView ID="gvProductos3" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="Yellow" BorderStyle="Double" Font-Bold="False" OnRowCommand="gvProductos3_RowCommand">
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
                        <asp:Button ID="btnAgregar3" runat="server"
                            CommandName="commandAgregar3"
                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                            Text="Agregar" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle BackColor="Yellow" ForeColor="#284E98" />
        </asp:GridView>
    </p>
</asp:Content>

