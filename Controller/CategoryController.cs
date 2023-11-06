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
        public List<Category> list()
        {
            List<Category> categoryList = new List<Category>();
            DataAccess dataAccess = new DataAccess();

            try
            {
                dataAccess.setCommandText("Select Id, Descripcion from CATEGORIAS");
                dataAccess.readData();
                while (dataAccess.Reader.Read())
                {
                    Category aux = new Category();
                    aux.Id = (int)dataAccess.Reader["Id"];
                    aux.Name = (string)dataAccess.Reader["Descripcion"];
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
