using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class BrandController
    { 
        public List<Brand> list()
        {
            List<Brand> brandList = new List<Brand>();
            DataAccess dataAccess = new DataAccess();

            try
            {
                dataAccess.setCommandText("Select Id, Descripcion from MARCAS");
                dataAccess.readData();
                while (dataAccess.Reader.Read())
                {
                    Brand aux = new Brand();
                    aux.Id = (int)dataAccess.Reader["Id"];
                    aux.Name = (string)dataAccess.Reader["Descripcion"];
                    brandList.Add(aux);
                }
                return brandList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
