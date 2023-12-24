<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Views.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container ms-2 mt-2 content">
        <h2>Iniciar sesión:</h2>
        <div class="row mb-3">
            <div class="col-5">
                <label class="form-label">Correo electrónico:</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtbEmail" placeholder="nombre@ejemplo.com" />
            </div>
        </div>
        <div class="row mb-3">
            <div class="col-5">
                <label class="form-label">Contraseña:</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtbPassword" TextMode="Password" />
            </div>
        </div>
        <asp:Label ID="lblIncorrectData" CssClass="form-label mb-3 d-none" runat="server" Text="Correo o contraseña incorrectos. Por favor, vuelta a intentarlo." ForeColor="Red"></asp:Label>
        <div class="row mt-3">
            <div class="col-5">
                <asp:Button ID="btnLogin" Text="Iniciar sesión" CssClass="btn btn-primary" OnClick="btnLogin_Click" runat="server" />
            </div>
        </div>
        <div class="row mt-2">
            <div class="col-5">
                <label>¿No tienes una cuenta? <a href="SignUp.aspx" class="link-primary link-offset-2 link-underline-opacity-25 link-underline-opacity-100-hover"> Crear una cuenta nueva</a></label>
            </div>
        </div>
    </div>
</asp:Content>
