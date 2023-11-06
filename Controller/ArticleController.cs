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
        private DataAccess dataAccess = new DataAccess();

        public List<Article> listArticles()
        {
            List<Article> articleList = new List<Article>();
            try
            {
                dataAccess.setCommandText("Select a.Id, Codigo, Nombre, a.Descripcion, c.Descripcion Categoria, IdCategoria, m.Descripcion Marca, IdMarca, ImagenUrl, Precio from ARTICULOS a, CATEGORIAS c, MARCAS m Where IdMarca=m.Id and IdCategoria = c.Id");
                dataAccess.readData();

                while (dataAccess.Reader.Read())
                {
                    Article aux = new Article();
                    aux.Id= (int)dataAccess.Reader["Id"];
                    aux.Code = (string)dataAccess.Reader["Codigo"];
                    aux.Name = (string)dataAccess.Reader["Nombre"];
                    aux.Description = (string)dataAccess.Reader["Descripcion"];
                    aux.Category.Name = (string)dataAccess.Reader["Categoria"];
                    aux.Category.Id = (int)dataAccess.Reader["IdCategoria"];
                    aux.Brand.Name = (string)dataAccess.Reader["Marca"];
                    aux.Brand.Id = (int)dataAccess.Reader["IdMarca"];
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
                dataAccess.closeConnection();
            }
        }

        public List<Article> filterSearch(string field, string criterion, string filter)
        {
            string query = "Select a.Id, Codigo, Nombre, a.Descripcion, c.Descripcion Categoria, IdCategoria, m.Descripcion Marca, IdMarca, ImagenUrl, Precio from ARTICULOS a, CATEGORIAS c, MARCAS m Where IdMarca=m.Id and IdCategoria = c.Id and ";
            List<Article> filteredList = new List<Article>();

            switch (field)
            {
                case "Id":
                    query += filterQuery("a.Id ", criterion, filter);
                    break;
                case "Código":
                    query += filterQuery("Codigo ", criterion, filter);
                    break;
                case "Nombre":
                    query += filterQuery("Nombre ", criterion, filter);
                    break;
                case "Precio":
                    query += filterQuery("Precio ", criterion, filter);
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
                dataAccess.setCommandText(query);
                dataAccess.readData();
                while (dataAccess.Reader.Read())
                {
                    Article aux = new Article();
                    aux.Id = (int)dataAccess.Reader["Id"];
                    aux.Code = (string)dataAccess.Reader["Codigo"];
                    aux.Name = (string)dataAccess.Reader["Nombre"];
                    aux.Description = (string)dataAccess.Reader["Descripcion"];
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
                dataAccess.closeConnection();
            }
        }

        private string filterQuery(string query, string criterion, string filter)
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

        public void addArticle(Article aux)
        {
            try
            {
                dataAccess.setCommandText("insert into ARTICULOS values(@code, @name, @description, @brand, @category, @url, @price)");
                dataAccess.setParameters("@code", aux.Code);
                dataAccess.setParameters("@name", aux.Name);
                dataAccess.setParameters("@description", aux.Description);
                dataAccess.setParameters("@brand", aux.Brand.Id);
                dataAccess.setParameters("@category", aux.Category.Id);
                dataAccess.setParameters("@url", aux.ImageUrl);
                dataAccess.setParameters("@price", aux.Price);
                dataAccess.nonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dataAccess.closeConnection();
            }
        }

        public void modifyArticle(Article aux)
        {
            try
            {
                dataAccess.setCommandText("UPDATE ARTICULOS SET Codigo = @code, Nombre = @name, Descripcion = @description, IdMarca = @brand, IdCategoria = @category, ImagenUrl = @url, Precio = @price WHERE Id = @id");
                dataAccess.setParameters("@code", aux.Code);
                dataAccess.setParameters("@name", aux.Name);
                dataAccess.setParameters("@description", aux.Description);
                dataAccess.setParameters("@brand", aux.Brand.Id);
                dataAccess.setParameters("@category", aux.Category.Id);
                dataAccess.setParameters("@url", aux.ImageUrl);
                dataAccess.setParameters("@price", aux.Price);
                dataAccess.setParameters("@id", aux.Id);
                dataAccess.nonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dataAccess.closeConnection();
            }
        }

        public void deleteArticle(Article aux)
        {
            try
            {
                dataAccess.setCommandText("DELETE ARTICULOS WHERE Id = @id");
                dataAccess.setParameters("@id", aux.Id);
                dataAccess.nonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dataAccess.closeConnection();
            }
        }
        
    }
}
