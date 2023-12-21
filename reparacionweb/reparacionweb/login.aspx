<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="reparacionweb.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LOGIN</title>
    <link href="css/login.css" rel="stylesheet" />
</head>
<body>
    <form id="loginForm" runat="server" method="post">
        <div class="container">
            <label for="usuario"><b>Usuario</b></label>
            <asp:TextBox ID="tusuario" runat="server" placeholder="Ingresa tu correo" name="username"></asp:TextBox>

            <label for="password"><b>Contraseña</b></label>
            <asp:TextBox ID="tclave" runat="server" placeholder="Ingresa tu contraseña" name="password" TextMode="Password"></asp:TextBox>

            <asp:Button ID="btnlogin" runat="server" Text="Login" name="button" class="button" OnClick="btnlogin_Click" />
        </div>
    </form>
</body>
</html>
