<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AltaCliente.aspx.cs" Inherits="AltaCliente" %>

<%@ MasterType TypeName="MasterPage" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function ClientValidateEmail(source, arguments) {
            arguments.IsValid = validarEmail();
        }

        function validarEmail() {
            var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
            var address = document.getElementById("<%= txtUser.ClientID %>").value;
            if (reg.test(address) == false) {
                return false;
            }
            else {
                return true;
            }
        }

        function hacerPostback() {
            return validarEmail();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True">
    </asp:ToolkitScriptManager>
    <p>
        <asp:Label ID="Label4" runat="server" Text="Ingresar los siguientes datos:"></asp:Label>
    </p>
    <asp:Label ID="Label3" runat="server" Text="User (email): " Font-Bold="True" ForeColor="#284E98"></asp:Label>
    <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
    &nbsp;
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="El campo &quot;User&quot; no puede estar vacio." ControlToValidate="txtUser" ValidationGroup="groupAltaCliente" Display="Dynamic">(Campo &quot;User&quot; es obligatorio)</asp:RequiredFieldValidator>
    &nbsp;<asp:CustomValidator ID="CustomValidatorEmail" runat="server" ErrorMessage="El campo &quot;User&quot; tiene que ser un email." ControlToValidate="txtUser" ClientValidationFunction="ClientValidateEmail" EnableClientScript="true" Display="Dynamic" ValidationGroup="groupAltaCliente" OnServerValidate="CustomValidatorEmail_ServerValidate" ValidateEmptyText="True">(Campo &quot;User&quot; formato email invalido)</asp:CustomValidator>
    <br />
    <asp:Label ID="Label5" runat="server" Text="Password: " Font-Bold="True" ForeColor="#284E98"></asp:Label>
    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
    &nbsp;
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="El campo &quot;Password&quot; no puede estar vacio." ControlToValidate="txtPassword" ValidationGroup="groupAltaCliente">(Campo &quot;Password&quot; es obligatorio)</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="Label6" runat="server" Text="Direccion de facturacion: " Font-Bold="True" ForeColor="#284E98"></asp:Label>
    <asp:TextBox ID="txtDireccionFacturacion" runat="server"></asp:TextBox>
    &nbsp;
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="El campo &quot;Direccion de facturacion&quot; no puede estar vacio." ControlToValidate="txtDireccionFacturacion" ValidationGroup="groupAltaCliente">(Campo &quot;Direccion de facturacion&quot; es obligatorio)</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="Label7" runat="server" Text="Direccion de envio: " Font-Bold="True" ForeColor="#284E98"></asp:Label>
    <asp:TextBox ID="txtDireccionEnvio" runat="server"></asp:TextBox>
    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="El campo &quot;Direccion de envio&quot; no puede estar vacio." ControlToValidate="txtDireccionEnvio" ValidationGroup="groupAltaCliente">(Campo &quot;Direccion de envio&quot; es obligatorio)</asp:RequiredFieldValidator>
    <p>
        <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="*Para ingresar varias direcciones de envio, separelas por coma sin espacio."></asp:Label>
        </br>
        <asp:Label ID="Label11" runat="server" Text="*Ej.: &quot;Pereira 1311,Uruguay 4564&quot;." ForeColor="Red"></asp:Label>
    </p>
    <p>
        <asp:Button ID="btnAltaCliente" runat="server" Text="Alta Cliente"
            OnClick="btnAltaCliente_Click" OnClientClick="return hacerPostback()" />
    </p>
    <p>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="groupAltaCliente" />
</asp:Content>

