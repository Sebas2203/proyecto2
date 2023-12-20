<%@ Page Title="" Language="C#" MasterPageFile="~/menu2.Master" AutoEventWireup="true" CodeBehind="usuarios.aspx.cs" Inherits="reparacionweb.usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
        <br />
        <h1>Usuarios</h1>
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
        Nombre:
        <asp:TextBox ID="tnombre" class="form-control" runat="server"></asp:TextBox>
        Correo:
        <asp:TextBox ID="tcorreo" class="form-control" runat="server"></asp:TextBox>
        Telefono:
        <asp:TextBox ID="ttelefono" class="form-control" runat="server"></asp:TextBox>
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
