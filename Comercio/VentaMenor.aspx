<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VentaMenor.aspx.cs" Inherits="VentaMenor" %>

<%@ MasterType TypeName="MasterPage" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True">
    </asp:ToolkitScriptManager>
    <p>
        <asp:Label ID="Label11" runat="server" Text="Lista de productos con venta menor que un valor entre dos fechas..."></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label12" runat="server" Text="Fecha inical: " Font-Bold="True" ForeColor="#284E98"></asp:Label>
        <asp:TextBox ID="txtFechaInicial" runat="server"></asp:TextBox>
        <asp:CalendarExtender ID="txtFechaInicial_CalendarExtender" runat="server" TargetControlID="txtFechaInicial">
        </asp:CalendarExtender>
    </p>
    <p>
        <asp:Label ID="Label13" runat="server" Text="Fecha tope: " Font-Bold="True" ForeColor="#284E98"></asp:Label>
        <asp:TextBox ID="txtFechaTope" runat="server"></asp:TextBox>
        <asp:CalendarExtender ID="txtFechaTope_CalendarExtender" runat="server" TargetControlID="txtFechaTope">
        </asp:CalendarExtender>
    </p>
    <p>
        <asp:Label ID="Label14" runat="server" Text="Tope ganancias: " Font-Bold="True" ForeColor="#284E98"></asp:Label>
        <asp:TextBox ID="txtTopeGanancias" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label15" runat="server" ForeColor="Red" Text="*El tope de ganancias es para cada producto entre las fechas dadas."></asp:Label>
        <br>
        <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*Los productos de un pedido cuentan para  el calculo  solo si este fue enviado."></asp:Label>
        <br>
        <asp:Label ID="Label16" runat="server" ForeColor="Red" Text="*La lista se desplegara en orden ascendente segun ganancias con un tope."></asp:Label>
    </p>
    <p>
        <asp:Button ID="btnCalcular" runat="server" Text="Calcular" OnClick="btnCalcular_Click" />
    </p>
    <p>
        <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="Yellow" BorderStyle="Double" Font-Bold="False" HorizontalAlign="Center">
            <Columns>
                <asp:BoundField DataField="CategoriaProducto" HeaderText="Categoria" />
                <asp:BoundField DataField="NombreProd" HeaderText="Nombre" />
                <asp:BoundField DataField="Stock" HeaderText="Stock" />
                <asp:BoundField DataField="StockMin" HeaderText="Stock Min." />
                <asp:ImageField DataImageUrlField="Imagen" HeaderText="Imagen" NullImageUrl="~/Image/404.png">
                    <ControlStyle Height="80px" Width="80px" />
                </asp:ImageField>
                <asp:BoundField DataField="Precio" HeaderText="Precio $" />
                <asp:BoundField DataField="Ganancias" HeaderText="Ganancias para fecha" />
            </Columns>
            <HeaderStyle BackColor="Yellow" ForeColor="#284E98" />
        </asp:GridView>
    </p>
</asp:Content>

