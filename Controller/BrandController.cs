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
        private readonly DataAccess dataAccess = new DataAccess();

        public List<Brand> List()
        {
            List<Brand> brandList = new List<Brand>();
            try
            {
                dataAccess.SetCommandText("Select Id, Descripcion from MARCAS");
                dataAccess.ReadData();
                while (dataAccess.Reader.Read())
                {
                    Brand aux = new Brand
                    {
                        Id = (int)dataAccess.Reader["Id"],
                        Description = (string)dataAccess.Reader["Descripcion"]
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

        public Brand GetBrandById(int id)
        {
            Brand brand = new Brand();
            try
            {
                dataAccess.SetCommandText($"SELECT Descripcion FROM MARCAS WHERE Id = {id}");
                dataAccess.ReadData();

                while (dataAccess.Reader.Read())
                {
                    brand.Id = id;
                    brand.Description = (string)dataAccess.Reader["Descripcion"];
                }
                return brand;
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
