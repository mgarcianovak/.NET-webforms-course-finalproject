<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ArticleDetail.aspx.cs" Inherits="Views.ArticleDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center content">
        <div class="card w-75 mx-auto my-4">
            <div class="row">
                <div class="col col-lg-6">
                    <img src="<%: article.ImageUrl %>" class="img-fluid" alt="<%: article.Name %>" onerror="this.onerror=null; this.src='Photos/article-default.jpg'">
                </div>
                <div class="col-lg-6">
                    <div class="card-body text-start h-100 d-flex flex-column">
                        <h2 class="card-title text-uppercase"><%: article.Name %></h2>
                        <h3 class="card-subtitle mb-2 text-body-secondary"><%: article.Brand %></h3>
                        <p class="card-text flex-grow-1"><%: article.Description %></p>
                        <div class="d-flex justify-content-between">
                            <p class="text-body-secondary mb-0 mt-auto"><%: article.Price.ToString("C2") %></p>
                            <asp:Button Text="Agregar a favoritos" CssClass="btn btn-outline-warning mb-0" ID="btnAddFavorite" OnClick="btnAddFavorite_Click" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
