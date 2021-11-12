using System;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data.Common;
using VeloBikeRepo.Models;
using System.Collections.Generic;

namespace VeloBikeRepo.Repository
{
    public class HistoryRepo
    {
        string ConnectionName { get; set; }

        public HistoryRepo(string connectionName)
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

        public int addOrder(Order or)
        {
            string query = $"INSERT INTO history (userID, date, beginStID, bykeID) VALUES('{or.User}', '{or.Date}', '{or.BeginSt}', '{or.Byke}');";
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

        public int addOrder(int User, long Date, int BeginSt, int Byke)
        {
            string query = $"INSERT INTO history (userID, date, beginStID, bykeID) VALUES('{User}', '{Date}', '{BeginSt}', '{Byke}');";
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
        public int addStAndCoast(int id, int station, double coast)
        {
            int number = -1;

            string query = $"UPDATE history SET endStID = '{station}', cost = '{coast}' WHERE id = '{id}'";
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

        public List<string> getClientHistory(int userName)
        {
            List<string> history = null;
            string query = $"SELECT history.id, users.nick, history.date, station.name, st.name as nameSt, bykes.model, history.cost FROM history, users, station, station as st, bykes WHERE history.userID = users.id AND history.beginStID = station.id AND history.endStID = st.id AND history.bykeID = bykes.id AND history.userID = '{userName}'";

            using (var connection = GetDbConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                var reader = cmd.ExecuteReader();
                history = new List<string>();
                if (reader.HasRows)
                {
                    foreach (DbDataRecord row in reader)
                    {
                        History h = new History()
                        {
                            ID = (Int32.Parse(row["id"].ToString())),
                            User = row["nick"].ToString(),
                            Date = (long.Parse(row["date"].ToString())),
                            BeginSt = row["name"].ToString(),
                            EndSt = row["nameSt"].ToString(),
                            Bike = row["model"].ToString(),
                            Cost = double.Parse(row["cost"].ToString())
                        };
                        DateTime dt = new DateTime(h.Date);
                        history.Add($"Дата: {dt.ToString("dd MMMM, yyyy")}, стоимость: {h.Cost} грн.\nБронирование со станции {h.BeginSt} до станции {h.EndSt}\nМодель: {h.Bike}");
                    }
                }
                reader.Close();
            }
            return history;
        }

        public List<string> getClientOrders(int userName)
        {
            List<string> history = null;
            string query = $"SELECT history.id, users.nick, history.date, station.name, bykes.model FROM history, users, station, bykes WHERE history.userID = users.id AND history.beginStID = station.id AND history.bykeID = bykes.id AND history.cost IS NULL AND history.userID = '{userName}'";

            using (var connection = GetDbConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                var reader = cmd.ExecuteReader();
                history = new List<string>();
                if (reader.HasRows)
                {
                    foreach (DbDataRecord row in reader)
                    {
                        History h = new History()
                        {
                            ID = (Int32.Parse(row["id"].ToString())),
                            User = row["nick"].ToString(),
                            Date = (long.Parse(row["date"].ToString())),
                            BeginSt = row["name"].ToString(),
                            Bike = row["model"].ToString(),
                        };
                        DateTime dt = new DateTime(h.Date);
                        history.Add($"Дата: {dt.ToString("dd MMMM, yyyy")}, взято в аренду со станции {h.BeginSt}\nМодель: {h.Bike}");
                    }
                }
                reader.Close();
            }
            return history;
        }

        public List<OrderText> getMngHistory(string userName)
        {
            List<OrderText> history = null;
            string query = $"SELECT history.id, users.nick, history.date, station.name, st.name as nameSt, bykes.model, history.cost FROM history, users, station, station as st, bykes WHERE history.userID = users.id AND history.beginStID = station.id AND history.endStID = st.id AND history.bykeID = bykes.id AND users.nick = '{userName}'";

            using (var connection = GetDbConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                var reader = cmd.ExecuteReader();
                history = new List<OrderText>();
                if (reader.HasRows)
                {
                    foreach (DbDataRecord row in reader)
                    {
                        History h = new History()
                        {
                            ID = (Int32.Parse(row["id"].ToString())),
                            User = row["nick"].ToString(),
                            Date = (long.Parse(row["date"].ToString())),
                            BeginSt = row["name"].ToString(),
                            EndSt = row["nameSt"].ToString(),
                            Bike = row["model"].ToString(),
                            Cost = double.Parse(row["cost"].ToString())
                        };
                        DateTime dt = new DateTime(h.Date);
                        OrderText orderText = new OrderText(h.ID, $"Дата: {dt.ToString("dd MMMM, yyyy")}, заказчик: {h.User}, стоимость: {h.Cost} грн.\nБронирование со станции {h.BeginSt} до станции {h.EndSt}\nМодель: {h.Bike}");
                        history.Add(orderText);
                    }
                }
                reader.Close();
            }
            return history;
        }

        public List<OrderText> getMngOrders(string userName)
        {
            List<OrderText> history = null;
            string query = $"SELECT history.id, users.nick, history.date, station.name, bykes.model FROM history, users, station, bykes WHERE history.userID = users.id AND history.beginStID = station.id AND history.bykeID = bykes.id AND history.cost IS NULL AND users.nick = '{userName}'";

            using (var connection = GetDbConnection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                var reader = cmd.ExecuteReader();
                history = new List<OrderText>();
                if (reader.HasRows)
                {
                    foreach (DbDataRecord row in reader)
                    {
                        History h = new History()
                        {
                            ID = (Int32.Parse(row["id"].ToString())),
                            User = row["nick"].ToString(),
                            Date = (long.Parse(row["date"].ToString())),
                            BeginSt = row["name"].ToString(),
                            Bike = row["model"].ToString(),
                        };
                        DateTime dt = new DateTime(h.Date);
                        OrderText orderText = new OrderText(h.ID, $"Дата: {dt.ToString("dd MMMM, yyyy")}, заказчик: {h.User}.\nВзято в аренду со станции {h.BeginSt}\nМодель: {h.Bike}");
                        history.Add(orderText);
                    }
                }
                reader.Close();
            }
            return history;
        }

        public History getOrderFromID(int ID)
        {
            History h = null;
            string query = $"SELECT history.id, users.nick, history.date, station.name, bykes.model FROM history, users, station, bykes WHERE history.userID = users.id AND history.beginStID = station.id AND history.bykeID = bykes.id AND history.cost IS NULL AND history.id = '{ID}'";

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
                        h = new History()
                        {
                            ID = (Int32.Parse(row["id"].ToString())),
                            User = row["nick"].ToString(),
                            Date = (long.Parse(row["date"].ToString())),
                            BeginSt = row["name"].ToString(),
                            Bike = row["model"].ToString(),
                        };
                    }
                }
                reader.Close();
            }
            return h;
        }

        public int getBykeIDFromOrder(int OrderID)
        {
            int result = -1;
            string query = $"SELECT bykeID FROM history WHERE history.id = '{OrderID}'";

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
                        result = (Int32.Parse(row["bykeID"].ToString()));
                    }
                }
                reader.Close();
            }
            return result;
        }
    }
}