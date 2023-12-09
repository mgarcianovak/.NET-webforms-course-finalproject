using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;
using System.Web.UI.WebControls;

namespace Model
{
    public static class Validation
    {
        public static bool IsTextBoxEmpty(TextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.CssClass = ChangeValidState(textBox.CssClass, false);
                return true;
            }

            textBox.CssClass = ChangeValidState(textBox.CssClass, true);
            return false;
        }

        public static string ChangeValidState(string currentClasses, bool isValid)
        {
            if (isValid)
            {
                currentClasses = RemoveClass(currentClasses, "is-invalid");
                currentClasses = AddClass(currentClasses, "is-valid");
            }
            else
            {
                currentClasses = RemoveClass(currentClasses, "is-valid");
                currentClasses = AddClass(currentClasses, "is-invalid");
            }
            return currentClasses;
        }

        private static string RemoveClass(string currentClasses, string classToRemove)
        {
            if (currentClasses.Contains(classToRemove))
            {
                return currentClasses.Replace(" "+classToRemove, string.Empty.Trim());
            }
            return currentClasses;
        }

        private static string AddClass(string currentClasses, string classToAdd)
        {
            if (!currentClasses.Contains(classToAdd))
            {
                return currentClasses += " " + classToAdd;
            }
            return currentClasses;
        }
    }
}
