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
            throw new NotImplementedException();
        }

        public void Edit(User user)
        {
            throw new NotImplementedException();
        }

        public User FindUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> ListOfUsers()
        {
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
