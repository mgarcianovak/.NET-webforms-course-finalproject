<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Views.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container ms-2 mt-2">
        <h2>Iniciar sesión:</h2>
        <div class="row mb-3">
            <div class="col-5">
                <label class="form-label">Correo electrónico:</label>
                <asp:TextBox runat="server" class="form-control" ID="txtbUsername" placeholder="nombre@ejemplo.com" />
            </div>
        </div>
        <div class="row mb-3">
            <div class="col-5">
                <label class="form-label">Contraseña:</label>
                <asp:TextBox runat="server" class="form-control" ID="txtbPassword" TextMode="Password" />
            </div>
        </div>
        <%if (txtbPassword.BorderColor == System.Drawing.Color.Red || txtbUsername.BorderColor == System.Drawing.Color.Red)
            {%>
        <div class="row mb3">
            <div class="col-5">
                <p>Ingrese los campos requeridos</p>
            </div>
        </div>
        <%} %>
        <div class="row mb-3">
            <div class="col-5">
                <asp:Button ID="btnLogin" Text="Ingresar" CssClass="btn btn-primary" OnClick="btnLogin_Click" runat="server" />
            </div>
        </div>
        <div class="row">
            <div class="col-5">
                <asp:Button ID="btnCreateNewAccount" Text="Crear una nueva cuenta" CssClass="btn btn-outline-primary" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
