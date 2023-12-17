using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class UserController
    {
        readonly DataAccess dataAccess = new DataAccess();

        public bool IsEmailAvailable(string email)
        {
            try
            {
                dataAccess.SetCommandText("SELECT email FROM USERS WHERE email = @email");
                dataAccess.SetParameter("@email", email);
                dataAccess.ReadData();
                if (dataAccess.Reader.Read())
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dataAccess.CloseConnection();
            }
            return true;
        }

        public User GetUserById(int userId)
        {
            User user;
            try
            {
                dataAccess.SetCommandText($"SELECT email, pass, nombre, apellido, urlImagenPerfil, admin FROM USERS WHERE Id = {userId}");
                dataAccess.ReadData();
                if (dataAccess.Reader.Read())
                {
                    user = new User
                    {
                        Id = userId,
                        Email = (string)dataAccess.Reader["email"],
                        Password = (string)dataAccess.Reader["pass"],
                        Name = dataAccess.Reader["nombre"] is DBNull ? string.Empty : (string)dataAccess.Reader["nombre"],
                        Surname = dataAccess.Reader["apellido"] is DBNull ? string.Empty : (string)dataAccess.Reader["apellido"],
                        ImageUrl = dataAccess.Reader["urlImagenPerfil"] is DBNull ? string.Empty : (string)dataAccess.Reader["urlImagenPerfil"],
                        IsAdmin = (bool)dataAccess.Reader["admin"]
                    };
                }
                else
                {
                    user = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dataAccess.CloseConnection();
            }

            return user;
        }

        public User Login(string email, string password)
        {
            User user;
            try
            {
                dataAccess.SetCommandText($"SELECT Id, nombre, apellido, urlImagenPerfil, admin FROM USERS WHERE email = '{email}' AND pass = '{password}'");
                dataAccess.ReadData();
                if (dataAccess.Reader.Read())
                {
                    user = new User
                    {
                        Id = (int)dataAccess.Reader["id"],
                        Email = email,
                        Password = password,
                        Name = dataAccess.Reader["nombre"] is DBNull ? string.Empty : (string)dataAccess.Reader["nombre"],
                        Surname = dataAccess.Reader["apellido"] is DBNull ? string.Empty : (string)dataAccess.Reader["apellido"],
                        ImageUrl = dataAccess.Reader["urlImagenPerfil"] is DBNull ? string.Empty : (string)dataAccess.Reader["urlImagenPerfil"],
                        IsAdmin = (bool)dataAccess.Reader["admin"]
                    };
                }
                else
                {
                    user = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dataAccess.CloseConnection();
            }

            return user;
        }

        public User SignUp(string email, string password)
        {
            User user = new User();
            try
            {
                dataAccess.SetCommandText($"INSERT INTO USERS (email, pass) VALUES ('{email}', '{password}')");
                dataAccess.ExecuteNonQuery();
                user.Email = email;
                user.Password = password;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dataAccess.CloseConnection();
            }

            return user;
        }


        public void ModifyUserInformation(User user)
        {
            try
            {
                dataAccess.SetCommandText($"UPDATE USERS SET nombre = '{user.Name}', apellido = '{user.Surname}', urlImagenPerfil = '{user.ImageUrl}'" +
                    $"WHERE Id = {user.Id}");
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
    }
}
