using Controller;
using Model;
using System;

namespace Views
{
    public partial class Login : System.Web.UI.Page
    {


        private bool AreFieldsCorrect()
        {
            bool isLoginValid = true;

            if (Validation.IsTextBoxEmpty(txtbEmail))
            {
                lblIncorrectData.CssClass = CssClassController.AddClass(lblIncorrectData.CssClass, "d-none");
                isLoginValid = false;
            }
            if (Validation.IsTextBoxEmpty(txtbPassword))
            {
                lblIncorrectData.CssClass = CssClassController.AddClass(lblIncorrectData.CssClass, "d-none");
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
                lblIncorrectData.CssClass = CssClassController.RemoveClass(lblIncorrectData.CssClass, "d-none");
                txtbEmail.CssClass = CssClassController.ChangeValidState(txtbEmail.CssClass, false);
                txtbPassword.CssClass = CssClassController.ChangeValidState(txtbPassword.CssClass, false);
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