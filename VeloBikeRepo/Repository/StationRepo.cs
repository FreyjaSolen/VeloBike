using System;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data.Common;
using VeloBikeRepo.Models;
using System.Collections.Generic;

namespace VeloBikeRepo.Repository
{
    public class StationRepo
    {
        string ConnectionName { get; set; }

        public StationRepo(string connectionName)
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

        public int addStation(string name)
        {
            string query = $"INSERT INTO station (name) VALUES('{name}');";
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

        public int delStation(string name)
        {
            string query = $"Delete FROM station WHERE name = '{name}'";
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
                    Console.WriteLine("Успешно удалено: {0}", number);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return number;
        }

        public int getStation(string name)
        {
            string query = $"SELECT * FROM station WHERE name = '{name}'";
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
            }
            return result;
        }

        public string getStation(int id)
        {
            string query = $"SELECT * FROM station WHERE id = '{id}'";
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
                        result = row["name"].ToString();
                    }
                }
                reader.Close();
            }
            return result;
        }

        public List<string> getAllStations()
        {
            List<string> st = null;
            string query = $"SELECT * FROM station";
            string result = null;
            using (var connection = GetDbConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                var reader = cmd.ExecuteReader();
                st = new List<string>();
                if (reader.HasRows)
                {
                    foreach (DbDataRecord row in reader)
                    {
                        result = row["name"].ToString();
                        st.Add(result);
                    }
                }
                reader.Close();
            }
            return st;
        }

        public int updateStation(int id, string name)
        {
            int number = -1;

            string query = $"UPDATE station SET name ='{name}' WHERE id = '{id}'";
            using (var connection = GetDbConnection())
            {
                try
                {
                    connection.Open();
                    var cmd = connection.CreateCommand();
                    cmd.CommandText = query;
                    cmd.Connection = connection;
                    number = cmd.ExecuteNonQuery();
                    Console.WriteLine("Успешно обновлено: {0}", number);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return number;
        }
    }
}
