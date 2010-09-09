using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace automatyczny_moderator
{
    class DatabaseSrc
    {
        static public MySqlConnection connection = null;
        protected const string DB_HOST = "localhost";
        protected const string DB_NAME = "forum";
        protected const string DB_USER = "moderator";
        protected const string DB_PASS = "qwe123";

        static public MySqlConnection getConnection()
        {
            if (null == connection)
            {
                connection = new MySqlConnection(
                            "server=" + DB_HOST + 
                            ";database="+ DB_NAME +
                            ";uid=" + DB_USER +
                            ";password=" + DB_PASS
                );
            }
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            return connection;
        }

        static public void closeConnection()
        {
            if (null != connection && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        static public MySqlDataReader query(string sql)
        {
            closeConnection();
            getConnection();
            MySqlCommand mysqlCmd = new MySqlCommand(sql, connection);
            Console.WriteLine(sql);
            MySqlDataReader result = mysqlCmd.ExecuteReader();
            return result;
        }
    }
}