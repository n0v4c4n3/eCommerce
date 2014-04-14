<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Montos.aspx.cs" Inherits="Montos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ MasterType TypeName="MasterPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <p>
        <asp:Label ID="Label11" runat="server" Text="Monto total entre dos fechas: "></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label12" runat="server" Text="Fecha inical: "></asp:Label>
        <asp:TextBox ID="txtFechaInicial" runat="server"></asp:TextBox>
        <asp:CalendarExtender ID="txtFechaInicial_CalendarExtender" runat="server" TargetControlID="txtFechaInicial">
        </asp:CalendarExtender>
    </p>
    <p>
        <asp:Label ID="Label13" runat="server" Text="Fecha tope: "></asp:Label>
        <asp:TextBox ID="txtFechaTope" runat="server"></asp:TextBox>
        <asp:CalendarExtender ID="txtFechaTope_CalendarExtender" runat="server" TargetControlID="txtFechaTope">
        </asp:CalendarExtender>
    </p>
    <p>
        <asp:Button ID="btnCalcular" runat="server" Text="Calcular" OnClick="btnCalcular_Click" />
    </p>
    <p>
        <asp:Label ID="Label14" runat="server" Text="Resultado: $"></asp:Label>
        <asp:Label ID="lblMonto" runat="server" BorderColor="Yellow" BorderStyle="Double" BorderWidth="5px" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
    </p>

</asp:Content>

