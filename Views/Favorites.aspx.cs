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
    public partial class Favorites : System.Web.UI.Page
    {
        readonly ArticleController articleController = new ArticleController();
        readonly FavoriteController favoriteController = new FavoriteController();
        List<Article> articleList;
        public List<Favorite> favoriteList = new List<Favorite>();


        private bool IsUserLoggedIn()
        {
            if (Session["user"] == null)
            {
                return false;
            }
            return true;
        }

        private void BindRepeaterDataSource()
        {
            repHomeGrid.DataSource = articleList;
            repHomeGrid.DataBind();
        }

        private void RefreshFavorites()
        {
            favoriteList = favoriteController.ListFavorites(int.Parse(Session["user"].ToString()));
            articleList = articleController.ListFavoriteArticles(favoriteList);
            BindRepeaterDataSource();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsUserLoggedIn())
                {
                    Response.Redirect("Default.aspx");
                    return;
                }
                RefreshFavorites();
            }
        }

        protected void btnRemoveFavorite_Click(object sender, EventArgs e)
        {
            favoriteController.RemoveFavorite(int.Parse(Session["user"].ToString()), int.Parse(((Button)sender).CommandArgument));
            RefreshFavorites();
        }

        protected void btnSeeDetail_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect($"ArticleDetail.aspx?id={((Button)sender).CommandArgument}");
            }
            catch (System.Threading.ThreadAbortException ex)
            {

            }
        }
    }
}