using System;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data.Common;
using VeloBikeRepo.Models;
using System.Collections.Generic;

namespace VeloBikeRepo.Repository
{
    public class UserRepo
    {
        string ConnectionName { get; set; }

        public UserRepo(string connectionName)
        {
            ConnectionName = connectionName;
        }

        private MySqlConnection GetDbConnection()
        {
            var settings = ConfigurationManager.ConnectionStrings[ConnectionName];
            var factory = MySqlClientFactory.Instance;
            var connection = factory.CreateConnection();
            connection.ConnectionString = settings.ConnectionString;
            return (MySqlConnection)connection;
        }

        public int addUser(string nick, string password)
        {
            string query = $"INSERT INTO users (nick, role, password) VALUES('{nick}', 'user', '{password}');";
            int number = -1;
            using (var connection = GetDbConnection())
            {
                try
                {
                    connection.Open();
                    var cmd = connection.CreateCommand();
                    cmd.CommandText = query;
                    cmd.Connection = connection;
                    number = cmd.ExecuteNonQuery();
                    Console.WriteLine("Успешно добавлено: {0}", number);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return number;
        }

        public bool isUserExist(string nick)
        {
            bool result = false;
            string query = $"SELECT * FROM users WHERE nick = '{nick}'";

            using (var connection = GetDbConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    result = true;
                }
                Console.WriteLine("Результат: {0}", result);
                reader.Close();
            }

            return result;
        }

        public bool isLogExist(string nick, string password)
        {
            bool result = false;
            string query = $"SELECT * FROM users WHERE nick = '{nick}' AND password = '{password}'";

            using (var connection = GetDbConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    result = true;
                }
                Console.WriteLine("Результат: {0}", result);
                reader.Close();
            }

            return result;
        }

        public bool updatePassword(string userName, string password)
        {
            int result;
            string query = $"UPDATE users SET Password = '{password}' WHERE nick = '{userName}'";
            using (var connection = GetDbConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;
                result = cmd.ExecuteNonQuery();
            }
            if (result == 1)
            {
                return true;
            }
            else return false;
        }

        public User userInfo(string login)
        {
            string query = $"SELECT * FROM users WHERE nick = '{login}'";
            User u = null;
            using (var connection = GetDbConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    foreach (DbDataRecord row in reader)
                    {
                        u = new User()
                        {
                            ID = (Int32.Parse(row["id"].ToString())),
                            UserName = row["NickName"].ToString(),
                            Name = row["Name"].ToString(),
                            LastName = row["LastName"].ToString()
                        };
                    }
                }
                reader.Close();
                return u;
            }
        }

        public bool isManager(string login)
        {
            bool result = false;

            string query = $"SELECT * FROM users WHERE nick = '{login}' AND role = 'manager'";

            using (var connection = GetDbConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    foreach (DbDataRecord row in reader)
                    {
                        result = true;
                    }
                }
                reader.Close();
            }
            return result;
        }

        public int getUser(string name)
        {
            string query = $"SELECT * FROM users WHERE nick = '{name}'";
            int result = -1;
            using (var connection = GetDbConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    foreach (DbDataRecord row in reader)
                    {
                        result = Int32.Parse(row["id"].ToString());
                    }
                }
                reader.Close();
                return result;
            }
        }

        public string getUser(int id)
        {
            string query = $"SELECT * FROM users WHERE id = '{id}'";
            string result = null;
            using (var connection = GetDbConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    foreach (DbDataRecord row in reader)
                    {
                        result = row["nick"].ToString();
                    }
                }
                reader.Close();
            }
            return result;
        }

        public bool updateName(string nick, string name)
        {
            int result;
            string query = $"UPDATE users SET frstName = '{name}' WHERE nick = '{nick}'";
            using (var connection = GetDbConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;
                result = cmd.ExecuteNonQuery();
            }
            if (result == 1)
            {
                return true;
            }
            else return false;
        }

        public bool ifName(int ID)
        {
            string query = $"SELECT frstName FROM users WHERE id = '{ID}' AND frstName IS NOT NULL";
            bool result = false;
            using (var connection = GetDbConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    foreach (DbDataRecord row in reader)
                    {
                        result = true;
                    }
                }
                reader.Close();
            }
            return result;
        }

        public string getName(int ID)
        {
            string query = $"SELECT frstName FROM users WHERE id = '{ID}'";
            string result = null;
            using (var connection = GetDbConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    foreach (DbDataRecord row in reader)
                    {
                        result = row["frstName"].ToString();
                    }
                }
                reader.Close();
            }
            return result;
        }

        public bool updateLstName(string nick, string lstName)
        {
            int result;
            string query = $"UPDATE users SET lstName = '{lstName}' WHERE nick = '{nick}'";
            using (var connection = GetDbConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;
                result = cmd.ExecuteNonQuery();
            }
            if (result == 1)
            {
                return true;
            }
            else return false;
        }

        public List<string> getClients()
        {
            List<string> users = null;
            string query = $"SELECT nick FROM users WHERE role = 'user'";

            using (var connection = GetDbConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                var reader = cmd.ExecuteReader();
                users = new List<string>();
                if (reader.HasRows)
                {
                    foreach (DbDataRecord row in reader)
                    {
                        string u = row["nick"].ToString();
                        users.Add(u);
                    }
                }
                reader.Close();
            }
            return users;
        }
    }
}
