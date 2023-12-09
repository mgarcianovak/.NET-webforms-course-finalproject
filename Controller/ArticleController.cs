using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public class ArticleController
    {
        private readonly DataAccess dataAccess = new DataAccess();

        public List<Article> ListArticles()
        {
            List<Article> articleList = new List<Article>();
            try
            {
                dataAccess.SetCommandText("SELECT a.Id, Codigo, Nombre, a.Descripcion, c.Descripcion Categoria, IdCategoria, m.Descripcion Marca, IdMarca, ImagenUrl, Precio " +
                    "FROM ARTICULOS a, CATEGORIAS c, MARCAS m " +
                    "WHERE IdMarca=m.Id AND IdCategoria = c.Id");
                dataAccess.ReadData();

                while (dataAccess.Reader.Read())
                {
                    Article aux = new Article
                    {
                        Id = (int)dataAccess.Reader["Id"],
                        Code = (string)dataAccess.Reader["Codigo"],
                        Name = (string)dataAccess.Reader["Nombre"],
                        Description = (string)dataAccess.Reader["Descripcion"]
                    };
                    aux.Brand.Name = (string)dataAccess.Reader["Marca"];
                    aux.Brand.Id = (int)dataAccess.Reader["IdMarca"];
                    aux.Category.Id = (int)dataAccess.Reader["IdCategoria"];
                    aux.Category.Name = (string)dataAccess.Reader["Categoria"];
                    if (!(dataAccess.Reader["ImagenUrl"] is DBNull))
                    {
                        aux.ImageUrl = (string)dataAccess.Reader["ImagenUrl"];
                    }
                    aux.Price = (Decimal)dataAccess.Reader["Precio"];
                    articleList.Add(aux);
                }
                return articleList;
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

        public List<Article> FilterSearch(string field, string criterion, string filter)
        {
            string query = "Select a.Id, Codigo, Nombre, a.Descripcion, c.Descripcion Categoria, IdCategoria, m.Descripcion Marca, IdMarca, ImagenUrl, Precio from ARTICULOS a, CATEGORIAS c, MARCAS m Where IdMarca=m.Id and IdCategoria = c.Id and ";
            List<Article> filteredList = new List<Article>();

            switch (field)
            {
                case "Id":
                    query += FilterQuery("a.Id ", criterion, filter);
                    break;
                case "Código":
                    query += FilterQuery("Codigo ", criterion, filter);
                    break;
                case "Nombre":
                    query += FilterQuery("Nombre ", criterion, filter);
                    break;
                case "Precio":
                    query += FilterQuery("Precio ", criterion, filter);
                    break;
                case "Marca":
                    query += "m.Descripcion = '" + criterion + "'";
                    break;
                case "Categoría":
                    query += "c.Descripcion = '" + criterion + "'";
                    break;
            }

            try
            {
                dataAccess.SetCommandText(query);
                dataAccess.ReadData();
                while (dataAccess.Reader.Read())
                {
                    Article aux = new Article
                    {
                        Id = (int)dataAccess.Reader["Id"],
                        Code = (string)dataAccess.Reader["Codigo"],
                        Name = (string)dataAccess.Reader["Nombre"],
                        Description = (string)dataAccess.Reader["Descripcion"]
                    };
                    aux.Category.Name = (string)dataAccess.Reader["Categoria"];
                    aux.Category.Id = (int)dataAccess.Reader["IdCategoria"];
                    aux.Brand.Name = (string)dataAccess.Reader["Marca"];
                    aux.Brand.Id = (int)dataAccess.Reader["IdMarca"];
                    if (!(dataAccess.Reader["ImagenUrl"] is DBNull))
                    {
                        aux.ImageUrl = (string)dataAccess.Reader["ImagenUrl"];
                    }
                    aux.Price = (Decimal)dataAccess.Reader["Precio"];
                    filteredList.Add(aux);
                }
                return filteredList;
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

        private string FilterQuery(string query, string criterion, string filter)
        {
            switch (criterion)
            {
                case "Menor a":
                    query += "< '" + filter + "'";
                    break;
                case "Igual a":
                    query += "= '" + filter + "'";
                    break;
                case "Mayor a":
                    query += "> '" + filter + "'";
                    break;
                case "Empieza con":
                    query += "like '" + filter + "%'";
                    break;
                case "Contiene":
                    query += "like '%" + filter + "%'";
                    break;
                case "Termina con":
                    query += "like '%" + filter + "'";
                    break;
            }
            return query;
        }

        public void AddArticle(Article aux)
        {
            try
            {
                dataAccess.SetCommandText("insert into ARTICULOS values(@code, @name, @description, @brand, @category, @url, @price)");
                dataAccess.SetParameter("@code", aux.Code);
                dataAccess.SetParameter("@name", aux.Name);
                dataAccess.SetParameter("@description", aux.Description);
                dataAccess.SetParameter("@brand", aux.Brand.Id);
                dataAccess.SetParameter("@category", aux.Category.Id);
                dataAccess.SetParameter("@url", aux.ImageUrl);
                dataAccess.SetParameter("@price", aux.Price);
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

        public void ModifyArticle(Article aux)
        {
            try
            {
                dataAccess.SetCommandText("UPDATE ARTICULOS SET Codigo = @code, Nombre = @name, Descripcion = @description, IdMarca = @brand, IdCategoria = @category, ImagenUrl = @url, Precio = @price WHERE Id = @id");
                dataAccess.SetParameter("@code", aux.Code);
                dataAccess.SetParameter("@name", aux.Name);
                dataAccess.SetParameter("@description", aux.Description);
                dataAccess.SetParameter("@brand", aux.Brand.Id);
                dataAccess.SetParameter("@category", aux.Category.Id);
                dataAccess.SetParameter("@url", aux.ImageUrl);
                dataAccess.SetParameter("@price", aux.Price);
                dataAccess.SetParameter("@id", aux.Id);
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

        public void DeleteArticle(Article aux)
        {
            try
            {
                dataAccess.SetCommandText("DELETE ARTICULOS WHERE Id = @id");
                dataAccess.SetParameter("@id", aux.Id);
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

        public Article SearchArticleById(int id)
        {
            Article article = new Article();
            try
            {
                dataAccess.SetCommandText("SELECT a.Id, Codigo, Nombre, a.Descripcion, c.Descripcion Categoria, IdCategoria, m.Descripcion Marca, IdMarca, ImagenUrl, Precio " +
                    "FROM ARTICULOS a, CATEGORIAS c, MARCAS m " +
                    $"WHERE IdMarca = m.Id AND IdCategoria = c.Id AND a.Id = {id}");
                dataAccess.ReadData();

                while (dataAccess.Reader.Read())
                {
                    article.Id = (int)dataAccess.Reader["Id"];
                    article.Code = (string)dataAccess.Reader["Codigo"];
                    article.Name = (string)dataAccess.Reader["Nombre"];
                    article.Description = (string)dataAccess.Reader["Descripcion"];
                    article.Brand.Name = (string)dataAccess.Reader["Marca"];
                    article.Brand.Id = (int)dataAccess.Reader["IdMarca"];
                    article.Category.Id = (int)dataAccess.Reader["IdCategoria"];
                    article.Category.Name = (string)dataAccess.Reader["Categoria"];
                    if (!(dataAccess.Reader["ImagenUrl"] is DBNull))
                    {
                        article.ImageUrl = (string)dataAccess.Reader["ImagenUrl"];
                    }
                    article.Price = (Decimal)dataAccess.Reader["Precio"];
                }
                return article;
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
