<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BanearUsuario.aspx.cs" Inherits="BanearUsuario" %>

<%@ MasterType TypeName="MasterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <p>
        <asp:Label ID="Label11" runat="server" Text="Para banear un usuario ingrese lo siguiente..."></asp:Label>
    </p>
    <asp:Label ID="Label1" runat="server" Text="Usuario a banear:" Font-Bold="True" ForeColor="#284E98"></asp:Label>
    &nbsp;<asp:TextBox ID="txtUsuarioABanear" runat="server"></asp:TextBox>
    <p>
        <asp:Button ID="btnBanear" runat="server" Text="Banear" OnClick="btnBanear_Click" />
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="*Esto evitara que el usuario ingrese al sitio y lo marcara como baneado." ForeColor="Red"></asp:Label>
    </p>
</asp:Content>

