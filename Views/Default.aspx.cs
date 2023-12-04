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
    public partial class Default : System.Web.UI.Page
    {
        public List<Article> articleList;

        protected void Page_Load(object sender, EventArgs e)
        {
            ArticleController articleController = new ArticleController();
            articleList = articleController.ListArticles();
        }
    }
}