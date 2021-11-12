using System;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data.Common;
using VeloBikeRepo.Models;
using System.Collections.Generic;

namespace VeloBikeRepo.Repository
{
    public class BikeRepo
    {
        string ConnectionName { get; set; }

        public BikeRepo(string connectionName)
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

        public int addByke(string name, int station)
        {
            string query = $"INSERT INTO bykes (model, stateID, stationID) VALUES('{name}', '1', '{station}');";
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

        public VeloBike getBike(int ID)
        {
            VeloBike b = null;

            string query = $"SELECT * FROM bykes, station, accessibility WHERE bykes.stationID = station.id " +
                $"AND bykes.stateID = accessibility.id AND bykes.id = '{ID}'";

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
                        b = new VeloBike()
                        {
                            ID = (Int32.Parse(row["id"].ToString())),
                            Model = row["model"].ToString(),
                            StationID = row["name"].ToString(),
                            StateiD = row["state"].ToString()
                        };
                    }
                }
                reader.Close();
            }

            return b;
        }

        public List<Bike> getBikesFromStation(string st)
        {
            List<Bike> bikes = null;

            string query = $"SELECT * FROM bykes, station, accessibility WHERE bykes.stationID = station.id " +
                $"AND bykes.stateID = accessibility.id AND station.name = '{st}' AND accessibility.state = 'Свободен'";

            using (var connection = GetDbConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                var reader = cmd.ExecuteReader();

                bikes = new List<Bike>();
                if (reader.HasRows)
                {
                    Bike b = null;
                    foreach (DbDataRecord row in reader)
                    {
                        b = new Bike()
                        {
                            ID = (Int32.Parse(row["id"].ToString())),
                            Model = row["model"].ToString(),
                        };

                        bikes.Add(b);
                    }
                }
                reader.Close();
            }
            return bikes;
        }
        public List<Bike> getBikesWithState(string st)
        {
            List<Bike> bikes = null;

            string query = $"SELECT * FROM bykes, accessibility WHERE bykes.stateID = accessibility.id AND accessibility.state = '{st}'";            

            using (var connection = GetDbConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                var reader = cmd.ExecuteReader();

                bikes = new List<Bike>();
                if (reader.HasRows)
                {
                    Bike b = null;
                    foreach (DbDataRecord row in reader)
                    {
                        b = new Bike()
                        {
                            ID = (Int32.Parse(row["id"].ToString())),
                            Model = row["model"].ToString(),
                        };

                        bikes.Add(b);
                    }
                }
                reader.Close();
            }
            return bikes;
        }

        public int setBusy(int id)
        {
            int number = -1;

            string query = $"UPDATE bykes SET stateID = '2' WHERE id = '{id}'";
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

        public int setRepair(int id)
        {
            int number = -1;

            string query = $"UPDATE bykes SET stateID = '3' WHERE id = '{id}'";
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

        public int setVoid(int id)
        {
            int number = -1;

            string query = $"UPDATE bykes SET stateID = '1' WHERE id = '{id}'";
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

        public int setStation(int id, int st)
        {
            int number = -1;

            string query = $"UPDATE bykes SET stationID = '{st}' WHERE id = '{id}'";
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

        public int updateBike(int id, string model, int state, int station)
        {
            int number = -1;

            string query = $"UPDATE bykes SET model ='{model}', stateID = '{state}', stationID = '{station}' WHERE id = '{id}'";
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

        public int deleteBike(int ID)
        {
            string query = $"Delete FROM bykes WHERE id = '{ID}'";
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
    }
}