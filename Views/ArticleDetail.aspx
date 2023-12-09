<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ArticleDetail.aspx.cs" Inherits="Views.ArticleDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
        <div class="card w-75 mx-auto my-4">
            <div class="row">
                <div class="col-md-8">
                    <img src="<%: article.ImageUrl %>" class="img-fluid" alt="<%: article.Name %>">
                </div>
                <div class="col-md-4">
                    <div class="card-body text-start">
                        <h2 class="card-title text-uppercase"><%: article.Name %></h2>
                        <p class="card-text"><%: article.Description %></p>
                        <p class="card-text"><%: article.Price.ToString("C2") %></p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
