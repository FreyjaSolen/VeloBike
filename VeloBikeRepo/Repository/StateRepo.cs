using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeloBikeRepo.Repository
{
    public class StateRepo
    {
        string ConnectionName { get; set; }

        public StateRepo(string connectionName)
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

        public int getState(string name)
        {
            string query = $"SELECT * FROM accessibility WHERE state = '{name}'";
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

        public string getState(int id)
        {
            string query = $"SELECT * FROM accessibility WHERE id = '{id}'";
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
                        result = row["state"].ToString();
                    }
                }
                reader.Close();
            }
            return result;
        }

        public List<string> getStates()
        {
            List<string> states = null;
            string query = $"SELECT state FROM accessibility";

            using (var connection = GetDbConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                var reader = cmd.ExecuteReader();
                states = new List<string>();
                if (reader.HasRows)
                {
                    foreach (DbDataRecord row in reader)
                    {
                        string result = row["state"].ToString();
                        states.Add(result);
                    }
                }
                reader.Close();
            }
            return states;
        }
    }
}
