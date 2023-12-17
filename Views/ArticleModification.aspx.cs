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
    public partial class ArticleModification : System.Web.UI.Page
    {
        public Article article;
        public string pageTitle = "Modificar artículo:";

        private readonly ArticleController articleController = new ArticleController();
        private readonly BrandController brandController = new BrandController();
        private readonly CategoryController categoryController = new CategoryController();
        private readonly UserController userController = new UserController();

        private void FillFieldsWithArticleData()
        {
            txtbId.Text = article.Id.ToString();
            txtbCode.Text = article.Code;
            txtbName.Text = article.Name;
            txtbDescription.Text = article.Description;
            LoadDropDownList(ddlBrand, brandController.List());
            ddlBrand.SelectedValue = article.Brand.Id.ToString();
            LoadDropDownList(ddlCategory, categoryController.List());
            ddlCategory.SelectedValue = article.Category.Id.ToString();
            txtbImageUrl.Text = article.ImageUrl;
            txtbPrice.Text = article.Price.ToString();
        }

        private bool AreFieldsCorrect()
        {
            bool isModificationValid = true;

            if (Validation.IsTextBoxEmpty(txtbCode))
            {
                isModificationValid = false;
            }
            if (Validation.IsTextBoxEmpty(txtbName))
            {
                isModificationValid = false;
            }
            if (Validation.IsTextBoxEmpty(txtbDescription))
            {
                isModificationValid = false;
            }
            if (Validation.IsTextBoxEmpty(txtbImageUrl))
            {
                isModificationValid = false;
            }
            if (Validation.IsTextBoxEmpty(txtbPrice))
            {
                isModificationValid = false;
            }

            return isModificationValid;
        }

        private void LoadDropDownList<T>(DropDownList dropDownList, List<T> list)
        {
            dropDownList.DataSource = list;
            dropDownList.DataTextField = "Description";
            dropDownList.DataValueField = "Id";
            dropDownList.DataBind();
        }

        private Article CreateModifiedArticle()
        {
            Article modifiedArticle = new Article
            {
                Id = int.Parse(txtbId.Text),
                Code = txtbCode.Text,
                Name = txtbName.Text,
                Description = txtbDescription.Text,
                Brand = brandController.GetBrandById(int.Parse(ddlBrand.SelectedValue)),
                Category = categoryController.GetCategoryById(int.Parse(ddlCategory.SelectedValue)),
                ImageUrl = txtbImageUrl.Text,
                Price = decimal.Parse(txtbPrice.Text)
            };

            return modifiedArticle;
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
                if (Request.QueryString["id"] != null)
                {
                    article = articleController.GetArticleById(int.Parse(Request.QueryString["id"]));
                    FillFieldsWithArticleData();
                    txtbImageUrl_TextChanged(sender, e);
                }
                else
                {
                    btnModify.Text = "Agregar";
                    pageTitle = "Agregar artículo:";
                    txtbId.Text = articleController.GetNextId().ToString();
                    LoadDropDownList(ddlBrand, brandController.List());
                    LoadDropDownList(ddlCategory, categoryController.List());
                }
            }
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AreFieldsCorrect())
                {
                    lblCompleteFields.CssClass = "form-label";
                    return;
                }
                if (Request.QueryString["id"] != null)
                {
                    articleController.ModifyArticle(CreateModifiedArticle());
                }
                else
                {
                    articleController.AddArticle(CreateModifiedArticle());
                }
                Response.Redirect("ArticleManagement.aspx");
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!chbxDelete.Checked)
            {
                chbxDelete.ForeColor = System.Drawing.Color.Red;
                return;
            }
            articleController.DeleteArticle(int.Parse(txtbId.Text));
            try
            {
                Response.Redirect("ArticleManagement.aspx");
            }
            catch (Exception ex)
            {

            }
        }

        protected void txtbImageUrl_TextChanged(object sender, EventArgs e)
        {
            articleImage.ImageUrl = txtbImageUrl.Text;
        }
    }
}