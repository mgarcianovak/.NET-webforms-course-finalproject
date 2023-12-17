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
    public partial class CreateAccount : System.Web.UI.Page
    {
        private readonly UserController userController = new UserController();

        private bool AreFieldsCorrect()
        {
            bool isSignUpValid = true;

            if (Validation.IsTextBoxEmpty(txtbEmail))
            {
                lblIncorrectData.CssClass = CssClassController.AddClass(lblIncorrectData.CssClass, "d-none");
                isSignUpValid = false;
            }
            if (Validation.IsTextBoxEmpty(txtbPassword))
            {
                lblIncorrectData.CssClass = CssClassController.AddClass(lblIncorrectData.CssClass, "d-none");
                isSignUpValid = false;
            }

            return isSignUpValid;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            if (!AreFieldsCorrect())
            {
                return;
            }
            if (!userController.IsEmailAvailable(txtbEmail.Text))
            {
                lblIncorrectData.CssClass = CssClassController.AddClass(lblUnavailableEmail.CssClass, "d-none");
                return;
            }
            User user = userController.SignUp(txtbEmail.Text, txtbPassword.Text);
            user = userController.Login(user.Email, user.Password);
            Session.Add("user", user.Id.ToString());
            Response.Redirect("Default.aspx", false);
        }
    }
}