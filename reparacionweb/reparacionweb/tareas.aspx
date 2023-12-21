<%@ Page Title="" Language="C#" MasterPageFile="~/menu2.Master" AutoEventWireup="true" CodeBehind="tareas.aspx.cs" Inherits="reparacionweb.asignaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />

        <asp:Button ID="button1" class="btn btn-outline-primary" runat="server" Text="Reparaciones" OnClick="button1_Click" />
        <asp:Button ID="button2" class="btn btn-outline-secondary" runat="server" Text="Asignaciones" OnClick="button2_Click" />
        <asp:Button ID="button3" runat="server" class="btn btn-outline-danger" Text="Detalles" OnClick="button3_Click" />

    </div>
</asp:Content>
