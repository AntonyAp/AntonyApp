using System;
using System.Data.SqlClient;
using DomainModel;
using Services.Services.Contracts;

namespace Services.DataAccessProviders
{
    // TODO: Store users in the database. Connect the database using ADO.NET
    public class AdoNetDataAccessProvider : IDataAccessProvider
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=UserStore;Integrated Security=True";

        public void Add(User user)
        {
            string _name = user.Name;string _password = user.Password;string _login = user.Login;
            string sqlExpression = "INSERT INTO Users (password,login,name) VALUES (@password, @login,@name)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter passwordParam = new SqlParameter("@password", _password);
                command.Parameters.Add(passwordParam);
                SqlParameter loginParam = new SqlParameter("@login", _login);
                command.Parameters.Add(loginParam);
                SqlParameter nameParam = new SqlParameter("@name", _name);
                command.Parameters.Add(nameParam);
                int number = command.ExecuteNonQuery();
            }
         }

        public void Save(User user)
        {
            
        }

        public string CheckData(User user)
        {
            string log = user.Login;string pas = user.Password;
            string sqlExpression = "select * from users where login=@login AND password=@password";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter loginParam = new SqlParameter("@login", log);
                command.Parameters.Add(loginParam);
                SqlParameter passwordParam = new SqlParameter("@password", pas);
                command.Parameters.Add(passwordParam);
                SqlDataReader reader = command.ExecuteReader();
                var redirectViewName = reader.HasRows ? "Football" : "LoginPage";
                return redirectViewName;
            }
        }
    }
}
