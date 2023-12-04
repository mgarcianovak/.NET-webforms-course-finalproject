<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Views.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <h2 class="mt-2">Productos:</h2>
        <div class="row row-cols-2 px-3">

            <%foreach (Model.Article article in articleList)
                { %>

            <div class="col col-md-4 col-xl-2 p-2">
                <div class="card container h-100">
                    <div class="card-img-container">
                        <img src="<%: article.ImageUrl %>" class="card-img-top" alt="<%: article.Name %>">
                    </div>
                    <div class="card-body">
                        <h5 class="card-title"><%: article.Name %></h5>
                        <h6 class="card-subtitle mb-2 text-body-secondary"><%: article.Brand %></h6>
                        <p class="card-text"><%: article.Description %></p>
                        <a href="#" class="btn btn-primary">Ver más</a>
                    </div>
                </div>
            </div>

            <% } %>
        </div>
    </div>
</asp:Content>
