using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace automatyczny_moderator
{
    public class ModeratorLogDB : ModeratorLog
    {
        const string READ_LAST_DATE = "last date reading...";
        const string WRITE_LAST_DATE = "last date writing...";

        private const string TABLE = "automod_mlog";
        private const string DATE_NAME = "date";
        private const string INFO_NAME = "info";

        private const int DATE_INDEX = 0;
        private const int INFO_INDEX = 1;

        private const string THE_VERY_BEGINNING = "1970-01-01 00:00:01";

        #region ModeratorLog Members
        public string getLastModerationDate()
        {
            string sql = "SELECT " + DATE_NAME + " FROM " + TABLE;
            MySqlDataReader result = DatabaseSrc.query(sql);
            if (result.Read())
            {
                return result.GetString(DATE_INDEX);
            }
            return THE_VERY_BEGINNING;
        }

        public void setLastModerationDate()
        {
            DateTime saveNow = DateTime.Now;
            setLastModerationDate(DateTime.Now.ToString());
        }

        public void setLastModerationDate(string date)
        {
            // zapisz do bazy danych
        }

        public void log(string status)
        {
            string now = getCurrentDateString();
            string sql = "INSERT INTO " + TABLE + 
                " VALUES ('" + now + "', '"  + status + "')";
            DatabaseSrc.query(sql);
        }

        #endregion  
        private string getCurrentDateString()
        {
            return DateTime.Now.ToString();
        }
    }
}
