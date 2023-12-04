using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class CategoryController
    {
        public List<Category> List()
        {
            List<Category> categoryList = new List<Category>();
            DataAccess dataAccess = new DataAccess();

            try
            {
                dataAccess.SetCommandText("Select Id, Descripcion from CATEGORIAS");
                dataAccess.ReadData();
                while (dataAccess.Reader.Read())
                {
                    Category aux = new Category
                    {
                        Id = (int)dataAccess.Reader["Id"],
                        Name = (string)dataAccess.Reader["Descripcion"]
                    };
                    categoryList.Add(aux);
                }
                return categoryList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
