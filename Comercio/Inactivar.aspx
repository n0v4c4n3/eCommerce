<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Inactivar.aspx.cs" Inherits="Inactivar" %>

<%@ MasterType TypeName="MasterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <p>
        <asp:Label ID="Label11" runat="server" Text="Inactivacion de cuenta..."></asp:Label>
    </p>
    <p>
        <asp:Button ID="btnInactivar" runat="server" Text="Inactivarme" OnClick="btnInactivar_Click" />
    </p>
    <p>
        <asp:Label ID="Label12" runat="server" Text="*Tenga en cuenta que una vez inactivado no podra loguearse." ForeColor="Red"></asp:Label>
        <br />
        <asp:Label ID="Label5" runat="server" Text="*Se cerrara automaticamente la sesion." ForeColor="Red"></asp:Label>
        <br />
        <asp:Label ID="Label1" runat="server" Text="*Para activarse necesitara solicitar con un gerente o administrador." ForeColor="Red"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label13" runat="server" Text="Emails de contacto:"></asp:Label>

        <asp:BulletedList ID="BulletedList1" runat="server">
            <asp:ListItem>Admin@comercio.com</asp:ListItem>
            <asp:ListItem>Gerente@comercio.com</asp:ListItem>
        </asp:BulletedList>
    </p>
</asp:Content>

