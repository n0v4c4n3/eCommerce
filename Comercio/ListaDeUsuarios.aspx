<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListaDeUsuarios.aspx.cs" Inherits="ListaDeUsuarios" %>

<%@ MasterType TypeName="MasterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <p>
        <asp:Label ID="Label8" runat="server" Text="Lista de usuarios a gerenciar..."></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label15" runat="server" Font-Bold="True" ForeColor="#284E98" Text="Filtrar por estado:  "></asp:Label>
        <asp:DropDownList ID="ddlEstado" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged">
            <asp:ListItem>Todos</asp:ListItem>
            <asp:ListItem>Activos</asp:ListItem>
            <asp:ListItem>Inactivos</asp:ListItem>
        </asp:DropDownList>
    </p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="Yellow" BorderStyle="Double" HorizontalAlign="Center">
        <Columns>
            <asp:BoundField DataField="User" HeaderText="User" />
            <asp:BoundField DataField="Tipo" HeaderText="Rango" />
            <asp:BoundField DataField="Password" HeaderText="Password" />
            <asp:BoundField DataField="DireccionFacturacion" HeaderText="Dir. Facturacion" />
            <asp:CheckBoxField DataField="Inactivo" Text="Inactivo" />
            <asp:CheckBoxField DataField="Ban" Text="Baneado" />
            <asp:TemplateField HeaderText="Dir. Envio">
                <ItemTemplate>
                    <asp:BulletedList ID="BulletedList1" runat="server" DataSource='<%# Eval("DireccionEnvio") %>'></asp:BulletedList>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle BackColor="Yellow" ForeColor="#284E98" />
    </asp:GridView>
    <p>
        <asp:Label ID="Label10" runat="server" Text="Usuario a activar: " Font-Bold="True" ForeColor="#284E98"></asp:Label>
        <asp:TextBox ID="txtActivar" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="btnActivar" runat="server" OnClick="btnActivar_Click" Text="Activar" />
    </p>
    <p>
        <asp:Label ID="Label12" runat="server" ForeColor="Red" Text="*Se le permitira entrar al sitio."></asp:Label><br/>
        <asp:Label ID="Label14" runat="server" Text="*Tenga en cuenta que si el admin lo baneo, ese usuario no podra entrar aunque usted lo active." ForeColor="Red"></asp:Label>     
    </p>
    <p>
        <asp:Label ID="Label11" runat="server" Text="Usuario inactivar: " Font-Bold="True" ForeColor="#284E98"></asp:Label>
        <asp:TextBox ID="txtInactivar" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="btnInactivar" runat="server" OnClick="btnInactivar_Click" Text="Inactivar" />
    </p>
    <p>
        <asp:Label ID="Label13" runat="server" ForeColor="Red" Text="*No se le permitira entrar al sitio."></asp:Label>
    </p>
</asp:Content>

