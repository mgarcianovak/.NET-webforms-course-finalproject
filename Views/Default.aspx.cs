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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArticleController articleController = new ArticleController();
                repHomeGrid.DataSource = articleController.ListArticles();
                repHomeGrid.DataBind();
            }
        }

        protected void btnSeeDetail_Click(object sender, EventArgs e)
        {
            Response.Redirect($"ArticleDetail.aspx?id={((Button)sender).CommandArgument}", false);
        }
    }
}