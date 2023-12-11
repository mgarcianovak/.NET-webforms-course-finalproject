<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Views.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <div class="container-fluid">
        <div class="row mt-2">
            <div class="col-6 col-md-4 col-lg-2">
                <asp:CheckBox Text="Mostrar filtros" CssClass="form-control ps-2" OnCheckedChanged="chbxFilters_CheckedChanged" AutoPostBack="true" ID="chbxFilters" runat="server" />
            </div>
        </div>
        <%if (isFilterActive)
            {%>
        <asp:UpdatePanel ID="upFilters" runat="server">
            <ContentTemplate>
                <div class="row">
                    <div class="col-6 col-md-4 col-lg-3">
                        <label>Filtrar por:</label>
                        <asp:DropDownList ID="ddlField" CssClass="form-control mt-2" OnSelectedIndexChanged="ddlField_SelectedIndexChanged" AutoPostBack="true" runat="server">
                            <asp:ListItem Text="Nombre" />
                            <asp:ListItem Text="Marca" />
                            <asp:ListItem Text="Categoría" />
                            <asp:ListItem Text="Precio" />
                        </asp:DropDownList>
                    </div>

                    <%if (!(ddlField.SelectedValue.ToLower().Equals("nombre")))
                        {  %>
                    <div class="col-6 col-md-4 col-lg-3">
                        <asp:Label ID="lblCriterion" Text="Marca:" runat="server" />
                        <asp:DropDownList ID="ddlCriterion" OnSelectedIndexChanged="ddlCriterion_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control mt-2" runat="server">
                        </asp:DropDownList>
                    </div>
                    <%} %>
                    <%if (ddlField.SelectedValue.ToLower().Equals("precio") || ddlField.SelectedValue.ToLower().Equals("nombre"))
                        { %>
                    <div class="col col-md-4 col-lg-3">
                        <asp:Label ID="lblFilter" Text="Menor a:" runat="server" />
                        <asp:TextBox CssClass="form-control mt-2" ID="txtbFilter" runat="server" />
                    </div>
                    <% }%>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="row">
            <div class="col col-lg-3 mt-auto">
                <asp:Button ID="btnApplyFilter" CssClass="btn btn-secondary w-100 mt-2" Text="Filtrar" OnClick="btnApplyFilter_Click" runat="server" />
            </div>
        </div>
        <% }%>
        <div class="row row-cols-2 px-3">
            <asp:Repeater ID="repHomeGrid" runat="server">
                <ItemTemplate>
                    <div class="col col-md-4 col-xl-2 p-2">
                        <div class="card container h-100">
                            <div class="card-img-container">
                                <img src="<%# Eval("ImageUrl") %>" class="card-img-top" alt="<%# Eval("Name") %>" onerror="this.onerror=null; this.src='Photos/article-default.jpg'">
                            </div>
                            <div class="card-body">
                                <h5 class="card-title text-uppercase"><%# Eval("Name") %></h5>
                                <h6 class="card-subtitle mb-2 text-body-secondary"><%# Eval("Brand") %></h6>
                                <p class="card-text"><%# ((decimal)Eval("Price")).ToString("C2") %></p>
                                <asp:Button Text="Ver más" CssClass="btn btn-secondary" ID="btnSeeDetail" OnClick="btnSeeDetail_Click" runat="server" CommandArgument='<%# Eval("Id")%>' CommandName="articleId" />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
