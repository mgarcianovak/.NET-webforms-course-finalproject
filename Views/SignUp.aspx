<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Views.CreateAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container ms-2 mt-2 content">
        <h2>Crear una cuenta nueva:</h2>
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
        <asp:Label ID="lblUnavailableEmail" CssClass="form-label mb-3 d-none" runat="server" Text="El correo electrónico ya está en uso. Pruebe iniciando sesión." ForeColor="Red"></asp:Label>
        <div class="row mt-3">
            <div class="col-5">
                <asp:Button ID="btnCreateAccount" Text="Crear cuenta" CssClass="btn btn-primary" OnClick="btnCreateAccount_Click" runat="server" />
            </div>
        </div>
        <div class="row mt-2">
            <div class="col-5">
                <label>¿Ya tienes una cuenta? <a href="Login.aspx" class="link-primary link-offset-2 link-underline-opacity-25 link-underline-opacity-100-hover">Iniciar sesión</a></label>
            </div>
        </div>
    </div>
</asp:Content>
