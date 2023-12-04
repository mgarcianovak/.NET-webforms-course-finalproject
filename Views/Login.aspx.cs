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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtbUsername.Text)||string.IsNullOrEmpty(txtbPassword.Text))
            {
                txtbPassword.BorderColor = Color.Red;
                txtbUsername.BorderColor = Color.Red;
            }
        }
    }
}