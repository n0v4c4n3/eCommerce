<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RecuperarPassword.aspx.cs" Inherits="RecuperarPassword" %>

<%@ MasterType TypeName="MasterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <p>
        <asp:Label ID="Label11" runat="server" Text="Para recuperar la password ingrese:"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="User (email): "></asp:Label>
        <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
        </br>
        <asp:Label ID="Label12" runat="server" Text="Alguna dir. envio:  "></asp:Label>
        <asp:TextBox ID="txtDirEnvio" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Recuperar" />
    </p>
    <p>
        <asp:Label ID="Label13" runat="server" Text="Password desencriptada: "></asp:Label>
        <asp:Label ID="lblPassword" runat="server" BorderColor="Yellow" BorderStyle="Double" BorderWidth="5px" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
    </p>

</asp:Content>

