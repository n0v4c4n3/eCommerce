<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AltaProducto.aspx.cs" Inherits="AltaProducto" %>

<%@ MasterType TypeName="MasterPage" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function validarTxtStock(source, arguments) {
            var varStock = document.getElementById("<%= txtStock.ClientID %>").value;
            if (!isNaN(varStock)) {
                arguments.IsValid = true;
            }
            else {
                arguments.IsValid = false;
            }
        }
        function validarTxtStockMin(source, arguments) {
            var varStockMin = document.getElementById("<%= txtStockMin.ClientID %>").value;
            if (!isNaN(varStockMin)) {
                arguments.IsValid = true;
            }
            else {
                arguments.IsValid = false;
            }
        }
        function validarTxtPrecio(source, arguments) {
            var varPrecio = document.getElementById("<%= txtPrecio.ClientID %>").value;
            if (!isNaN(varPrecio)) {
                arguments.IsValid = true;
            }
            else {
                arguments.IsValid = false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Ingrese los siguientes datos para dar de alta un producto:"></asp:Label>
    </p>
    <asp:Label ID="Label2" runat="server" Text="Nombre: "></asp:Label>
    <asp:TextBox ID="txtNombreProd" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label8" runat="server" Text="Stock ini: "></asp:Label>
    <asp:TextBox ID="txtStock" runat="server"></asp:TextBox>
    &nbsp;<asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="validarTxtStock" ControlToValidate="txtStockMin" ErrorMessage="El campo &quot;Stock ini.&quot; debe ser un numero ni vacio." OnServerValidate="CustomValidator1_ServerValidate" ValidateEmptyText="True" ValidationGroup="groupAltaProducto">(Campo "Stock ini. debe ser un numero)</asp:CustomValidator>
    <br />
    <asp:Label ID="Label9" runat="server" Text="Stock min: "></asp:Label>
    <asp:TextBox ID="txtStockMin" runat="server"></asp:TextBox>
    &nbsp;<asp:CustomValidator ID="CustomValidator2" runat="server" ClientValidationFunction="validarTxtStockMin" ControlToValidate="txtStockMin" ErrorMessage="El campo &quot;Stock min.&quot; debe ser un numero ni vacio." OnServerValidate="CustomValidator2_ServerValidate" ValidateEmptyText="True" ValidationGroup="groupAltaProducto">(Campo "Stock min." debe ser un numero)</asp:CustomValidator>
    <br />
    <asp:Label ID="Label10" runat="server" Text="Precio: "></asp:Label>
    <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
    &nbsp;<asp:CustomValidator ID="CustomValidator3" runat="server" ClientValidationFunction="validarTxtPrecio" ControlToValidate="txtPrecio" ErrorMessage="El campo &quot;Precio&quot; debe ser decimal ni vacio." OnServerValidate="CustomValidator3_ServerValidate" ValidateEmptyText="True" ValidationGroup="groupAltaProducto">(Campo "Precio" debe ser decimal)</asp:CustomValidator>
    <br />
    <asp:Label ID="Label11" runat="server" Text="Categoria: "></asp:Label>
    <asp:RadioButtonList ID="rblCategoria" runat="server">
    </asp:RadioButtonList>
    <br />
    <asp:Label ID="Label12" runat="server" Text="Imagen: "></asp:Label>
    <asp:FileUpload ID="fuImagen" runat="server" />
    <br />
    <p>
        <asp:Button ID="btnAltaProducto" runat="server" Text="Alta Producto" OnClick="btnAltaProducto_Click" />
    </p>
    <p>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="groupAltaProducto" />
    </p>
</asp:Content>

