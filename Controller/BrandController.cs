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
        public List<Brand> List()
        {
            List<Brand> brandList = new List<Brand>();
            DataAccess dataAccess = new DataAccess();

            try
            {
                dataAccess.SetCommandText("Select Id, Descripcion from MARCAS");
                dataAccess.ReadData();
                while (dataAccess.Reader.Read())
                {
                    Brand aux = new Brand
                    {
                        Id = (int)dataAccess.Reader["Id"],
                        Name = (string)dataAccess.Reader["Descripcion"]
                    };
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
