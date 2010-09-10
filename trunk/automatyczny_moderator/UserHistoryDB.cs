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

        private int iduser;

        public UserHistoryDB( int id )
        {
            this.iduser = id;
        }

        #region UserHistory Members

        public ArrayList getWarnings()
        {
            string sql = "SELECT * FROM " + TABLE + " WHERE iduser = " + this.iduser;
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
            string sql = "INSERT INTO " + TABLE + 
                "(id, iduser, date, info)" +
                " VALUES (NULL," + this.iduser + 
                " '" + now + "', '" + status + "')";
            DatabaseSrc.query(sql);
        }

        public void warning(string msg)
        {
            log(msg);
        }

        public void deletePost(string msg)
        {
            log(msg);
        }

        public void ban(string msg)
        {
            log(msg);
        }

        public void deleteUser(string msg)
        {
            log(msg);
        }

        #endregion

        private string getCurrentDateString()
        {
            return DateTime.Now.ToString();
        }
    }
}
