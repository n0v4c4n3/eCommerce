<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AltaCategoria.aspx.cs" Inherits="AltaCategoria" %>

<%@ MasterType TypeName="MasterPage" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <p>
        <asp:Label ID="Label8" runat="server" Text="Ingrese el nombre de categoria que desea crear:"></asp:Label>
    </p>
    <asp:Label ID="Label9" runat="server" Text="Nombre: "></asp:Label>
    <asp:TextBox ID="txtNombreCat" runat="server"></asp:TextBox>
    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombreCat" ErrorMessage="El campo &quot;Nombre&quot; no puede estar vacio." ValidationGroup="groupAltaCategoria">(Campo &quot;Nombre&quot; es obligaorio)</asp:RequiredFieldValidator>
    <p>
        <asp:Button ID="btnAltaCategoria" runat="server" Text="Alta Categoria" OnClick="Button1_Click" Style="margin-bottom: 0px" />
    </p>
    <p>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="groupAltaCategoria" />
</asp:Content>

