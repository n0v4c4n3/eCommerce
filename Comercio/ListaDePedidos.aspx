﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListaDePedidos.aspx.cs" Inherits="ListaDePedidos" %>

<%@ MasterType TypeName="MasterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <p>
        <asp:Label ID="Label1" runat="server" Text="Lista de pedidos realizados por los usuarios..."></asp:Label>
    </p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="Yellow" BorderStyle="Double" HorizontalAlign="Center">
        <Columns>
            <asp:BoundField DataField="CodPedido" HeaderText="Codigo" />
            <asp:BoundField DataField="Fecha" HeaderText="Fecha Pedido" />
            <asp:BoundField DataField="DireccionEnvio" HeaderText="Direccion Envio" />
            <asp:TemplateField HeaderText="Productos">
                <ItemTemplate>
                    <asp:ListBox ID="lstPedidos" runat="server" DataSource='<%# Eval("ColProductos") %>'></asp:ListBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Monto" HeaderText="Monto $" />
            <asp:CheckBoxField DataField="Estado" Text="Enviado" />
            <asp:CheckBoxField DataField="Cancelado" Text="Cancelado" />
        </Columns>
        <HeaderStyle BackColor="Yellow" ForeColor="#284E98" />
    </asp:GridView>
    <p>
        <asp:Label ID="Label10" runat="server" Text="Codigo de pedido enviado:  " Font-Bold="True" ForeColor="#284E98"></asp:Label>
        <asp:TextBox ID="txtCodigoEnviado" runat="server"></asp:TextBox>
        &nbsp;<asp:Button ID="btnCodigoEnviado" runat="server" Text="Enviado" OnClick="btnCodigoEnviado_Click" />
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="*Solo utilicelo si ya se envio el producto al usuario y no ha sido cancelado." ForeColor="Red"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label11" runat="server" Text="Codigo de pedido a cancelar: " Font-Bold="True" ForeColor="#284E98"></asp:Label>
        <asp:TextBox ID="txtCodigoCancelado" runat="server"></asp:TextBox>
        &nbsp;<asp:Button ID="btnCodigoCancelado" runat="server" Text="Cancelar" OnClick="btnCodigoCancelado_Click"/>
    </p>
    <p>       
        <asp:Label ID="Label3" runat="server" Text="*Solo utilicelo si el pedido no ha sido enviado y desea cancelarlo restaurando el stock de los productos." ForeColor="Red"></asp:Label>
    </p>
</asp:Content>

