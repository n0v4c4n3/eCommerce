<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ MasterType TypeName="MasterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <asp:Panel runat="server">
        <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/Image/Log in.png" NavigateUrl="~/LogIn.aspx">LogIn</asp:HyperLink>
        <asp:HyperLink ID="HyperLink2" runat="server" ImageUrl="~/Image/Registro.png" NavigateUrl="~/AltaCliente.aspx">Registro</asp:HyperLink>
    </asp:Panel>
</asp:Content>

