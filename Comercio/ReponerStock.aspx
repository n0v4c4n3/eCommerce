<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReponerStock.aspx.cs" Inherits="ReponerStock" %>

<%@ MasterType TypeName="MasterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <p>
        <asp:Label ID="Label1" runat="server" Text="Los siguientes productos  necesitan reponer stock:"></asp:Label>
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
            <asp:TemplateField HeaderText="Mas Cant.">
                <ItemTemplate>
                    <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Aceptar">
                <ItemTemplate>
                    <asp:Button ID="AddButton" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="AgregarStock" Text="Agregar Stock" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle BackColor="Yellow" ForeColor="#284E98" />
    </asp:GridView>
    <p>
        <asp:Label ID="Label12" runat="server" Font-Bold="True" ForeColor="#284E98" Text="Forzar vaciado de todos los carritos: "></asp:Label>
        <asp:Button ID="btnVaciarTodo" runat="server" Text="Vaciar" OnClick="btnVaciarTodo_Click" />
    </p>
    <p>
        <asp:Label ID="Label11" runat="server" ForeColor="Red" Text="*Usarlo solo si es necesario."></asp:Label>
    </p>
</asp:Content>

