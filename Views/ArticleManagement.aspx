<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ArticleManagement.aspx.cs" Inherits="Views.ArticleManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid px-5">
        <h2 class="m-2">Listado de artículos</h2>
        <div class="row my-2">
            <div class="col-auto">
                <asp:CheckBox Text="Mostrar filtros" CssClass="form-control ps-2" OnCheckedChanged="chbxFilters_CheckedChanged" AutoPostBack="true" ID="chbxFilters" runat="server" />
            </div>
        </div>
        <asp:ScriptManager runat="server" />
        <%if (IsFilterActive)
            {%>
        <asp:UpdatePanel ID="upFilters" runat="server">
            <ContentTemplate>
                <div class="row mb-2">
                    <div class="col-6 col-md-4 col-lg-3">
                        <label>Filtrar por:</label>
                        <asp:DropDownList ID="ddlField" CssClass="form-control mt-2" OnSelectedIndexChanged="ddlField_SelectedIndexChanged" AutoPostBack="true" runat="server">
                            <asp:ListItem Text="Nombre" />
                            <asp:ListItem Text="Marca" />
                            <asp:ListItem Text="Categoría" />
                            <asp:ListItem Text="Precio" />
                        </asp:DropDownList>
                    </div>

                    <%if (!(ddlField.SelectedValue.ToLower().Equals("nombre")) && !(ddlField.SelectedValue.ToLower().Equals("precio")))
                        {
                    %>
                    <div class="col-6 col-md-4 col-lg-3">
                        <asp:Label ID="lblCriterion" Text="Marca:" runat="server" />
                        <asp:DropDownList ID="ddlCriterion" CssClass="form-control mt-2" runat="server">
                        </asp:DropDownList>
                    </div>
                    <%}
                        else if (ddlField.SelectedValue.ToLower().Equals("nombre"))
                        {
                    %>
                    <div class="col col-md-4 col-lg-3">
                        <asp:Label ID="lblNameFilter" Text="Nombre:" runat="server" />
                        <asp:TextBox CssClass="form-control mt-2" ID="txtbName" runat="server" />
                    </div>
                    <%
                        }%>
                    <%else
                        { %>
                    <div class="col col-md-4 col-lg-3">
                        <asp:Label ID="lblGreaterThan" Text="Desde:" runat="server" />
                        <asp:TextBox CssClass="form-control mt-2" ID="txtbGreaterThan" runat="server" />
                    </div>
                    <div class="col col-md-4 col-lg-3">
                        <asp:Label ID="lblLessThan" Text="Hasta:" runat="server" />
                        <asp:TextBox CssClass="form-control mt-2" ID="txtbLessThan" runat="server" />
                    </div>
                    <% }%>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="row mb-2">
            <div class="col col-lg-3 mt-auto">
                <asp:Button ID="btnApplyFilter" CssClass="btn btn-primary w-100 mt-2" Text="Filtrar" OnClick="btnApplyFilter_Click" runat="server" />
            </div>
            <div class="col col-md-4 col-lg-3 mt-auto">
                <asp:Button ID="btnCleanFilters" CssClass="btn btn-outline-primary w-100 mt-2" Text="Limpiar Filtros" OnClick="btnCleanFilters_Click" runat="server" />
            </div>
        </div>
        <%} %>
        <div class="table-responsive">
            <asp:GridView ID="gvArticles" CssClass="table table-striped" HeaderStyle-Font-Bold="true" DataKeyNames="Id" runat="server" OnSelectedIndexChanged="gvArticles_SelectedIndexChanged" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id" />
                    <asp:BoundField DataField="Code" HeaderText="Código" SortExpression="Code" />
                    <asp:BoundField DataField="Name" HeaderText="Nombre" SortExpression="Name" />
                    <asp:BoundField DataField="Description" HeaderText="Descripción" SortExpression="Description" />
                    <asp:BoundField DataField="Brand" HeaderText="Marca" SortExpression="Brand" />
                    <asp:BoundField DataField="Category" HeaderText="Categoría" SortExpression="Category" />
                    <asp:BoundField DataField="ImageUrl" HeaderText="Url de imagen" SortExpression="UrlImage" />
                    <asp:BoundField DataField="Price" HeaderText="Precio" SortExpression="Price" />
                    <asp:CommandField ShowSelectButton="true" SelectText="Modificar" HeaderText="Modificación" />
                </Columns>
            </asp:GridView>
        </div>
        <a href="ArticleModification.aspx" class="btn btn-primary mt-1">Agregar artículo</a>
    </div>
</asp:Content>
