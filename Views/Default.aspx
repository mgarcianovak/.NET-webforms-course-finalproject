<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Views.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <h2 class="mt-2">Productos:</h2>
        <div class="row row-cols-2 px-3">
            <asp:Repeater ID="repHomeGrid" runat="server">
                <ItemTemplate>
                    <div class="col col-md-4 col-xl-2 p-2">
                        <div class="card container h-100">
                            <div class="card-img-container">
                                <img src="<%# Eval("ImageUrl") %>" class="card-img-top" alt="<%# Eval("Name") %>">
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
