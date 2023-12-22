<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detalles.aspx.cs" Inherits="reparacionweb.detalles" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DETALLES</title>
    <link href="css/gridview.css" rel="stylesheet" />
    <style>
        .main {
            display: flex;
            justify-content: center;
            align-items: center;
        }

        #elemento {
            display: flex;
            justify-content: center;
            align-items: center;
        }

        #button {
            display: flex;
            justify-content: center;
            align-items: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="container text-center">
        <div class="main">
            <br />
            <h1>DETALLES</h1>
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
        <div class="container text-center" id="elemento">
            ID:
            <asp:TextBox ID="tid" class="form-control" runat="server"></asp:TextBox>

            ID Reparacion:
            <asp:DropDownList ID="tidReparacion" class="form-control" runat="server"></asp:DropDownList>

            Fecha Inicio:
            <asp:TextBox ID="tfechaInicio" class="form-control" runat="server"></asp:TextBox>

            Fecha Fin:
            <asp:TextBox ID="tfechaFin" class="form-control" runat="server"></asp:TextBox>

            Descipcion:
            <asp:TextBox ID="tdescripcion" class="form-control" runat="server"></asp:TextBox>


            <br />
            <br />
            <br />
        </div>
        <div class="container text-center" id="button">
            <asp:Button ID="button1" class="btn btn-outline-primary" runat="server" Text="Agregar" OnClick="button1_Click" />
            <asp:Button ID="button2" class="btn btn-outline-secondary" runat="server" Text="Modificar" OnClick="button2_Click" />
            <asp:Button ID="button3" class="btn btn-outline-secondary" runat="server" Text="Atrás" OnClick="button3_Click" />
        </div>
    </form>
</body>
</html>
