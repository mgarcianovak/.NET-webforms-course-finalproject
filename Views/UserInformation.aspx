<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="UserInformation.aspx.cs" Inherits="Views.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-2 content">
        <asp:ScriptManager runat="server" />
        <div class="row">
            <div class="col col-md-5 col-lg-4">
                <label>Correo electrónico:</label>
                <asp:TextBox ID="txtbEmail" Enabled="false" CssClass="form-control mt-2" runat="server" />
                <label>Nombre:</label>
                <asp:TextBox ID="txtbName" Enabled="false" CssClass="form-control mt-2" runat="server" />
                <label>Apellido:</label>
                <asp:TextBox ID="txtbSurname" Enabled="false" CssClass="form-control mt-2" runat="server" />
            </div>
            <div class="col col-md-5 col-lg-4">
                <label>Imagen de perfil:</label>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtbImageUrl" Enabled="false" AutoPostBack="true" CssClass="form-control mt-2" OnTextChanged="txtbImageUrl_TextChanged" runat="server" />
                        <asp:Image ImageUrl="<%# txtbImageUrl.Text %>" ID="userImage" onerror="imgError(this)" ClientIDMode="Static" CssClass="mt-2" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="row">
            <%if (!IsModificationEnabled)
                {%>
            <div class="col">
                <asp:Button Text="Modificar información" ID="btnEnableModification" CssClass="btn btn-primary mt-2" OnClick="btnEnableModification_Click" runat="server" />
            </div>
            <%}%>
            <%else
                {%>
            <div class="col">
                <asp:Button Text="Guardar cambios" ID="btnSaveChanges" CssClass="btn btn-outline-primary mt-2" OnClick="btnSaveChanges_Click" runat="server" />
            </div>
            <div class="col">
                <asp:Button Text="Cancelar" ID="btnCancel" CssClass="btn btn-outline-danger mt-2" OnClick="btnCancel_Click" runat="server" />
            </div>
            <%}%>
        </div>
    </div>
</asp:Content>
