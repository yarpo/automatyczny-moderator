using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using MySql.Data.MySqlClient;

namespace automatyczny_moderator
{
    public class UserHistoryDB : UserHistory
    {
        const string TABLE = "automod_ulog";

        private int id;

        public UserHistoryDB( int id )
        {
            this.id = id;
        }

        #region UserHistory Members

        public ArrayList getWarnings()
        {
            string sql = "SELECT * FROM " + TABLE + " WHERE id = " + this.id;
            MySqlDataReader data = DatabaseSrc.query(sql);
            ArrayList result = new ArrayList();

            while (data.Read())
            {
                result.Add(data.GetString(0));
            }

            return result;
        }

        public void log(string status)
        {
            string now = getCurrentDateString();
            string sql = "INSERT INTO " + TABLE + "(id, date, info)" +
                " VALUES (NULL, '" + now + "', '" + status + "')";
            DatabaseSrc.query(sql);
        }

        #endregion

        private string getCurrentDateString()
        {
            return DateTime.Now.ToString();
        }
    }
}
