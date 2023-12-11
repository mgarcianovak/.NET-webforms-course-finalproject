using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Views
{
    public partial class Default : System.Web.UI.Page
    {
        ArticleController articleController = new ArticleController();
        List<Article> articleList;
        public bool isFilterActive { get; set; }

        private void FillCriterion(string field)
        {
            ddlCriterion.Items.Clear();
            switch (field)
            {
                case "marca":
                    BrandController brandController = new BrandController();
                    foreach (Brand brand in brandController.List())
                    {
                        ddlCriterion.Items.Add(brand.Name);
                    }
                    break;
                case "categoría":
                    CategoryController categoryController = new CategoryController();
                    foreach (Category category in categoryController.List())
                    {
                        ddlCriterion.Items.Add(category.Name);
                    }
                    break;
                case "precio":
                    ddlCriterion.Items.Add("Menor a");
                    ddlCriterion.Items.Add("Mayor a");
                    lblFilter.Text = "Menor a:";
                    break;
                case "nombre":
                    lblFilter.Text = "Nombre:";
                    break;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                articleList = articleController.ListArticles();
                repHomeGrid.DataSource = articleList;
                repHomeGrid.DataBind();
                FillCriterion(ddlField.Text.ToLower());
            }
            isFilterActive = chbxFilters.Checked;
        }

        protected void btnSeeDetail_Click(object sender, EventArgs e)
        {
            Response.Redirect($"ArticleDetail.aspx?id={((Button)sender).CommandArgument}", false);
        }

        protected void chbxFilters_CheckedChanged(object sender, EventArgs e)
        {
            isFilterActive = chbxFilters.Checked;
        }

        protected void ddlField_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCriterion.Text = ddlField.SelectedValue+":";
            FillCriterion(ddlField.Text.ToLower());
        }

        protected void ddlCriterion_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblFilter.Text = ddlCriterion.SelectedValue+":";
        }

        protected void btnApplyFilter_Click(object sender, EventArgs e)
        {
            if (ddlField.SelectedValue.ToLower().Equals("nombre"))
            {
                articleList = articleController.FilterSearch("Nombre", "Contiene", txtbFilter.Text);
            }
            else if (ddlField.SelectedValue.ToLower().Equals("precio"))
            {
                articleList = articleController.FilterSearch("Precio", ddlCriterion.SelectedValue, txtbFilter.Text);
            }
            else
            {
                articleList = articleController.FilterSearch(ddlField.SelectedValue, ddlCriterion.SelectedValue, "");
            }
            repHomeGrid.DataSource = articleList;
            repHomeGrid.DataBind();
        }
    }
}