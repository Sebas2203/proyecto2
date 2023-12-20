<%@ Page Title="" Language="C#" MasterPageFile="~/menu2.Master" AutoEventWireup="true" CodeBehind="equipos.aspx.cs" Inherits="reparacionweb.equipos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
        <br />
        <h1>Equipos</h1>
    </div>
    <div>
        <br />
        <br />
        <asp:GridView runat="server" ID="datagrid" PageSize="10" HorizontalAlign="Center"
            CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
            RowStyle-CssClass="rows" AllowPaging="True" />

        <br />
        <br />
        <br />

    </div>
    <div class="container text-center">
        ID:
    <asp:TextBox ID="tid" class="form-control" runat="server"></asp:TextBox>
        Id Usuario:
    <asp:DropDownList ID="tidUsuario" class="form-control" runat="server"></asp:DropDownList>
        Tipo de Equipo:
    <asp:TextBox ID="ttipoEquipo" class="form-control" runat="server"></asp:TextBox>
        Modelo:
    <asp:TextBox ID="tmodelo" class="form-control" runat="server"></asp:TextBox>
    </div>
    <div class="container text-center">
        <br />
        <br />
        <br />
        <asp:Button ID="button1" class="btn btn-outline-primary" runat="server" Text="Agregar" OnClick="button1_Click" />
        <asp:Button ID="button2" class="btn btn-outline-secondary" runat="server" Text="Borrar" OnClick="button2_Click" />
        <asp:Button ID="button3" runat="server" class="btn btn-outline-danger" Text="Modificar" OnClick="button3_Click" />
        <asp:Button ID="button4" runat="server" class="btn btn-outline-danger" Text="Consultar" OnClick="button4_Click" />


    </div>
</asp:Content>
