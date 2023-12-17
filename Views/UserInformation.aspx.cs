using Controller;
using Model;
using System;

namespace Views
{
    public partial class Profile : System.Web.UI.Page
    {
        private readonly UserController userController = new UserController();
        private User user = new User();

        public bool IsModificationEnabled { get; set; }

        private void FillFieldsWithUserInformation()
        {
            user = userController.GetUserById(user.Id);
            txtbEmail.Text = user.Email;
            txtbName.Text = user.Name;
            txtbSurname.Text = user.Surname;
            txtbImageUrl.Text = user.ImageUrl;
        }

        private void ApplyUserInformationChanges()
        {
            user.Name = txtbName.Text;
            user.Surname = txtbSurname.Text;
            user.ImageUrl = txtbImageUrl.Text;
        }

        private void ToggleTextBoxesState()
        {
            txtbName.Enabled = !txtbName.Enabled;
            txtbSurname.Enabled = !txtbSurname.Enabled;
            txtbImageUrl.Enabled = !txtbImageUrl.Enabled;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                try
                {
                    Response.Redirect("Default.aspx");
                }
                catch (System.Threading.ThreadAbortException ex)
                {

                }
            }
            user.Id = int.Parse(Session["user"].ToString());
            if (!IsPostBack)
            {
                user = userController.GetUserById(user.Id);
                IsModificationEnabled = false;
                FillFieldsWithUserInformation();
                txtbImageUrl_TextChanged(sender, e);
            }
        }

        protected void txtbImageUrl_TextChanged(object sender, EventArgs e)
        {
            userImage.ImageUrl = txtbImageUrl.Text;
        }

        protected void btnEnableModification_Click(object sender, EventArgs e)
        {
            ToggleTextBoxesState();
            IsModificationEnabled = true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            FillFieldsWithUserInformation();
            IsModificationEnabled = false;
        }

        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {
            ApplyUserInformationChanges();
            userController.ModifyUserInformation(user);
            FillFieldsWithUserInformation();
            IsModificationEnabled = false;
        }
    }
}