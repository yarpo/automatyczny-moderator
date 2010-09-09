using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace automatyczny_moderator
{
    public class ModeratorLogDB : ModeratorLog
    {
        const string READING = "reading posts";
        const string READ_LAST_DATE = "last date reading...";
        const string START_OF_WORK = "start of moderation";
        const string END_OF_WORK = "end of moderation this time";

        private const string TABLE = "automod_mlog";
        private const string DATE_NAME = "date";
        private const string INFO_NAME = "info";

        private const int DATE_INDEX = 1;
        private const int INFO_INDEX = 2;

        private const string THE_VERY_BEGINNING = "1970-01-01 00:00:01";

        #region ModeratorLog Members
        public string getLastModerationDate()
        {
            log(READ_LAST_DATE);
            string sql = "SELECT " + DATE_NAME + " FROM " + TABLE;
            MySqlDataReader result = DatabaseSrc.query(sql);

            return (result.Read()) ? result.GetString(0) : THE_VERY_BEGINNING;
        }

        public void startOfWork()
        {
            log(START_OF_WORK);
        }

        public void reading()
        {
            log(READING);
        }


        public void endOfWork()
        {
            log(END_OF_WORK);
        }

        public void log(string status)
        {
            string now = getCurrentDateString();
            string sql = "INSERT INTO " + TABLE + "(id, date, info)" +
                " VALUES (NULL, '" + now + "', '"  + status + "')";
            DatabaseSrc.query(sql);
        }

        #endregion  
        private string getCurrentDateString()
        {
            return DateTime.Now.ToString();
        }
    }
}
