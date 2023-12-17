using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Views
{
    public partial class ArticleManagement : System.Web.UI.Page
    {
        private readonly UserController userController = new UserController();
        private readonly ArticleController articleController = new ArticleController();
        private List<Article> articleList;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || !userController.GetUserById(int.Parse((string)Session["user"])).IsAdmin)
            {
                try
                {
                    Response.Redirect("Default.aspx");
                }
                catch (System.Threading.ThreadAbortException ex)
                {

                }
            }

            if (!IsPostBack)
            {
                FillCriterion(ddlField.Text.ToLower());
            }
            
            IsFilterActive = chbxFilters.Checked;
            articleList = articleController.ListArticles();
            gvArticles.DataSource = articleList;
            gvArticles.DataBind();
        }

        protected void gvArticles_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(gvArticles.SelectedDataKey.Value.ToString());
            Response.Redirect($"ArticleModification.aspx?id={id}", false);
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
            gvArticles.DataSource = articleList;
            gvArticles.DataBind();
        }

        protected void btnCleanFilters_Click(object sender, EventArgs e)
        {
            articleList = articleController.ListArticles();
            gvArticles.DataSource = articleList;
            gvArticles.DataBind();
        }
    }
}