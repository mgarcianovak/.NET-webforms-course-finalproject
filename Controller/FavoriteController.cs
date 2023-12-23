using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class FavoriteController
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

        public bool IsFavorite(int userId, int articleId)
        {
            try
            {
                dataAccess.SetCommandText($"SELECT Id FROM FAVORITOS WHERE IdUser = {userId} AND IdArticulo = {articleId}");
                dataAccess.ReadData();

                while (dataAccess.Reader.Read())
                {
                    return true;
                }
                return false;
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

        public void SetFavorite(int userId, int articleId)
        {
            try
            {
                dataAccess.SetCommandText($"INSERT INTO FAVORITOS (IdUser, IdArticulo) VALUES ({userId}, {articleId})");
                dataAccess.ExecuteNonQuery();
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

        public void RemoveFavorite(int userId, int articleId)
        {
            try
            {
                dataAccess.SetCommandText($"DELETE FROM FAVORITOS WHERE IdUser = {userId} AND IdArticulo = {articleId}");
                dataAccess.ExecuteNonQuery();
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

        //public List<Favorite> GetFavorites(int userId, int articleId)
        //{
        //    dataAccess.SetCommandText("SELECT ");

        //    return new List<Favorite>();
        //}

    }
}
