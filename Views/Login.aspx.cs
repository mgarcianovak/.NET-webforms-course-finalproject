using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Views
{
    public partial class Login : System.Web.UI.Page
    {


        private bool AreFieldsCorrect()
        {
            bool isLoginValid = true;

            if (Validation.IsTextBoxEmpty(txtbEmail))
            {
                isLoginValid = false;
            }
            if (Validation.IsTextBoxEmpty(txtbPassword))
            {
                isLoginValid = false;
            }

            return isLoginValid;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (!AreFieldsCorrect())
            {
                return;
            }

            UserController userController = new UserController();
            User user = userController.Login(txtbEmail.Text, txtbPassword.Text);
            if (user == null)
            {
                txtbEmail.CssClass = Validation.ChangeValidState(txtbEmail.CssClass, false);
                txtbPassword.CssClass = Validation.ChangeValidState(txtbPassword.CssClass, false);
            }
            else
            {
                Session.Add("user", user.Id.ToString());
                Response.Redirect("Default.aspx", false);
            }

        }

        protected void btnCreateNewAccount_Click(object sender, EventArgs e)
        {

        }
    }
}