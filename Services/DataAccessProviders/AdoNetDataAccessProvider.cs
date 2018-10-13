using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DomainModel;
using Services.Services.Contracts;
namespace Services.DataAccessProviders
{
    // TODO: Store users in the database. Connect the database using ADO.NET
    public class AdoNetDataAccessProvider : IDataAccessProvider
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=UserStore;Integrated Security=True";
        //string connectionString = ConfigurationManager.ConnectionStrings["UserStore"].ConnectionString;
        public void Add(User user)
        {
            var name = user.Name;
            var password = user.Password;
            var login = user.Login;
            var sqlExpression = "INSERT INTO Users (password,login,name) VALUES (@password, @login,@name)";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                var passwordParam = new SqlParameter("@password", password);
                command.Parameters.Add(passwordParam);
                var loginParam = new SqlParameter("@login", login);
                command.Parameters.Add(loginParam);
                var nameParam = new SqlParameter("@name", name);
                command.Parameters.Add(nameParam);
                int number = command.ExecuteNonQuery();
            }
         }

        public void Delete(int id)
        {
            var sqlExpression = "DELETE  FROM users where Id=@id ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                var IDparam = new SqlParameter("@id", id);
                command.Parameters.Add(IDparam);
                var number = command.ExecuteNonQuery();
             }
        }

        public void Edit(User user)
        {
            var id = user.Id;
            var log = user.Login;
            var pas = user.Password;
            var name = user.Name;
            var sqlExpression = "update users set  login=@login, password=@password,name=@name where id=@id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                var loginParam = new SqlParameter("@login", log);
                command.Parameters.Add(loginParam);
                var passwordParam = new SqlParameter("@password", pas);
                command.Parameters.Add(passwordParam);
                var nameParam = new SqlParameter("@name", name);
                command.Parameters.Add(nameParam);
                var IDparam = new SqlParameter("@id", id);
                command.Parameters.Add(IDparam);
                var reader = command.ExecuteReader();

            }
        }

        public User FindUser(int id)
        {
            string sqlExpression = "SELECT * FROM Users where id=@id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                var IDparam = new SqlParameter("@id", id);
                command.Parameters.Add(IDparam);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var user = new User();
                    user.Id = reader.GetInt32(0);
                    user.Password = reader.GetString(1);
                    user.Login = reader.GetString(2);
                    user.Name = reader.GetString(3);
                    return user;
                }
            }

            throw new NotImplementedException();
        }

        public List<User> ListOfUsers()
        {
            var users = new List<User>();
            string sqlExpression = "SELECT * FROM Users";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                { var user=new User();
                    user.Id = reader.GetInt32(0);
                    user.Password = reader.GetString(1);
                    user.Login = reader.GetString(2);
                    user.Name = reader.GetString(3);
                    users.Add(user);
                }

                return users;
            }

            throw new NotImplementedException();
        }

        public bool ValidateCredentials(User user)
        {
            var correctData = false;
            var log = user.Login;
            var pas = user.Password;
            var sqlExpression = "select * from users where login=@login AND password=@password";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                var loginParam = new SqlParameter("@login", log);
                command.Parameters.Add(loginParam);
                var passwordParam = new SqlParameter("@password", pas);
                command.Parameters.Add(passwordParam);
                var reader = command.ExecuteReader();
                if (reader.HasRows) correctData = true;
                return correctData;
            }
        }
    }
}
