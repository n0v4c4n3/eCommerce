<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListaDeUsuarios.aspx.cs" Inherits="ListaDeUsuarios" %>

<%@ MasterType TypeName="MasterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <p>
        <asp:Label ID="Label8" runat="server" Text="Lista de usuarios a gerenciar:"></asp:Label>
    </p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="Yellow" BorderStyle="Double">
        <Columns>
            <asp:BoundField DataField="User" HeaderText="User" />
            <asp:BoundField DataField="Tipo" HeaderText="Rango" />
            <asp:BoundField DataField="Password" HeaderText="Password" />
            <asp:BoundField DataField="DireccionFacturacion" HeaderText="Dir. Facturacion" />
            <asp:CheckBoxField DataField="Inactivo" Text="Inactivo" />
            <asp:TemplateField HeaderText="Dir. Envio">
                <ItemTemplate>
                    <asp:BulletedList ID="BulletedList1" runat="server" DataSource='<%# Eval("DireccionEnvio") %>'></asp:BulletedList>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle BackColor="Yellow" ForeColor="#284E98" />
    </asp:GridView>
    <p></p>
</asp:Content>

