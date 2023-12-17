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
        private readonly DataAccess dataAccess = new DataAccess();
        public List<Category> List()
        {
            List<Category> categoryList = new List<Category>();

            try
            {
                dataAccess.SetCommandText("Select Id, Descripcion from CATEGORIAS");
                dataAccess.ReadData();
                while (dataAccess.Reader.Read())
                {
                    Category aux = new Category
                    {
                        Id = (int)dataAccess.Reader["Id"],
                        Description = (string)dataAccess.Reader["Descripcion"]
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

        public Category GetCategoryById(int id)
        {
            Category category = new Category();
            try
            {
                dataAccess.SetCommandText($"SELECT Descripcion FROM CATEGORIAS WHERE Id = {id}");
                dataAccess.ReadData();

                while (dataAccess.Reader.Read())
                {
                    category.Id = id;
                    category.Description = (string)dataAccess.Reader["Descripcion"];
                }
                return category;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dataAccess.CloseConnection();
            }
        }
    }
}
