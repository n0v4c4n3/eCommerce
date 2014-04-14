<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RealizarPedido.aspx.cs" Inherits="RealizarPedido" %>

<%@ MasterType TypeName="MasterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <p>
        <asp:Label ID="Label10" runat="server" Text="Para realizar el pedido haga click en confirmar."></asp:Label>
    </p>
    <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="Yellow" BorderStyle="Double" Font-Bold="False" OnRowCommand="gvProductos_RowCommand">
        <Columns>
            <asp:BoundField DataField="CategoriaProducto" HeaderText="Categoria" />
            <asp:BoundField DataField="NombreProd" HeaderText="Nombre" />
            <asp:ImageField DataImageUrlField="Imagen" HeaderText="Imagen" NullImageUrl="~/Image/404.png">
                <ControlStyle Height="80px" Width="80px" />
            </asp:ImageField>
            <asp:BoundField DataField="Precio" HeaderText="Precio $">
                <ItemStyle BackColor="Yellow" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Carrito">
                <ItemTemplate>
                    <asp:Button ID="btnSacar" runat="server"
                        CommandName="commandSacar"
                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                        Text="Sacar" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle BackColor="Yellow" ForeColor="#284E98" />
    </asp:GridView>
    <p>
        <asp:Label ID="Label12" runat="server" Font-Bold="True" ForeColor="#284E98" Text="Enviar a: "></asp:Label>
        <asp:RadioButtonList ID="rblDirecciones" runat="server"></asp:RadioButtonList>
    </p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Monto total: $" Font-Bold="True" ForeColor="#284E98"></asp:Label>
        <asp:Label ID="lblMontoTotal" runat="server" BorderColor="Yellow" BorderStyle="Double" BorderWidth="5px" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label11" runat="server" Font-Bold="True" ForeColor="#284E98" Text="Confirmacion: "></asp:Label>
        <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click" />
    </p>
</asp:Content>

