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

        public List<Favorite> ListFavorites(int userId)
        {
            List<Favorite> favoriteList = new List<Favorite>();
            try
            {
                dataAccess.SetCommandText($"SELECT Id, IdArticulo FROM FAVORITOS WHERE IdUser = {userId}");
                dataAccess.ReadData();
                while (dataAccess.Reader.Read())
                {
                    Favorite aux = new Favorite();
                    aux.Id = (int)dataAccess.Reader["Id"];
                    aux.ArticleId = (int)dataAccess.Reader["IdArticulo"];
                    aux.UserId = userId;
                    favoriteList.Add(aux);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                dataAccess.CloseConnection();
            }

            return favoriteList;
        }

    }
}
