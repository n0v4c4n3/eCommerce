<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ModificarDatos.aspx.cs" Inherits="ModificarDatos" %>

<%@ MasterType TypeName="MasterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <p>
        <asp:Label ID="Label4" runat="server" Text="Modificar datos del usuario..."></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label16" runat="server" Font-Bold="True" ForeColor="#284E98" Text="Datos actuales:"></asp:Label>
    </p>
    <asp:Panel runat="server" BackColor="#CCCCCC">
        <asp:Label ID="Label12" runat="server" Text="User (email): " Font-Bold="True" ForeColor="#284E98"></asp:Label>
        <asp:Label ID="lblUser" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label13" runat="server" Font-Bold="True" ForeColor="#284E98" Text="Password: "></asp:Label>
        <asp:Label ID="lblPassword" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label14" runat="server" Font-Bold="True" ForeColor="#284E98" Text="Direccion de facturacion: "></asp:Label>
        <asp:Label ID="lblDireccionFacturacion" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label15" runat="server" Font-Bold="True" ForeColor="#284E98" Text="Direcciones de envio: "></asp:Label>
        <asp:BulletedList ID="rblDireccionEnvio" runat="server" />
        <br />
    </asp:Panel>
    <p>
        <asp:Label ID="Label17" runat="server" Font-Bold="True" ForeColor="#284E98" Text="Datos nuevos:"></asp:Label>
    </p>
    <asp:Panel runat="server">
        <asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="#284E98" Text="Password: "></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label6" runat="server" Font-Bold="True" ForeColor="#284E98" Text="Direccion de facturacion: "></asp:Label>
        <asp:TextBox ID="txtDireccionFacturacion" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label7" runat="server" Font-Bold="True" ForeColor="#284E98" Text="Direccion de envio: "></asp:Label>
        <asp:TextBox ID="txtDireccionEnvio" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="*Para ingresar varias direcciones de envio, separelas por coma sin espacio."></asp:Label>
            <br />
            <asp:Label ID="Label11" runat="server" Text="*Ej.: &quot;Pereira 1311,Uruguay 4564&quot;." ForeColor="Red"></asp:Label>
        </p>
        <p>
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
        </p>

    </asp:Panel>
</asp:Content>

