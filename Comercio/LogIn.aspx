<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LogIn.aspx.cs" Inherits="LogIn" %>

<%@ MasterType TypeName="MasterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <p>
        <asp:Label ID="Label8" runat="server" Text="Ingrese sus datos:"></asp:Label>
    </p>
    <div>
        <asp:Label ID="Label1" runat="server" Text="User (email): " Font-Bold="True" ForeColor="#284E98"></asp:Label>
        <asp:TextBox ID="txtUser" runat="server">Admin@comercio.com</asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Password: " Font-Bold="True" ForeColor="#284E98"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <p>
            <asp:Button ID="btnLogin" runat="server" OnClick="btnLogIn_Click" Text="Log in" />
            &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="False" ForeColor="#284E98" OnClick="LinkButton1_Click">Recuperar password?</asp:LinkButton>
        </p>
    </div>
</asp:Content>

