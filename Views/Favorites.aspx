<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Favorites.aspx.cs" Inherits="Views.Favorites" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <div class="container-fluid px-3 content">
        <div class="row mt-2">
            <div class="col-auto">
                <h2>Mis favoritos:</h2>
            </div>
        </div>
        <%if (favoriteList.Count >= 1)
            {%>
        <div class="row row-cols-2 mt-2">
            <asp:Repeater ID="repHomeGrid" runat="server">
                <ItemTemplate>
                    <div class="col col-md-4 col-xl-3 py-2">
                        <div class="card container h-100">
                            <div class="card-img-container">
                                <img src="<%# Eval("ImageUrl") %>" class="card-img-top" alt="<%# Eval("Name") %>" onerror="imgError(this)">
                            </div>
                            <div class="card-body">
                                <h5 class="card-title text-uppercase"><%# Eval("Name") %></h5>
                                <h6 class="card-subtitle mb-2 text-body-secondary"><%# Eval("Brand") %></h6>
                                <p class="card-text"><%# ((decimal)Eval("Price")).ToString("C2") %></p>
                                <asp:Button Text="Ver más" CssClass="btn btn-secondary mb-2" ID="btnSeeDetail" OnClick="btnSeeDetail_Click" runat="server" CommandArgument='<%# Eval("Id")%>' CommandName="articleId" />
                                <asp:Button Text="Quitar de favoritos" CssClass="btn btn-outline-warning mb-2" ID="btnRemoveFavorite" OnClick="btnRemoveFavorite_Click" CommandArgument='<%# Eval("Id")%>' CommandName="articleId" runat="server" />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <%}
            else
            {%>
        <h5>Aún no tienes favoritos.</h5>
            <%}%>
    </div>
</asp:Content>
