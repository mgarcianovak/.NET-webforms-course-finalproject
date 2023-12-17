using Controller;
using Model;
using System;

namespace Views
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        public UserController userController = new UserController();

        public User User { get; set; }

        public bool IsLoggedIn { get; set; }

        public bool IsAdmin { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            IsLoggedIn = false;
            IsAdmin = false;
            if (Session["user"] != null)
            {
                IsLoggedIn = true;
                User = userController.GetUserById(int.Parse((string)Session["user"]));
                IsAdmin = User.IsAdmin;
            }

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx", false);
        }
    }
}