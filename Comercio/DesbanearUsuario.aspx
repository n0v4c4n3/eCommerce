<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DesbanearUsuario.aspx.cs" Inherits="DesbanearUsuario" %>


<%@ MasterType TypeName="MasterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <p>
        <asp:Label ID="Label11" runat="server" Text="Para desbanear un usuario ingrese lo siguiente..."></asp:Label>
    </p>
    <asp:Label ID="Label1" runat="server" Text="Usuario a desbanear:" Font-Bold="True" ForeColor="#284E98"></asp:Label>
    &nbsp;<asp:RadioButtonList ID="rblUsuariosBaneados" runat="server">
    </asp:RadioButtonList>
    <p>
        <asp:Button ID="btnDesbanear" runat="server" Text="Desbanear" OnClick="btnDesbanear_Click" />
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="*Esto permitira que el usuario ingrese al sitio." ForeColor="Red"></asp:Label>
    </p>
</asp:Content>
