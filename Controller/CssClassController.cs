using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public static class CssClassController
    {
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

        public static string RemoveClass(string currentClasses, string classToRemove)
        {
            if (currentClasses.Contains(classToRemove))
            {
                return currentClasses.Replace(" " + classToRemove, string.Empty.Trim());
            }
            return currentClasses;
        }

        public static string AddClass(string currentClasses, string classToAdd)
        {
            if (!currentClasses.Contains(classToAdd))
            {
                return currentClasses += " " + classToAdd;
            }
            return currentClasses;
        }
    }
}
