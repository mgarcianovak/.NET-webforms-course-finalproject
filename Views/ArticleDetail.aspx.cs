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
    public partial class ArticleDetail : System.Web.UI.Page
    {
        public Article article;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArticleController articleController = new ArticleController();
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

                article = articleController.SearchArticleById(int.Parse(Request.QueryString["id"]));
            }
        }
    }
}