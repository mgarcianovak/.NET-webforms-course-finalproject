using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Views
{
    public partial class Default : System.Web.UI.Page
    {
        readonly ArticleController articleController = new ArticleController();
        readonly FavoriteController favoriteController = new FavoriteController();
        List<Article> articleList;
        public bool IsFilterActive { get; set; }

        private void FillCriterion(string field)
        {
            ddlCriterion.Items.Clear();
            switch (field)
            {
                case "marca":
                    BrandController brandController = new BrandController();
                    ddlCriterion.DataSource = brandController.List();
                    ddlCriterion.DataTextField = "Description";
                    ddlCriterion.DataValueField = "Id";
                    ddlCriterion.DataBind();
                    break;
                case "categoría":
                    CategoryController categoryController = new CategoryController();
                    ddlCriterion.DataSource = categoryController.List();
                    ddlCriterion.DataTextField = "Description";
                    ddlCriterion.DataValueField = "Id";
                    ddlCriterion.DataBind();
                    break;
                case "precio":
                    ddlCriterion.Items.Add("Menor a");
                    ddlCriterion.Items.Add("Mayor a");
                    break;
            }
        }

        private bool IsUserLoggedIn()
        {
            if (Session["user"] == null)
            {
                return false;
            }
            return true;
        }

        private void CheckUserFavorites(List<Article> articleList)
        {
            foreach (Article article in articleList)
            {
                article.IsFavorite = favoriteController.IsFavorite(int.Parse(Session["user"].ToString()), article.Id);
            }
        }

        private void BindRepeaterDataSource()
        {
            repHomeGrid.DataSource = articleList;
            repHomeGrid.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                articleList = articleController.ListArticles();
                if (IsUserLoggedIn())
                {
                    CheckUserFavorites(articleList);
                }
                BindRepeaterDataSource();
                FillCriterion(ddlField.Text.ToLower());
            }
            chbxFilters_CheckedChanged(sender, e);
        }

        protected void btnSeeDetail_Click(object sender, EventArgs e)
        {
            Response.Redirect($"ArticleDetail.aspx?id={((Button)sender).CommandArgument}", false);
        }

        protected void chbxFilters_CheckedChanged(object sender, EventArgs e)
        {
            IsFilterActive = chbxFilters.Checked;
        }

        protected void ddlField_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCriterion.Text = ddlField.SelectedItem.Text + ":";
            FillCriterion(ddlField.Text.ToLower());
        }

        protected void btnApplyFilter_Click(object sender, EventArgs e)
        {
            if (ddlField.SelectedValue.ToLower().Equals("nombre"))
            {
                articleList = articleController.FilterSearch("Nombre", "Contiene", txtbName.Text);
            }
            else if (ddlField.SelectedValue.ToLower().Equals("precio"))
            {
                articleList = articleController.SearchArticlesBetweenPriceRange(decimal.Parse(txtbGreaterThan.Text), decimal.Parse(txtbLessThan.Text));
            }
            else
            {
                articleList = articleController.FilterSearch(ddlField.SelectedValue, ddlCriterion.SelectedValue, "");
            }
            CheckUserFavorites(articleList);
            BindRepeaterDataSource();
        }

        protected void btnCleanFilters_Click(object sender, EventArgs e)
        {
            articleList = articleController.ListArticles();
            CheckUserFavorites(articleList);
            BindRepeaterDataSource();
        }

        protected void btnAddFavorite_Click(object sender, EventArgs e)
        {
            if (!IsUserLoggedIn())
            {
                Response.Redirect("Login.aspx");
                return;
            }
            if (favoriteController.IsFavorite(int.Parse(Session["user"].ToString()), int.Parse(((Button)sender).CommandArgument)))
            {
                favoriteController.RemoveFavorite(int.Parse(Session["user"].ToString()), int.Parse(((Button)sender).CommandArgument));
            }
            else
            {
                favoriteController.SetFavorite(int.Parse(Session["user"].ToString()), int.Parse(((Button)sender).CommandArgument));
            }
            btnApplyFilter_Click(sender, e);
        }
    }
}