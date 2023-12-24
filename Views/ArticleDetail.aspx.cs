using Controller;
using Model;
using System;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Views
{
    public partial class ArticleDetail : System.Web.UI.Page
    {
        private readonly ArticleController articleController = new ArticleController();
        private readonly FavoriteController favoriteController = new FavoriteController();
        public Article article = new Article();
        private bool IsUserLoggedIn()
        {
            if (Session["user"] == null)
            {
                return false;
            }
            return true;
        }

        private void CheckFavorite()
        {
            article.IsFavorite = favoriteController.IsFavorite(int.Parse(Session["user"].ToString()), article.Id);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] == null)
                {
                    try
                    {
                        Response.Redirect("Default.aspx");
                    }
                    catch (System.Threading.ThreadAbortException ex)
                    {

                    }
                }
            }
            article = articleController.GetArticleById(int.Parse(Request.QueryString["id"]));
            if (IsUserLoggedIn())
            {
                CheckFavorite();
                btnAddFavorite.Text = article.IsFavorite ? "Quitar de favoritos" : "Agregar a favoritos";
            }
        }

        protected void btnAddFavorite_Click(object sender, EventArgs e)
        {
            if (!IsUserLoggedIn())
            {
                Response.Redirect("Login.aspx");
                return;
            }
            if (favoriteController.IsFavorite(int.Parse(Session["user"].ToString()), article.Id))
            {
                favoriteController.RemoveFavorite(int.Parse(Session["user"].ToString()), article.Id);
            }
            else
            {
                favoriteController.SetFavorite(int.Parse(Session["user"].ToString()), article.Id);
            }
            CheckFavorite();
            btnAddFavorite.Text = article.IsFavorite ? "Quitar de favoritos" : "Agregar a favoritos";
        }
    }
}