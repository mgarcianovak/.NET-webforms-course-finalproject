<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ArticleModification.aspx.cs" Inherits="Views.ArticleModification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <div class="container-fluid">
        <h2 class="my-2"><%: pageTitle %></h2>
        <div class="row">
            <div class="col-6 col-md-5 col-lg-4 col-xl-3">
                <label class="form-label">Id:</label>
                <asp:TextBox ID="txtbId" CssClass="form-control mb-2" Enabled="false" runat="server" />
                <label class="form-label">Código:</label>
                <asp:TextBox ID="txtbCode" CssClass="form-control mb-2" runat="server" />
                <label class="form-label">Nombre:</label>
                <asp:TextBox ID="txtbName" CssClass="form-control mb-2" runat="server" />
                <label class="form-label">Descripción:</label>
                <asp:TextBox ID="txtbDescription" TextMode="MultiLine" CssClass="form-control mb-2" runat="server" />
                <label class="form-label">Marca:</label>
                <asp:DropDownList ID="ddlBrand" CssClass="form-control mb-2" runat="server"></asp:DropDownList>
                <label class="form-label">Categoría:</label>
                <asp:DropDownList ID="ddlCategory" CssClass="form-control mb-2" runat="server"></asp:DropDownList>
                <label class="form-label">Precio:</label>
                <asp:TextBox ID="txtbPrice" CssClass="form-control mb-2" runat="server" />
                <hr />
                <asp:Button Text="Modificar" ID="btnModify" CssClass="btn btn-primary" OnClick="btnModify_Click" runat="server" />
                <asp:Button Text="Eliminar" ID="btnDelete" CssClass="btn btn-danger" OnClick="btnDelete_Click" runat="server" />
                <asp:CheckBox Text="Confirmar eliminación" CssClass="form-check-input" ID="chbxDelete" runat="server" />
            </div>
            <div class="col-6 col-md-5 col-lg-4 col-xl-3">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <label class="form-label">Url imagen:</label>
                        <asp:TextBox ID="txtbImageUrl" TextMode="MultiLine" OnTextChanged="txtbImageUrl_TextChanged" CssClass="form-control mb-2" AutoPostBack="true" runat="server" />
                        <div class="text-center align-items-center">
                            <asp:Image ImageUrl="<%# txtbImageUrl.Text %>" ID="articleImage" onerror="imgError(this)" runat="server" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <asp:Label Text="Por favor, complete todos los campos." ForeColor="#ff0000" ID="lblCompleteFields" CssClass="form-label d-none" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
