using Controller;
using Model;
using System;

namespace Views
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        public UserController userController = new UserController();
        public User user;
        public bool loggedIn;
        public bool isAdmin;
        protected void Page_Load(object sender, EventArgs e)
        {
            loggedIn = false;
            isAdmin = false;
            if (Session["user"] != null)
            {
                loggedIn = true;
                user = userController.GetUserById(int.Parse((string)Session["user"]));
                isAdmin = user.isAdmin;
            }

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx",false);
        }
    }
}